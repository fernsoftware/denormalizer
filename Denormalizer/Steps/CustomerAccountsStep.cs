using System.Data;
using System.Linq;

using Microsoft.EntityFrameworkCore;

using Denormalizer.Database;
using Denormalizer.Factories;
using Denormalizer.Steps.Parameters;

namespace Denormalizer.Steps
{
    public sealed class CustomerAccountsStep : IStep
    {
        private readonly CustomerAccountsParameters _parameters;
        private readonly ICustomerAccountFactory _factory;

        public CustomerAccountsStep(CustomerAccountsParameters parameters)
        {
            _parameters = parameters;
            _factory = new CustomerAccountFactory();
        }

        public void Execute(int databaseId, AbacusContext source, AzureContext destination)
        {
            var sourceQuery = $@"EXEC dbo.[CUReportCUAccounts]
                @ValueDate = '{_parameters.ValueDate}',
                @CurrencyID = '{_parameters.CurrencyId}'
                @BranchID = '{_parameters.BranchId}'
                @AccNoStart = '{_parameters.AccNoStart}'
                @AccNoEnd = '{_parameters.AccNoEnd}'
                @ActiveState = '{_parameters.ActiveState}'
                @GroupIDs = '{_parameters.GroupIDs}'
                @ProductTypes = '{_parameters.ProductTypes}'
                @ProductID = '{_parameters.ProductID}'
                @LoanStatus = '{_parameters.LoanStatus}'
                @LoanSourceOfFundsID = '{_parameters.LoanSourceOfFundsID}'
                @LoanReasonID = '{_parameters.LoanReasonID}'
                @DistrictCodeID = '{_parameters.DistrictCodeID}'
                @PortfolioID = '{_parameters.PortfolioID}'
                @CustomerTypes = '{_parameters.CustomerTypes}'
                @RefinancedLoans = '{_parameters.RefinancedLoans}'
                @RefinanceStart = '{_parameters.RefinanceStart}'
                @RefinanceEnd = '{_parameters.RefinanceEnd}'
                @OrderBy = '{_parameters.OrderBy}'
                @NumResults = '{_parameters.NumResults}'
                @CheckDigit = '{_parameters.CheckDigit}'";

            using var command = source.Database.GetDbConnection().CreateCommand();

            command.CommandText = sourceQuery;
            command.CommandType = CommandType.StoredProcedure;

            using var result = command.ExecuteReader();

            var sourceEntities = _factory
                .CreateMany(result)
                .AsEnumerable();

            foreach (var entity in sourceEntities)
            {
                entity.DatabaseId = databaseId;

                destination.CustomerAccounts.Add(entity);
            }

            destination.SaveChanges();
        }
    }
}