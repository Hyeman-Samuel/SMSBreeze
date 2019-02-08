using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SMSBreeze.Web.Data.Migrations
{
    public partial class ApplicationUserupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_AspNetUsers_CustomerId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_SendReports_AspNetUsers_CustomerId",
                table: "SendReports");

            migrationBuilder.DropForeignKey(
                name: "FK_SmsDetails_SendReports_SentReportID",
                table: "SmsDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SmsTransaction_AspNetUsers_CustomerId",
                table: "SmsTransaction");

            migrationBuilder.DropIndex(
                name: "IX_GroupAssigns_ContactID",
                table: "GroupAssigns");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Contacts",
                newName: "CustomerID");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_CustomerId",
                table: "Contacts",
                newName: "IX_Contacts_CustomerID");

            migrationBuilder.RenameColumn(
                name: "SmsBalance",
                table: "AspNetUsers",
                newName: "CustomerId");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "SmsTransaction",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SentReportID",
                table: "SmsDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "SendReports",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerID",
                table: "Contacts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    SmsBalance = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupAssigns_ContactID",
                table: "GroupAssigns",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CustomerId",
                table: "AspNetUsers",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Customers_CustomerId",
                table: "AspNetUsers",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Customers_CustomerID",
                table: "Contacts",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SendReports_Customers_CustomerId",
                table: "SendReports",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SmsDetails_SendReports_SentReportID",
                table: "SmsDetails",
                column: "SentReportID",
                principalTable: "SendReports",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SmsTransaction_Customers_CustomerId",
                table: "SmsTransaction",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Customers_CustomerId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Customers_CustomerID",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_SendReports_Customers_CustomerId",
                table: "SendReports");

            migrationBuilder.DropForeignKey(
                name: "FK_SmsDetails_SendReports_SentReportID",
                table: "SmsDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SmsTransaction_Customers_CustomerId",
                table: "SmsTransaction");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_GroupAssigns_ContactID",
                table: "GroupAssigns");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CustomerId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Contacts",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_CustomerID",
                table: "Contacts",
                newName: "IX_Contacts_CustomerId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "AspNetUsers",
                newName: "SmsBalance");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "SmsTransaction",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "SentReportID",
                table: "SmsDetails",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "SendReports",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Contacts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_GroupAssigns_ContactID",
                table: "GroupAssigns",
                column: "ContactID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_AspNetUsers_CustomerId",
                table: "Contacts",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SendReports_AspNetUsers_CustomerId",
                table: "SendReports",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SmsDetails_SendReports_SentReportID",
                table: "SmsDetails",
                column: "SentReportID",
                principalTable: "SendReports",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SmsTransaction_AspNetUsers_CustomerId",
                table: "SmsTransaction",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
