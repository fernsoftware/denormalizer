using Denormalizer.Entities.PowerBI;

using Microsoft.EntityFrameworkCore;

namespace Denormalizer.Database
{
    public class AbacusContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<CustomerAccount> CustomerAccounts { get; set; }

        public AbacusContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);

            builder.UseSqlServer(_connectionString);
        }
    }
}