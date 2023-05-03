using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IA.Data.Migrations
{
    /// <inheritdoc />
    public partial class trocatable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InformacoesPessoais_Endereco_EnderecoId",
                table: "InformacoesPessoais");

            migrationBuilder.DropForeignKey(
                name: "FK_InformacoesPessoais_InformacoesAdicionais_InformacoesAdicion~",
                table: "InformacoesPessoais");

            migrationBuilder.DropIndex(
                name: "IX_InformacoesPessoais_EnderecoId",
                table: "InformacoesPessoais");

            migrationBuilder.DropIndex(
                name: "IX_InformacoesPessoais_InformacoesAdicionaisId",
                table: "InformacoesPessoais");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "InformacoesPessoais");

            migrationBuilder.DropColumn(
                name: "InformacoesAdicionaisId",
                table: "InformacoesPessoais");

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InformacoesAdicionaisId",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EnderecoId",
                table: "Usuario",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_InformacoesAdicionaisId",
                table: "Usuario",
                column: "InformacoesAdicionaisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Endereco_EnderecoId",
                table: "Usuario",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_InformacoesAdicionais_InformacoesAdicionaisId",
                table: "Usuario",
                column: "InformacoesAdicionaisId",
                principalTable: "InformacoesAdicionais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Endereco_EnderecoId",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_InformacoesAdicionais_InformacoesAdicionaisId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_EnderecoId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_InformacoesAdicionaisId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "InformacoesAdicionaisId",
                table: "Usuario");

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "InformacoesPessoais",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InformacoesAdicionaisId",
                table: "InformacoesPessoais",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InformacoesPessoais_EnderecoId",
                table: "InformacoesPessoais",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_InformacoesPessoais_InformacoesAdicionaisId",
                table: "InformacoesPessoais",
                column: "InformacoesAdicionaisId");

            migrationBuilder.AddForeignKey(
                name: "FK_InformacoesPessoais_Endereco_EnderecoId",
                table: "InformacoesPessoais",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InformacoesPessoais_InformacoesAdicionais_InformacoesAdicion~",
                table: "InformacoesPessoais",
                column: "InformacoesAdicionaisId",
                principalTable: "InformacoesAdicionais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
