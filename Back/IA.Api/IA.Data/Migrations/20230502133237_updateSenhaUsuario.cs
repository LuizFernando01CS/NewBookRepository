using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IA.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateSenhaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Usuario");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Usuario",
                type: "varchar(500)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Usuario");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Usuario",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
