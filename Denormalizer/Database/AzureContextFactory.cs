using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using Denormalizer.Configuration;

namespace Denormalizer.Database
{
    public class AzureContextFactory : IDesignTimeDbContextFactory<AzureContext>
    {
        public AzureContext CreateDbContext(string[] args)
        {
            var configuration = AppConfiguration.Create();

            var builder = new DbContextOptionsBuilder<AzureContext>();

            builder.UseSqlServer(configuration.Destination.ConnectionString);

            return new AzureContext(builder.Options);
        }
    }
}