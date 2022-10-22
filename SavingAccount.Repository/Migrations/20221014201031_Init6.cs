using Microsoft.EntityFrameworkCore.Migrations;

namespace SavingAccount.Repository.Migrations
{
    public partial class Init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Balance_Client_CLIENTID_CLIENT",
                table: "Balance");

            migrationBuilder.DropIndex(
                name: "IX_Balance_CLIENTID_CLIENT",
                table: "Balance");

            migrationBuilder.DropColumn(
                name: "CLIENTID_CLIENT",
                table: "Balance");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CLIENTID_CLIENT",
                table: "Balance",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Balance_CLIENTID_CLIENT",
                table: "Balance",
                column: "CLIENTID_CLIENT");

            migrationBuilder.AddForeignKey(
                name: "FK_Balance_Client_CLIENTID_CLIENT",
                table: "Balance",
                column: "CLIENTID_CLIENT",
                principalTable: "Client",
                principalColumn: "ID_CLIENT",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
