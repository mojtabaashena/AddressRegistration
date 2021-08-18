using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AddressRegistration.Data.Migrations
{
    public partial class CustomersAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Customerid",
                table: "Product",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descrip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Customerid",
                table: "Product",
                column: "Customerid");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Customer_Customerid",
                table: "Product",
                column: "Customerid",
                principalTable: "Customer",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Customer_Customerid",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Product_Customerid",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Customerid",
                table: "Product");
        }
    }
}
