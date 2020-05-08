using System.Collections.Generic;

using Denormalizer.Data;

namespace Denormalizer.Configuration
{
    internal sealed class AppConfiguration : IConfiguration
    {
        public IEnumerable<DataSource> Sources { get; set; }

        public DataSource Destination { get; set; }
    }
}