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
                RefinanceStart = new DateTime(1900, 1, 1),
                RefinanceEnd = new DateTime(2079, 1, 1)
            }));
        }

        public void Run()
        {
            var factory = new AzureContextFactory();
            var destinationContext = factory.CreateDbContext(null);

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