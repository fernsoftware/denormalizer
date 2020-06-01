using System;

namespace Denormalizer.Steps.Parameters
{
    public sealed class CustomerAccountsParameters
    {
        public CustomerAccountsParameters(DateTime valueDate)
        {
            ValueDate = valueDate;

            CurrencyId = 0;
            BranchId = 0;
            AccNoStart = string.Empty;
            AccNoEnd = string.Empty;
            ActiveState = 2;
            GroupIDs = "0";
            ProductTypes = 7;
            ProductID = 0;
            LoanStatus = 60;
            LoanSourceOfFundsID = 0;
            LoanReasonID = 0;
            DistrictCodeID = 0;
            PortfolioID = 0;
            CustomerTypes = 15;
            RefinancedLoans = false;
            OrderBy = 1;
            NumResults = long.MaxValue;
        }

        public DateTime ValueDate { get; set; }
        public int CurrencyId { get; set; }
        public int BranchId { get; set; }
        public string AccNoStart { get; set; }
        public string AccNoEnd { get; set; }
        public int ActiveState { get; set; }
        public string GroupIDs { get; set; }
        public int ProductTypes { get; set; }
        public int ProductID { get; set; }
        public int LoanStatus { get; set; }
        public int LoanSourceOfFundsID { get; set; }
        public int LoanReasonID { get; set; }
        public int DistrictCodeID { get; set; }
        public int PortfolioID { get; set; }
        public int CustomerTypes { get; set; }
        public bool RefinancedLoans { get; set; }
        public DateTime? RefinanceStart { get; set; }
        public DateTime? RefinanceEnd { get; set; }
        public int OrderBy { get; set; }
        public long NumResults { get; set; }
        public int CheckDigit { get; set; }
    }
}