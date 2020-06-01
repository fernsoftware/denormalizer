using Denormalizer.Configuration;

namespace Denormalizer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var app = new App(AppConfiguration.Create());
            app.Run();
        }
    }
}