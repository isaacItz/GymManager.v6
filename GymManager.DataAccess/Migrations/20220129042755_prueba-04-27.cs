using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymManager.DataAccess.Migrations
{
    public partial class prueba0427 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleRows_Sales_saleId",
                table: "SaleRows");

            migrationBuilder.RenameColumn(
                name: "saleId",
                table: "SaleRows",
                newName: "SaleId");

            migrationBuilder.RenameIndex(
                name: "IX_SaleRows_saleId",
                table: "SaleRows",
                newName: "IX_SaleRows_SaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleRows_Sales_SaleId",
                table: "SaleRows",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleRows_Sales_SaleId",
                table: "SaleRows");

            migrationBuilder.RenameColumn(
                name: "SaleId",
                table: "SaleRows",
                newName: "saleId");

            migrationBuilder.RenameIndex(
                name: "IX_SaleRows_SaleId",
                table: "SaleRows",
                newName: "IX_SaleRows_saleId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleRows_Sales_saleId",
                table: "SaleRows",
                column: "saleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
