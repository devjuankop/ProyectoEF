using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoEF.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaID", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("97edcd52-e5c2-44ce-b112-16c4bb570535"), null, "Actividades personales", 50 });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaID", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("97edcd52-e5c2-44ce-b112-16c4bb570538"), null, "Actividades pendientes", 30 });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaID", "CategoriaID", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[] { new Guid("97edcd52-e5c2-44ce-b112-16c4bb570530"), new Guid("97edcd52-e5c2-44ce-b112-16c4bb570535"), null, new DateTime(2022, 10, 8, 16, 12, 5, 467, DateTimeKind.Local).AddTicks(1319), 0, "Terminar de ver pelicula en netflix" });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaID", "CategoriaID", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[] { new Guid("97edcd52-e5c2-44ce-b112-16c4bb570533"), new Guid("97edcd52-e5c2-44ce-b112-16c4bb570538"), null, new DateTime(2022, 10, 8, 16, 12, 5, 467, DateTimeKind.Local).AddTicks(1304), 1, "Pago de servicios publicos" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaID",
                keyValue: new Guid("97edcd52-e5c2-44ce-b112-16c4bb570530"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaID",
                keyValue: new Guid("97edcd52-e5c2-44ce-b112-16c4bb570533"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaID",
                keyValue: new Guid("97edcd52-e5c2-44ce-b112-16c4bb570535"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaID",
                keyValue: new Guid("97edcd52-e5c2-44ce-b112-16c4bb570538"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
