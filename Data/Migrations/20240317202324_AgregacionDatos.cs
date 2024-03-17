using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teatro.Data.Migrations
{
    public partial class AgregacionDatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Obras",
                columns: new[] { "ObraId", "Descripción", "FechaHora", "Genero", "Imagen", "PrecioEntrada", "Título" },
                values: new object[,]
                {
                    { 1, "Descripción de La Extraña Pareja", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comedia", null, 10m, "La Extraña Pareja" },
                    { 2, "Descripción de La Comedia de las Equivocaciones", new DateTime(2022, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comedia", null, 10m, "La Comedia de las Equivocaciones" },
                    { 3, "Descripción de Un Tranvía llamado Deseo", new DateTime(2022, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comedia", null, 10m, "Un Tranvía llamado Deseo" },
                    { 4, "Descripción de Drácula", new DateTime(2022, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Terror", null, 15m, "Drácula" },
                    { 5, "Descripción de El Fantasma de Gantersville", new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Terror", null, 15m, "El Fantasma de Gantersville" },
                    { 6, "Descripción de La Mujer de Negro", new DateTime(2022, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Terror", null, 15m, "La Mujer de Negro" },
                    { 7, "Descripción de Edipo Rey", new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Drama", null, 20m, "Edipo Rey" },
                    { 8, "Descripción de La Casa de Bernarda", new DateTime(2022, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Drama", null, 20m, "La Casa de Bernarda" },
                    { 9, "Descripción de Muerte de un Viajero", new DateTime(2022, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Drama", null, 20m, "Muerte de un Viajero" },
                    { 10, "Descripción de Hamlet", new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tragedia", null, 25m, "Hamlet" },
                    { 11, "Descripción de Macbeth", new DateTime(2022, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tragedia", null, 25m, "Macbeth" },
                    { 12, "Descripción de Romeo y Julieta", new DateTime(2022, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tragedia", null, 25m, "Romeo y Julieta" },
                    { 13, "Descripción de El Fantasma de la Ópera", new DateTime(2022, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Musical", null, 30m, "El Fantasma de la Ópera" },
                    { 14, "Descripción de El Avaro", new DateTime(2022, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Musical", null, 30m, "El Avaro" },
                    { 15, "Descripción de Frankenstein", new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Musical", null, 30m, "Frankenstein" },
                    { 16, "Descripción de El Fantasma de la Opera", new DateTime(2022, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Terror", null, 15m, "El Fantasma de la Opera" },
                    { 17, "Descripción de El Rey Lear", new DateTime(2022, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Terror", null, 15m, "El Rey Lear" },
                    { 18, "Descripción de La Noche de Reyes", new DateTime(2022, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Terror", null, 15m, "La Noche de Reyes" },
                    { 19, "Descripción de El Inspector", new DateTime(2022, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Terror", null, 15m, "El Inspector" },
                    { 20, "Descripción de La Comedia de las Equivocaciones", new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Terror", null, 15m, "La Comedia de las Equivocaciones" },
                    { 21, "Descripción de La Caída de Bernarda", new DateTime(2022, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Terror", null, 15m, "La Caída de Bernarda" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Obras",
                keyColumn: "ObraId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Obras",
                keyColumn: "ObraId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Obras",
                keyColumn: "ObraId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Obras",
                keyColumn: "ObraId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Obras",
                keyColumn: "ObraId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Obras",
                keyColumn: "ObraId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Obras",
                keyColumn: "ObraId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Obras",
                keyColumn: "ObraId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Obras",
                keyColumn: "ObraId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Obras",
                keyColumn: "ObraId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Obras",
                keyColumn: "ObraId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Obras",
                keyColumn: "ObraId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Obras",
                keyColumn: "ObraId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Obras",
                keyColumn: "ObraId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Obras",
                keyColumn: "ObraId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Obras",
                keyColumn: "ObraId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Obras",
                keyColumn: "ObraId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Obras",
                keyColumn: "ObraId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Obras",
                keyColumn: "ObraId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Obras",
                keyColumn: "ObraId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Obras",
                keyColumn: "ObraId",
                keyValue: 21);
        }
    }
}
