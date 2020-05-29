using System.Threading.Tasks;

using AutoMapper;

using Denormalizer.Configuration;

namespace Denormalizer
{
    internal class App
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public App(IConfiguration configuration)
        {
            _configuration = configuration;

            var autoMapperConfiguration = new MapperConfiguration(config =>
            {
                //config.CreateMap<Entity1, Entity2>()
            });

            _mapper = autoMapperConfiguration.CreateMapper();
        }

        public async Task Run()
        {
            foreach (var dataSource in _configuration.Sources)
            {
                await Synchronize(dataSource);
            }
        }

        private async Task Synchronize(DataSource source)
        {
            Task.Delay(1000);
        }
    }
}