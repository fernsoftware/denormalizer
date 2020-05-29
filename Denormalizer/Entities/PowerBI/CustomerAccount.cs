namespace Denormalizer.Entities.PowerBI
{
    public sealed class CustomerAccount : BaseEntity
    {
        public int CUAccountID { get; set; }

        public int CustomerID { get; set; }

        public int? CULoanPartID { get; set; }

        public int BranchID { get; set; }

        public string AccountNumber { get; set; }

        public string Name { get; set; }

        public int CurrencyID { get; set; }

        public int ProductID { get; set; }

        public int ProductTypeID { get; set; }

        public int TermDeposit { get; set; }

        public int SavingsType { get; set; }

        public decimal Balance { get; set; }
    }
}