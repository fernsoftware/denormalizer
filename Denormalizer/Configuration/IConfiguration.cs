using System.Collections.Generic;

namespace Denormalizer.Configuration
{
    public interface IConfiguration
    {
        IEnumerable<DataSource> Sources { get; set; }

        DataSource Destination { get; set; }
    }
}