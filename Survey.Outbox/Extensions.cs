using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Survey.Outbox.Configurator;
using Survey.Outbox.Processors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Outbox
{
    public static class Extensions
    {
        private const string SectionName = "outbox";
        private const string RegistryName = "messageBrokers.outbox";
        public static void RegisterOutbox(this IServiceCollection services, IConfiguration configuration,
             string sectionName = SectionName)
        {
            if (string.IsNullOrWhiteSpace(sectionName))
            {
                sectionName = SectionName;
            }
            var options = new OutboxOptions();
            configuration.GetSection(sectionName).Bind(options);
            services.AddSingleton(options);
            services.AddHostedService<OutboxProcessor>();
        }
    }
}
