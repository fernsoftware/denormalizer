using System;
using System.Collections.Generic;
using System.IO;

using Newtonsoft.Json;

namespace Denormalizer.Configuration
{
    internal sealed class AppConfiguration : IConfiguration
    {
        private AppConfiguration()
        { }

        public static AppConfiguration Create()
        {
            return JsonConvert.DeserializeObject<AppConfiguration>(
                File.ReadAllText(Path.Combine(GetConfigurationDirectory(), "config.json")));
        }

        public IEnumerable<DataSource> Sources { get; set; }

        public DataSource Destination { get; set; }

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