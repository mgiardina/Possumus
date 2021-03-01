using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Possumus.Infrastructure.Migrations
{
    public partial class schemaupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Desde",
                table: "Empleos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Empresa",
                table: "Empleos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Hasta",
                table: "Empleos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Candidatos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Candidatos",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Candidatos",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Email", "FechaNacimiento", "Telefono" },
                values: new object[] { "mgiardina@gmail.com", new DateTime(1982, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "+5492317517703" });

            migrationBuilder.InsertData(
                table: "Candidatos",
                columns: new[] { "Id", "Apellido", "Email", "FechaNacimiento", "Nombre", "Telefono" },
                values: new object[] { 2L, "Perez", "juan@gmail.com", new DateTime(1980, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan", "+5492317515544" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Candidatos",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DropColumn(
                name: "Desde",
                table: "Empleos");

            migrationBuilder.DropColumn(
                name: "Empresa",
                table: "Empleos");

            migrationBuilder.DropColumn(
                name: "Hasta",
                table: "Empleos");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Candidatos");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Candidatos");

            migrationBuilder.UpdateData(
                table: "Candidatos",
                keyColumn: "Id",
                keyValue: 1L,
                column: "FechaNacimiento",
                value: new DateTime(2021, 2, 28, 23, 49, 27, 475, DateTimeKind.Local).AddTicks(6682));
        }
    }
}
