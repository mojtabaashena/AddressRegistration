using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AddressRegistration.Data.Migrations
{
    public partial class CustomerProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Customer_Customerid",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_Customerid",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Customerid",
                table: "Product");

            migrationBuilder.CreateTable(
                name: "CustomerProduct",
                columns: table => new
                {
                    Customersid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Productsid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerProduct", x => new { x.Customersid, x.Productsid });
                    table.ForeignKey(
                        name: "FK_CustomerProduct_Customer_Customersid",
                        column: x => x.Customersid,
                        principalTable: "Customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerProduct_Product_Productsid",
                        column: x => x.Productsid,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProduct_Productsid",
                table: "CustomerProduct",
                column: "Productsid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerProduct");

            migrationBuilder.AddColumn<Guid>(
                name: "Customerid",
                table: "Product",
                type: "uniqueidentifier",
                nullable: true);

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
    }
}
