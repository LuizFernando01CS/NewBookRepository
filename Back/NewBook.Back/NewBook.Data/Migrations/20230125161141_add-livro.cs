using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewBook.Data.Migrations
{
    /// <inheritdoc />
    public partial class addlivro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Resumo = table.Column<string>(type: "varchar(1000)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sumario = table.Column<string>(type: "varchar(1000)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LivroCompleto = table.Column<string>(type: "varchar(2000)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    TipoLivroId = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    PeloSite = table.Column<ulong>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livro");
        }
    }
}
