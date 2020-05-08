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
            await Task.Delay(5000);
        }
    }
}