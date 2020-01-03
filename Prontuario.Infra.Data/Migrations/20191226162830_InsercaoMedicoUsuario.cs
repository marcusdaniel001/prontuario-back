using Microsoft.EntityFrameworkCore.Migrations;

namespace Prontuario.Infra.Data.Migrations
{
    public partial class InsercaoMedicoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Medicos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_UsuarioId",
                table: "Medicos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicos_Usuarios_UsuarioId",
                table: "Medicos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicos_Usuarios_UsuarioId",
                table: "Medicos");

            migrationBuilder.DropIndex(
                name: "IX_Medicos_UsuarioId",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Medicos");
        }
    }
}
