using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyDivTracker.Data.EFCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsIsa = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ticker",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IsETF = table.Column<bool>(type: "bit", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticker", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dividend",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountGBP = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    TickerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dividend", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dividend_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dividend_Ticker_TickerId",
                        column: x => x.TickerId,
                        principalTable: "Ticker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "Description", "IsIsa", "Name" },
                values: new object[] { new Guid("df1917d7-d66a-4ad6-b58a-847c99d9662f"), "S&S ISA With Vanguard", true, "Vanguard S&S ISA" });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "Description", "IsIsa", "Name" },
                values: new object[] { new Guid("ef680a27-6b09-463a-8c75-25278938101f"), "S&S ISA With Trading 212", true, "Trading 212 S&S ISA" });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "Description", "IsIsa", "Name" },
                values: new object[] { new Guid("6add380f-9aa8-489a-afa3-bea7f6f10d28"), "General Acc. with Trading 212", true, "Trading 212 General Acc." });

            migrationBuilder.CreateIndex(
                name: "IX_Dividend_AccountId",
                table: "Dividend",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Dividend_TickerId",
                table: "Dividend",
                column: "TickerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dividend");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Ticker");
        }
    }
}
