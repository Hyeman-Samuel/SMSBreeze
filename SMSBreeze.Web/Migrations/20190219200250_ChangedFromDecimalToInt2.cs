using Microsoft.EntityFrameworkCore.Migrations;

namespace SMSBreeze.Web.Migrations
{
    public partial class ChangedFromDecimalToInt2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SmsBalance",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "SmsBalance",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
