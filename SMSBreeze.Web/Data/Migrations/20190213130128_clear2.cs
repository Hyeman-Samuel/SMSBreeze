using Microsoft.EntityFrameworkCore.Migrations;

namespace SMSBreeze.Web.Data.Migrations
{
    public partial class clear2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Groups",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CustomerId",
                table: "Groups",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Customers_CustomerId",
                table: "Groups",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Customers_CustomerId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_CustomerId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Groups");
        }
    }
}
