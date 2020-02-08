using Microsoft.EntityFrameworkCore.Migrations;

namespace Prontuario.Infra.Data.Migrations
{
    public partial class ajustesrelacionamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_LocalAtendimentos_LocalAtendimentoId",
                table: "Telefones");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_Usuarios_UsuarioId",
                table: "Telefones");

            migrationBuilder.DropIndex(
                name: "IX_Telefones_UsuarioId",
                table: "Telefones");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Telefones");

            migrationBuilder.AddColumn<int>(
                name: "TelefoneId",
                table: "Usuarios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "LocalAtendimentoId",
                table: "Telefones",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "TelefoneId",
                table: "LocalAtendimentos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TelefoneId",
                table: "Usuarios",
                column: "TelefoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_LocalAtendimentos_LocalAtendimentoId",
                table: "Telefones",
                column: "LocalAtendimentoId",
                principalTable: "LocalAtendimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Telefones_TelefoneId",
                table: "Usuarios",
                column: "TelefoneId",
                principalTable: "Telefones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_LocalAtendimentos_LocalAtendimentoId",
                table: "Telefones");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Telefones_TelefoneId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_TelefoneId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "TelefoneId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "TelefoneId",
                table: "LocalAtendimentos");

            migrationBuilder.AlterColumn<int>(
                name: "LocalAtendimentoId",
                table: "Telefones",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Telefones",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_UsuarioId",
                table: "Telefones",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_LocalAtendimentos_LocalAtendimentoId",
                table: "Telefones",
                column: "LocalAtendimentoId",
                principalTable: "LocalAtendimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_Usuarios_UsuarioId",
                table: "Telefones",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
