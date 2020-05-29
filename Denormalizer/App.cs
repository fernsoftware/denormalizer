using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Denormalizer.Configuration;
using Denormalizer.Database;
using Denormalizer.Steps;

namespace Denormalizer
{
    internal class App
    {
        private readonly IConfiguration _configuration;
        private readonly Queue<IStep> _steps;

        public App(IConfiguration configuration)
        {
            _configuration = configuration;

            _steps = new Queue<IStep>();

            _steps.Enqueue(new CustomerAccountsStep(
                valueDate: DateTime.UtcNow,
                currencyId: 0));
        }

        public async Task Run()
        {
            var destinationContext = new AzureContext(_configuration.Destination.ConnectionString);

            foreach (var source in _configuration.Sources)
            {
                var sourceContext = new AbacusContext(source.ConnectionString);

                foreach (var step in _steps)
                {
                    await step.Execute(sourceContext, destinationContext);
                }
            }
        }
    }
}