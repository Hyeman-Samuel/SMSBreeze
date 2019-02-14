using Microsoft.EntityFrameworkCore.Migrations;

namespace SMSBreeze.Web.Data.Migrations
{
    public partial class clearup1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountPaid",
                table: "SmsTransaction");

            migrationBuilder.DropColumn(
                name: "personalName",
                table: "SmsTransaction");

            migrationBuilder.DropColumn(
                name: "DeliveryReport",
                table: "SmsDetails");

            migrationBuilder.DropColumn(
                name: "UnitSent",
                table: "SendReports");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeliveryReportChecked",
                table: "SmsDetails",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitsUsed",
                table: "SendReports",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeliveryReportChecked",
                table: "SmsDetails");

            migrationBuilder.DropColumn(
                name: "UnitsUsed",
                table: "SendReports");

            migrationBuilder.AddColumn<decimal>(
                name: "AmountPaid",
                table: "SmsTransaction",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "personalName",
                table: "SmsTransaction",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryReport",
                table: "SmsDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitSent",
                table: "SendReports",
                nullable: false,
                defaultValue: 0);
        }
    }
}
