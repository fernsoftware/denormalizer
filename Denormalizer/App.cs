using System.Threading.Tasks;

using Denormalizer.Configuration;

namespace Denormalizer
{
    internal class App
    {
        private readonly IConfiguration _configuration;

        public App(IConfiguration configuration)
        {
            _configuration = configuration;
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