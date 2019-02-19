using Microsoft.EntityFrameworkCore.Migrations;

namespace SMSBreeze.Web.Migrations
{
    public partial class @fixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "SmsTransactions",
                newName: "AmountPaid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AmountPaid",
                table: "SmsTransactions",
                newName: "Amount");
        }
    }
}
