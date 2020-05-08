using System.Collections.Generic;

namespace Denormalizer.Configuration
{
    internal sealed class AppConfiguration : IConfiguration
    {
        public IEnumerable<DataSource> Sources { get; set; }

        public DataSource Destination { get; set; }
    }
}