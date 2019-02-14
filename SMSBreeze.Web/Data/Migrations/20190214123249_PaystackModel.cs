using Microsoft.EntityFrameworkCore.Migrations;

namespace SMSBreeze.Web.Data.Migrations
{
    public partial class PaystackModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AmountPaid",
                table: "SmsTransaction",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceNumber",
                table: "SmsTransaction",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountPaid",
                table: "SmsTransaction");

            migrationBuilder.DropColumn(
                name: "ReferenceNumber",
                table: "SmsTransaction");
        }
    }
}
