using Microsoft.EntityFrameworkCore;

namespace Denormalizer.Database
{
    public class AzureContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("");
        }
    }
}