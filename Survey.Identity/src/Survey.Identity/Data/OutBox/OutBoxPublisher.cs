using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Survey.Identity.Data.OutBox
{
    public class OutBoxPublisher
    {
        private const int MaxBatchSize = 100;
        private static readonly TimeSpan MinimumMessageAgeToBatch = TimeSpan.FromSeconds(30);

        private readonly IServiceScopeFactory _serviceScopeFactory;

        public OutBoxPublisher(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task PublishPendingAsync(CancellationToken ct)
        {
            // Invokes PublishBatchAsync while batches are being published, to exhaust all pending messages.

            // ReSharper disable once EmptyEmbeddedStatement - the logic is part of the method invoked in the condition 
            while (!ct.IsCancellationRequested && await PublishBatchAsync(ct)) ;
        }

        // returns true if there is a new batch to publish, false otherwise
        private async Task<bool> PublishBatchAsync(CancellationToken ct)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<SurveyIdentityContext>();

                using (var transaction = await db.Database.BeginTransactionAsync(ct))
                {
                    try
                    {
                        var messages = await GetMessageBatchAsync(db, ct);

                        if (messages.Count > 0 && await TryDeleteMessagesAsync(db, messages, ct))
                        {
                            // TODO: actually push the events to the event bus

                            // ReSharper disable once MethodSupportsCancellation - messages already published, try to delete them locally
                            transaction.Commit();

                            return await IsNewBatchAvailableAsync(db, ct);
                        }

                        transaction.Rollback();

                        // if we got here, there either aren't messages available or are being published concurrently
                        // in either case, we can break the loop
                        return false;
                    }
                    catch (Exception)
                    {
                        // ReSharper disable once MethodSupportsCancellation - try to clean up things before letting go
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        private static Task<List<OutboxMessage>> GetMessageBatchAsync(SurveyIdentityContext db, CancellationToken ct)
            => MessageBatchQuery(db)
            .Where(a => a.ProcessedAt == null)
                .Take(MaxBatchSize)
                .ToListAsync(ct);

        private static Task<bool> IsNewBatchAvailableAsync(SurveyIdentityContext db, CancellationToken ct)
            => MessageBatchQuery(db).AnyAsync();

        private static IQueryable<OutboxMessage> MessageBatchQuery(SurveyIdentityContext db)
            => db.Set<OutboxMessage>()
                .Where(m => m.CreatedAt < GetMinimumMessageAgeToBatch());

        private async Task<bool> TryDeleteMessagesAsync(
            SurveyIdentityContext db,
            List<OutboxMessage> messages,
            CancellationToken ct)
        {
            try
            {
                messages.ForEach(a => a.Process());
                await db.SaveChangesAsync(ct);
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        private static DateTime GetMinimumMessageAgeToBatch()
        {
            return DateTime.UtcNow - MinimumMessageAgeToBatch;
        }
    }

}
