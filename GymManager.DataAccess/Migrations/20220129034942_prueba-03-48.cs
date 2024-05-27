using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymManager.DataAccess.Migrations
{
    public partial class prueba0348 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RefilledId",
                table: "SaleRows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SaleRows_RefilledId",
                table: "SaleRows",
                column: "RefilledId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleRows_Refills_RefilledId",
                table: "SaleRows",
                column: "RefilledId",
                principalTable: "Refills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleRows_Refills_RefilledId",
                table: "SaleRows");

            migrationBuilder.DropIndex(
                name: "IX_SaleRows_RefilledId",
                table: "SaleRows");

            migrationBuilder.DropColumn(
                name: "RefilledId",
                table: "SaleRows");
        }
    }
}
