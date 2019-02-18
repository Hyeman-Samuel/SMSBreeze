using Microsoft.EntityFrameworkCore.Migrations;

namespace SMSBreeze.Web.Migrations
{
    public partial class addedReferenceToSmsTransacrionModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "SmsTransactions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reference",
                table: "SmsTransactions");
        }
    }
}
