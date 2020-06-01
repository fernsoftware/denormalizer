using System;
using System.IO;

using Newtonsoft.Json;

using Denormalizer.Configuration;

namespace Denormalizer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var configuration = JsonConvert.DeserializeObject<AppConfiguration>(
                File.ReadAllText(Path.Combine(GetConfigurationDirectory(), "config.json")));

            var app = new App(configuration);

            app.Run();
        }

        private static string GetConfigurationDirectory()
        {
            var baseDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

            try
            {
                return baseDirectory.Parent.Parent.Parent.FullName;
            }
            catch
            {
                throw new DirectoryNotFoundException();
            }
        }
    }
}