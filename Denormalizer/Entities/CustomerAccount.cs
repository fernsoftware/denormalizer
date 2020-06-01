using System;

namespace Denormalizer.Entities
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

        public bool TermDeposit { get; set; }

        public int SavingsType { get; set; }

        public decimal Balance { get; set; }

        public int Age { get; set; }

        public int NumberOfTransactions { get; set; }

        public DateTime BalanceDate { get; set; }

        public int Status { get; set; }

        public bool Active { get; set; }

        public string NameAddress { get; set; }

        public string ProductDescription { get; set; }

        public string OrderItem { get; set; }

        public string OrderItem1 { get; set; }

        public string OrderItem2 { get; set; }
    }
}