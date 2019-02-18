using Microsoft.EntityFrameworkCore.Migrations;

namespace SMSBreeze.Web.Data.Migrations
{
    public partial class Clearup3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SmsTransaction_Customers_CustomerId",
                table: "SmsTransaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SmsTransaction",
                table: "SmsTransaction");

            migrationBuilder.DropColumn(
                name: "AmountPaid",
                table: "SmsTransaction");

            migrationBuilder.DropColumn(
                name: "ReferenceNumber",
                table: "SmsTransaction");

            migrationBuilder.RenameTable(
                name: "SmsTransaction",
                newName: "SmsTransactions");

            migrationBuilder.RenameIndex(
                name: "IX_SmsTransaction_CustomerId",
                table: "SmsTransactions",
                newName: "IX_SmsTransactions_CustomerId");

            migrationBuilder.AlterColumn<string>(
                name: "GroupName",
                table: "Groups",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Contacts",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Contacts",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SmsTransactions",
                table: "SmsTransactions",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SmsTransactions_Customers_CustomerId",
                table: "SmsTransactions",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SmsTransactions_Customers_CustomerId",
                table: "SmsTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SmsTransactions",
                table: "SmsTransactions");

            migrationBuilder.RenameTable(
                name: "SmsTransactions",
                newName: "SmsTransaction");

            migrationBuilder.RenameIndex(
                name: "IX_SmsTransactions_CustomerId",
                table: "SmsTransaction",
                newName: "IX_SmsTransaction_CustomerId");

            migrationBuilder.AlterColumn<string>(
                name: "GroupName",
                table: "Groups",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Contacts",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Contacts",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountPaid",
                table: "SmsTransaction",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceNumber",
                table: "SmsTransaction",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SmsTransaction",
                table: "SmsTransaction",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SmsTransaction_Customers_CustomerId",
                table: "SmsTransaction",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
