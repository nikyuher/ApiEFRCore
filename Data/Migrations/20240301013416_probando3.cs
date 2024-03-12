using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teatro.Data.Migrations
{
    public partial class probando3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObraAsientos");

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

            migrationBuilder.CreateTable(
                name: "ObraAsientos",
                columns: table => new
                {
                    ObraAsientoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AsientoId = table.Column<int>(type: "int", nullable: false),
                    ObraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObraAsientos", x => x.ObraAsientoId);
                    table.ForeignKey(
                        name: "FK_ObraAsientos_Asientos_AsientoId",
                        column: x => x.AsientoId,
                        principalTable: "Asientos",
                        principalColumn: "AsientoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObraAsientos_Obras_ObraId",
                        column: x => x.ObraId,
                        principalTable: "Obras",
                        principalColumn: "ObraId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObraAsientos_AsientoId",
                table: "ObraAsientos",
                column: "AsientoId");

            migrationBuilder.CreateIndex(
                name: "IX_ObraAsientos_ObraId",
                table: "ObraAsientos",
                column: "ObraId");
        }
    }
}
