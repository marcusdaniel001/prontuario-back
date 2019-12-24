using Microsoft.EntityFrameworkCore.Migrations;

namespace Prontuario.Infra.Data.Migrations
{
    public partial class addingforeignkeyusuariointelefone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Telefone_TelefoneId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_TelefoneId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "TelefoneId",
                table: "Usuario");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Telefone",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_UsuarioId",
                table: "Telefone",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Telefone_Usuario_UsuarioId",
                table: "Telefone",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefone_Usuario_UsuarioId",
                table: "Telefone");

            migrationBuilder.DropIndex(
                name: "IX_Telefone_UsuarioId",
                table: "Telefone");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Telefone");

            migrationBuilder.AddColumn<int>(
                name: "TelefoneId",
                table: "Usuario",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_TelefoneId",
                table: "Usuario",
                column: "TelefoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Telefone_TelefoneId",
                table: "Usuario",
                column: "TelefoneId",
                principalTable: "Telefone",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
