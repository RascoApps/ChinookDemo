using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chinook.DataStore.SqlServer.Migrations
{
    public partial class PersistRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerShippingRate_Customer_CustomerId",
                table: "CustomerShippingRate");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "CustomerShippingRate",
                newName: "ToCustomerCustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerShippingRate_CustomerId",
                table: "CustomerShippingRate",
                newName: "IX_CustomerShippingRate_ToCustomerCustomerId");

            migrationBuilder.AddColumn<int>(
                name: "FromCustomerCustomerId",
                table: "CustomerShippingRate",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerShippingRate_FromCustomerCustomerId",
                table: "CustomerShippingRate",
                column: "FromCustomerCustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerShippingRate_Customer_FromCustomerCustomerId",
                table: "CustomerShippingRate",
                column: "FromCustomerCustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerShippingRate_Customer_ToCustomerCustomerId",
                table: "CustomerShippingRate",
                column: "ToCustomerCustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerShippingRate_Customer_FromCustomerCustomerId",
                table: "CustomerShippingRate");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerShippingRate_Customer_ToCustomerCustomerId",
                table: "CustomerShippingRate");

            migrationBuilder.DropIndex(
                name: "IX_CustomerShippingRate_FromCustomerCustomerId",
                table: "CustomerShippingRate");

            migrationBuilder.DropColumn(
                name: "FromCustomerCustomerId",
                table: "CustomerShippingRate");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "ToCustomerCustomerId",
                table: "CustomerShippingRate",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerShippingRate_ToCustomerCustomerId",
                table: "CustomerShippingRate",
                newName: "IX_CustomerShippingRate_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerShippingRate_Customer_CustomerId",
                table: "CustomerShippingRate",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId");
        }
    }
}
