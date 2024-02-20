using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teatro.Data.Migrations
{
    public partial class CorrecionModelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asientos_DetalleSalas_DetalleSalaSalaId_DetalleSalaObraId",
                table: "Asientos");

            migrationBuilder.DropTable(
                name: "DetalleSalas");

            migrationBuilder.DropTable(
                name: "ReservaSalas");

            migrationBuilder.DropTable(
                name: "Salas");

            migrationBuilder.RenameColumn(
                name: "DetalleSalaSalaId",
                table: "Asientos",
                newName: "DetalleReservaReservaId");

            migrationBuilder.RenameColumn(
                name: "DetalleSalaObraId",
                table: "Asientos",
                newName: "DetalleReservaObraId");

            migrationBuilder.RenameIndex(
                name: "IX_Asientos_DetalleSalaSalaId_DetalleSalaObraId",
                table: "Asientos",
                newName: "IX_Asientos_DetalleReservaReservaId_DetalleReservaObraId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asientos_DetalleReservas_DetalleReservaReservaId_DetalleReservaObraId",
                table: "Asientos");

            migrationBuilder.DropTable(
                name: "DetalleReservas");

            migrationBuilder.RenameColumn(
                name: "DetalleReservaReservaId",
                table: "Asientos",
                newName: "DetalleSalaSalaId");

            migrationBuilder.RenameColumn(
                name: "DetalleReservaObraId",
                table: "Asientos",
                newName: "DetalleSalaObraId");

            migrationBuilder.RenameIndex(
                name: "IX_Asientos_DetalleReservaReservaId_DetalleReservaObraId",
                table: "Asientos",
                newName: "IX_Asientos_DetalleSalaSalaId_DetalleSalaObraId");

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    SalaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreSala = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.SalaId);
                });

            migrationBuilder.CreateTable(
                name: "DetalleSalas",
                columns: table => new
                {
                    SalaId = table.Column<int>(type: "int", nullable: false),
                    ObraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleSalas", x => new { x.SalaId, x.ObraId });
                    table.ForeignKey(
                        name: "FK_DetalleSalas_Obras_ObraId",
                        column: x => x.ObraId,
                        principalTable: "Obras",
                        principalColumn: "ObraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleSalas_Salas_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Salas",
                        principalColumn: "SalaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservaSalas",
                columns: table => new
                {
                    SalaId = table.Column<int>(type: "int", nullable: false),
                    ReservaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaSalas", x => new { x.SalaId, x.ReservaId });
                    table.ForeignKey(
                        name: "FK_ReservaSalas_Reservas_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reservas",
                        principalColumn: "ReservaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservaSalas_Salas_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Salas",
                        principalColumn: "SalaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleSalas_ObraId",
                table: "DetalleSalas",
                column: "ObraId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaSalas_ReservaId",
                table: "ReservaSalas",
                column: "ReservaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asientos_DetalleSalas_DetalleSalaSalaId_DetalleSalaObraId",
                table: "Asientos",
                columns: new[] { "DetalleSalaSalaId", "DetalleSalaObraId" },
                principalTable: "DetalleSalas",
                principalColumns: new[] { "SalaId", "ObraId" });
        }
    }
}
