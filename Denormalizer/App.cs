using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using Denormalizer.Configuration;
using Denormalizer.Database;
using Denormalizer.Steps;

namespace Denormalizer
{
    internal class App
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly Queue<IStep> _steps;

        public App(IConfiguration configuration)
        {
            _configuration = configuration;

            var autoMapperConfiguration = new MapperConfiguration(config =>
            {
                //config.CreateMap<Entity1, Entity2>()
            });

            _mapper = autoMapperConfiguration.CreateMapper();

            _steps = new Queue<IStep>();

            _steps.Enqueue(new CustomerAccountsStep());
            // Add more steps
        }

        /// <summary>
        /// Main entry point for the synchronization app.
        /// </summary>
        public async Task Run()
        {
            var destinationContext = new AzureContext(_configuration.Destination.ConnectionString);

            foreach (var source in _configuration.Sources)
            {
                var sourceContext = new AbacusContext(source.ConnectionString);

                foreach (var step in _steps)
                {
                    await step.Execute(sourceContext, destinationContext, _mapper);
                }
            }
        }
    }
}