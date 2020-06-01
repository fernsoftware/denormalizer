using Microsoft.EntityFrameworkCore;

using Denormalizer.Entities;

namespace Denormalizer.Database
{
    public class AzureContext : DbContext
    {
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }

        public AzureContext(DbContextOptions options)
            : base(options)
        { }
    }
}