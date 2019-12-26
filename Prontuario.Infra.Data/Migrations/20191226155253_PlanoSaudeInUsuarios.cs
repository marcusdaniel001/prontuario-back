using Microsoft.EntityFrameworkCore.Migrations;

namespace Prontuario.Infra.Data.Migrations
{
    public partial class PlanoSaudeInUsuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faturistas_PlanosSaude_PlanoSaudeId",
                table: "Faturistas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_PlanosSaude_PlanoSaudeId",
                table: "Pacientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Secretarias_PlanosSaude_PlanoSaudeId",
                table: "Secretarias");

            migrationBuilder.DropIndex(
                name: "IX_Secretarias_PlanoSaudeId",
                table: "Secretarias");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_PlanoSaudeId",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Faturistas_PlanoSaudeId",
                table: "Faturistas");

            migrationBuilder.DropColumn(
                name: "PlanoSaudeId",
                table: "Secretarias");

            migrationBuilder.DropColumn(
                name: "PlanoSaudeId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "PlanoSaudeId",
                table: "Faturistas");

            migrationBuilder.AddColumn<int>(
                name: "PlanoSaudeId",
                table: "Usuario",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PlanoSaudeId",
                table: "Usuario",
                column: "PlanoSaudeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_PlanosSaude_PlanoSaudeId",
                table: "Usuario",
                column: "PlanoSaudeId",
                principalTable: "PlanosSaude",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_PlanosSaude_PlanoSaudeId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_PlanoSaudeId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "PlanoSaudeId",
                table: "Usuario");

            migrationBuilder.AddColumn<int>(
                name: "PlanoSaudeId",
                table: "Secretarias",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlanoSaudeId",
                table: "Pacientes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlanoSaudeId",
                table: "Faturistas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Secretarias_PlanoSaudeId",
                table: "Secretarias",
                column: "PlanoSaudeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_PlanoSaudeId",
                table: "Pacientes",
                column: "PlanoSaudeId");

            migrationBuilder.CreateIndex(
                name: "IX_Faturistas_PlanoSaudeId",
                table: "Faturistas",
                column: "PlanoSaudeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Faturistas_PlanosSaude_PlanoSaudeId",
                table: "Faturistas",
                column: "PlanoSaudeId",
                principalTable: "PlanosSaude",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_PlanosSaude_PlanoSaudeId",
                table: "Pacientes",
                column: "PlanoSaudeId",
                principalTable: "PlanosSaude",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Secretarias_PlanosSaude_PlanoSaudeId",
                table: "Secretarias",
                column: "PlanoSaudeId",
                principalTable: "PlanosSaude",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
