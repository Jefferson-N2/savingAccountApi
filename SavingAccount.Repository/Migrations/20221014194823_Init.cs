using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SavingAccount.Repository.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID_CLIENT = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CEATION_DATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID_CLIENT);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    ACCOUNT_NUMBER = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ID_ACCOUNT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ACCOUNT_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_CLIENT = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.ACCOUNT_NUMBER);
                    table.ForeignKey(
                        name: "FK_Account_Client_ID_CLIENT",
                        column: x => x.ID_CLIENT,
                        principalTable: "Client",
                        principalColumn: "ID_CLIENT",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Balance",
                columns: table => new
                {
                    ID_Balance = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_CLIENT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ACCOUNT_NUMBER = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Month = table.Column<int>(type: "int", nullable: false),
                    DEBIT_VALUE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CREDIT_VALUE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TOTAL_VALUE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CLIENTID_CLIENT = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balance", x => x.ID_Balance);
                    table.ForeignKey(
                        name: "FK_Balance_Account_ACCOUNT_NUMBER",
                        column: x => x.ACCOUNT_NUMBER,
                        principalTable: "Account",
                        principalColumn: "ACCOUNT_NUMBER",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Balance_Client_CLIENTID_CLIENT",
                        column: x => x.CLIENTID_CLIENT,
                        principalTable: "Client",
                        principalColumn: "ID_CLIENT",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_ID_CLIENT",
                table: "Account",
                column: "ID_CLIENT");

            migrationBuilder.CreateIndex(
                name: "IX_Balance_ACCOUNT_NUMBER",
                table: "Balance",
                column: "ACCOUNT_NUMBER");

            migrationBuilder.CreateIndex(
                name: "IX_Balance_CLIENTID_CLIENT",
                table: "Balance",
                column: "CLIENTID_CLIENT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Balance");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
