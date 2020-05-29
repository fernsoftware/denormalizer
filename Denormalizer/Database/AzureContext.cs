using Microsoft.EntityFrameworkCore;

using Denormalizer.Entities;

namespace Denormalizer.Database
{
    public class AzureContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<CustomerAccount> CustomerAccounts { get; set; }

        public AzureContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(_connectionString);
        }
    }
}