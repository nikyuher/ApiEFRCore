using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teatro.Data.Migrations
{
    public partial class probando5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ObraId",
                table: "Asientos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Asientos_ObraId",
                table: "Asientos",
                column: "ObraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asientos_Obras_ObraId",
                table: "Asientos",
                column: "ObraId",
                principalTable: "Obras",
                principalColumn: "ObraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asientos_Obras_ObraId",
                table: "Asientos");

            migrationBuilder.DropIndex(
                name: "IX_Asientos_ObraId",
                table: "Asientos");

            migrationBuilder.DropColumn(
                name: "ObraId",
                table: "Asientos");
        }
    }
}
