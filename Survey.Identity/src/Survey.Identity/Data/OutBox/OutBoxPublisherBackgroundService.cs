using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Survey.Identity.Data.OutBox
{
    public class OutBoxPublisherBackgroundService : BackgroundService
    {
        private readonly OutBoxPublisher _publisher;

        public OutBoxPublisherBackgroundService(OutBoxPublisher publisher)
        {
            _publisher = publisher;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await _publisher.PublishPendingAsync(stoppingToken);
                }
                catch (Exception ex)
                {
                    // We don't want the background service to stop while the application continues,
                    // so catching and logging.
                    // Should certainly have some extra checks for the reasons, to act on it. 
                }

                await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
            }
        }
    }

}
