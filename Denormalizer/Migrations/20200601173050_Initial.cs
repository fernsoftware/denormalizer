using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Denormalizer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatabaseId = table.Column<long>(nullable: false),
                    CUAccountID = table.Column<int>(nullable: false),
                    CustomerID = table.Column<int>(nullable: false),
                    CULoanPartID = table.Column<int>(nullable: true),
                    BranchID = table.Column<int>(nullable: false),
                    AccountNumber = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    CurrencyID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    ProductTypeID = table.Column<int>(nullable: false),
                    TermDeposit = table.Column<bool>(nullable: false),
                    SavingsType = table.Column<int>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    NumberOfTransactions = table.Column<int>(nullable: false),
                    BalanceDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    NameAddress = table.Column<string>(nullable: true),
                    ProductDescription = table.Column<string>(nullable: true),
                    OrderItem = table.Column<string>(nullable: true),
                    OrderItem1 = table.Column<string>(nullable: true),
                    OrderItem2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAccounts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAccounts");
        }
    }
}
