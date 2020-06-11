using System;
using System.Data;
using System.Linq;

using Microsoft.EntityFrameworkCore;

using Denormalizer.Database;
using Denormalizer.Factories;
using Denormalizer.Logging;
using Denormalizer.Steps.Parameters;

namespace Denormalizer.Steps
{
    public sealed class CustomerAccountsStep : BaseStep
    {
        private readonly CustomerAccountsParameters _parameters;
        private readonly ICustomerAccountFactory _factory;

        public CustomerAccountsStep(ILogger logger, CustomerAccountsParameters parameters)
            : base(logger)
        {
            _parameters = parameters;
            _factory = new CustomerAccountFactory();
        }

        public override void Execute(int databaseId, AbacusContext source, AzureContext destination)
        {
            Logger.Log("Starting CustomerAccounts synchronization");

            var sourceQuery = $@"EXEC dbo.[CUReportCUAccounts]
                @ValueDate = '{_parameters.ValueDate}',
                @CurrencyID = '{_parameters.CurrencyId}',
                @BranchID = '{_parameters.BranchId}',
                @AccNoStart = '{_parameters.AccNoStart}',
                @AccNoEnd = '{_parameters.AccNoEnd}',
                @ActiveState = '{_parameters.ActiveState}',
                @GroupIDs = '{_parameters.GroupIDs}',
                @ProductTypes = '{_parameters.ProductTypes}',
                @ProductID = '{_parameters.ProductID}',
                @LoanStatus = '{_parameters.LoanStatus}',
                @LoanSourceOfFundsID = '{_parameters.LoanSourceOfFundsID}',
                @LoanReasonID = '{_parameters.LoanReasonID}',
                @DistrictCodeID = '{_parameters.DistrictCodeID}',
                @PortfolioID = '{_parameters.PortfolioID}',
                @CustomerTypes = '{_parameters.CustomerTypes}',
                @RefinancedLoans = '{_parameters.RefinancedLoans}',
                @RefinanceStart = '{_parameters.RefinanceStart}',
                @RefinanceEnd = '{_parameters.RefinanceEnd}',
                @OrderBy = '{_parameters.OrderBy}',
                @NumResults = '{_parameters.NumResults}',
                @CheckDigit = '{_parameters.CheckDigit}'";

            try
            {
                using var command = source.Database.GetDbConnection().CreateCommand();

                command.CommandText = sourceQuery;
                command.CommandType = CommandType.Text;

                command.Connection.Open();

                using var result = command.ExecuteReader();

                var sourceEntities = _factory
                    .CreateMany(result)
                    .AsEnumerable();

                var destinationEntities = destination.CustomerAccounts
                    .Where(x => x.DatabaseId == databaseId);

                var entitiesToDelete = destinationEntities.Except(sourceEntities);
                var entitiesToAdd = sourceEntities.Except(destinationEntities);
                var entitiesToSync = sourceEntities
                    .Except(entitiesToDelete)
                    .Except(entitiesToAdd);

                foreach (var entity in entitiesToDelete)
                {
                    destination.Entry(entity).State = EntityState.Deleted;
                }

                destination.SaveChanges();

                foreach (var entity in entitiesToAdd)
                {
                    destination.Add(entity);
                }

                destination.SaveChanges();

                // Sync
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }
    }
}