using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teatro.Data.Migrations
{
    public partial class CorrecioDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asientos_DetalleReservas_DetalleReservaReservaId_DetalleReservaObraId",
                table: "Asientos");

            migrationBuilder.DropTable(
                name: "DetalleReservas");

            migrationBuilder.DropIndex(
                name: "IX_Asientos_DetalleReservaReservaId_DetalleReservaObraId",
                table: "Asientos");

            migrationBuilder.DropColumn(
                name: "DetalleReservaObraId",
                table: "Asientos");

            migrationBuilder.DropColumn(
                name: "DetalleReservaReservaId",
                table: "Asientos");

            migrationBuilder.AddColumn<int>(
                name: "AsientoId",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ObraId",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_AsientoId",
                table: "Reservas",
                column: "AsientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ObraId",
                table: "Reservas",
                column: "ObraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Asientos_AsientoId",
                table: "Reservas",
                column: "AsientoId",
                principalTable: "Asientos",
                principalColumn: "AsientoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Obras_ObraId",
                table: "Reservas",
                column: "ObraId",
                principalTable: "Obras",
                principalColumn: "ObraId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Asientos_AsientoId",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Obras_ObraId",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_AsientoId",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_ObraId",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "AsientoId",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "ObraId",
                table: "Reservas");

            migrationBuilder.AddColumn<int>(
                name: "DetalleReservaObraId",
                table: "Asientos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DetalleReservaReservaId",
                table: "Asientos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DetalleReservas",
                columns: table => new
                {
                    ReservaId = table.Column<int>(type: "int", nullable: false),
                    ObraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleReservas", x => new { x.ReservaId, x.ObraId });
                    table.ForeignKey(
                        name: "FK_DetalleReservas_Obras_ObraId",
                        column: x => x.ObraId,
                        principalTable: "Obras",
                        principalColumn: "ObraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleReservas_Reservas_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reservas",
                        principalColumn: "ReservaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asientos_DetalleReservaReservaId_DetalleReservaObraId",
                table: "Asientos",
                columns: new[] { "DetalleReservaReservaId", "DetalleReservaObraId" });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleReservas_ObraId",
                table: "DetalleReservas",
                column: "ObraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asientos_DetalleReservas_DetalleReservaReservaId_DetalleReservaObraId",
                table: "Asientos",
                columns: new[] { "DetalleReservaReservaId", "DetalleReservaObraId" },
                principalTable: "DetalleReservas",
                principalColumns: new[] { "ReservaId", "ObraId" });
        }
    }
}
