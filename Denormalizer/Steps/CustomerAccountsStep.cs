using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using Denormalizer.Database;
using Denormalizer.Factories;

namespace Denormalizer.Steps
{
    public sealed class CustomerAccountsStep : IStep
    {
        private readonly ICustomerAccountFactory _factory;

        private readonly DateTime _valueDate;
        private readonly int _currencyId;

        public CustomerAccountsStep(
            DateTime valueDate,
            int currencyId)
        {
            _valueDate = valueDate;
            _currencyId = currencyId;

            _factory = new CustomerAccountFactory();
        }

        public async Task Execute(AbacusContext source, AzureContext destination)
        {
            var sourceQuery = $@"EXEC dbo.[CUReportCUAccounts]
                @ValueDate = '{_valueDate}',
                @CurrencyID = '{_currencyId}'";

            using var command = source.Database.GetDbConnection().CreateCommand();

            command.CommandText = sourceQuery;
            command.CommandType = CommandType.StoredProcedure;

            var parameter = new SqlParameter("@ValueDate", _valueDate);

            using var result = command.ExecuteReader();

            var sourceEntities = _factory
                .CreateMany(result)
                .AsEnumerable();
        }
    }
}