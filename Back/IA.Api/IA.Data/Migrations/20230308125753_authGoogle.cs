using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IA.Data.Migrations
{
    /// <inheritdoc />
    public partial class authGoogle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<ulong>(
                name: "CreateAuthGoogle",
                table: "Usuario",
                type: "bit",
                nullable: false,
                defaultValue: 0ul);

            migrationBuilder.AddColumn<string>(
                name: "FirebaseId",
                table: "Usuario",
                type: "varchar(50)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "Usuario",
                type: "varchar(1000)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "MetodoAcesso",
                table: "Usuario",
                type: "varchar(50)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ProvedorId",
                table: "Usuario",
                type: "varchar(50)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimoAcesso",
                table: "Usuario",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));      
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livro");

            migrationBuilder.DropColumn(
                name: "CreateAuthGoogle",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "FirebaseId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "MetodoAcesso",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "ProvedorId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "UltimoAcesso",
                table: "Usuario");
        }
    }
}
