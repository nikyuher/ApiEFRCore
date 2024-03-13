using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teatro.Data.Migrations
{
    public partial class AddDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AsientoId",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaHora",
                table: "Obras",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_AsientoId",
                table: "Reservas",
                column: "AsientoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Asientos_AsientoId",
                table: "Reservas",
                column: "AsientoId",
                principalTable: "Asientos",
                principalColumn: "AsientoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Asientos_AsientoId",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_AsientoId",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "AsientoId",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "FechaHora",
                table: "Obras");
        }
    }
}
