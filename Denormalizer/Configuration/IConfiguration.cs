using System.Collections.Generic;

using Denormalizer.Data;

namespace Denormalizer.Configuration
{
    public interface IConfiguration
    {
        IEnumerable<DataSource> Sources { get; set; }

        DataSource Destination { get; set; }
    }
}