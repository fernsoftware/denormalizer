using System;
using System.Collections.Generic;
using System.Linq;

using Denormalizer.Configuration;
using Denormalizer.Database;
using Denormalizer.Steps;
using Denormalizer.Steps.Parameters;

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

            _steps.Enqueue(new CustomerAccountsStep(new CustomerAccountsParameters(DateTime.UtcNow)
            {
                CheckDigit = 9999,
                ProductTypes = 3,
                LoanStatus = 255,
                CustomerTypes = 31,
                RefinanceStart = DateTime.MinValue,
                RefinanceEnd = DateTime.MaxValue
            }));
        }

        public void Run()
        {
            var destinationContext = new AzureContext(_configuration.Destination.ConnectionString);

            foreach (var source in _configuration.Sources.OrderBy(x => x.Order))
            {
                var sourceContext = new AbacusContext(source.ConnectionString);

                foreach (var step in _steps)
                {
                    step.Execute(source.DatabaseId, sourceContext, destinationContext);
                }
            }
        }
    }
}