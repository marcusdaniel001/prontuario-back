using Microsoft.EntityFrameworkCore.Migrations;

namespace Prontuario.Infra.Data.Migrations
{
    public partial class localAtendimentoMedicoMedico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faturistas_Usuario_UsuarioId",
                table: "Faturistas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Usuario_UsuarioId",
                table: "Pacientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Secretarias_Usuario_UsuarioId",
                table: "Secretarias");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_Usuario_UsuarioId",
                table: "Telefones");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Enderecos_EnderecoId",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_PlanosSaude_PlanoSaudeId",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "Usuarios");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_PlanoSaudeId",
                table: "Usuarios",
                newName: "IX_Usuarios_PlanoSaudeId");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_EnderecoId",
                table: "Usuarios",
                newName: "IX_Usuarios_EnderecoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Faturistas_Usuarios_UsuarioId",
                table: "Faturistas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Usuarios_UsuarioId",
                table: "Pacientes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Secretarias_Usuarios_UsuarioId",
                table: "Secretarias",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_Usuarios_UsuarioId",
                table: "Telefones",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Enderecos_EnderecoId",
                table: "Usuarios",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_PlanosSaude_PlanoSaudeId",
                table: "Usuarios",
                column: "PlanoSaudeId",
                principalTable: "PlanosSaude",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faturistas_Usuarios_UsuarioId",
                table: "Faturistas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Usuarios_UsuarioId",
                table: "Pacientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Secretarias_Usuarios_UsuarioId",
                table: "Secretarias");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_Usuarios_UsuarioId",
                table: "Telefones");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Enderecos_EnderecoId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_PlanosSaude_PlanoSaudeId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Usuario");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_PlanoSaudeId",
                table: "Usuario",
                newName: "IX_Usuario_PlanoSaudeId");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_EnderecoId",
                table: "Usuario",
                newName: "IX_Usuario_EnderecoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Faturistas_Usuario_UsuarioId",
                table: "Faturistas",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Usuario_UsuarioId",
                table: "Pacientes",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Secretarias_Usuario_UsuarioId",
                table: "Secretarias",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_Usuario_UsuarioId",
                table: "Telefones",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Enderecos_EnderecoId",
                table: "Usuario",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_PlanosSaude_PlanoSaudeId",
                table: "Usuario",
                column: "PlanoSaudeId",
                principalTable: "PlanosSaude",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
