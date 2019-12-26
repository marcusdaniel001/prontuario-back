using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Prontuario.Infra.Data.Migrations
{
    public partial class AlteracoesNasRelacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefone_Usuario_UsuarioId",
                table: "Telefone");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Endereco_EnderecoId",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Telefone",
                table: "Telefone");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Telefone");

            migrationBuilder.DropColumn(
                name: "Fixo",
                table: "Telefone");

            migrationBuilder.RenameTable(
                name: "Telefone",
                newName: "Telefones");

            migrationBuilder.RenameTable(
                name: "Endereco",
                newName: "Enderecos");

            migrationBuilder.RenameIndex(
                name: "IX_Telefone_UsuarioId",
                table: "Telefones",
                newName: "IX_Telefones_UsuarioId");

            migrationBuilder.AddColumn<int>(
                name: "LocalAtendimentoId",
                table: "Telefones",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Telefones",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Telefones",
                table: "Telefones",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "LocalAtendimentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(nullable: true),
                    EnderecoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalAtendimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocalAtendimentos_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanosSaude",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanosSaude", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faturistas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Senha = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: false),
                    PlanoSaudeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faturistas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faturistas_PlanosSaude_PlanoSaudeId",
                        column: x => x.PlanoSaudeId,
                        principalTable: "PlanosSaude",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Faturistas_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Senha = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: false),
                    PlanoSaudeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_PlanosSaude_PlanoSaudeId",
                        column: x => x.PlanoSaudeId,
                        principalTable: "PlanosSaude",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pacientes_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Secretarias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Senha = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: false),
                    LocalAtendimentoId = table.Column<int>(nullable: false),
                    PlanoSaudeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secretarias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Secretarias_LocalAtendimentos_LocalAtendimentoId",
                        column: x => x.LocalAtendimentoId,
                        principalTable: "LocalAtendimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Secretarias_PlanosSaude_PlanoSaudeId",
                        column: x => x.PlanoSaudeId,
                        principalTable: "PlanosSaude",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Secretarias_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_LocalAtendimentoId",
                table: "Telefones",
                column: "LocalAtendimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Faturistas_PlanoSaudeId",
                table: "Faturistas",
                column: "PlanoSaudeId");

            migrationBuilder.CreateIndex(
                name: "IX_Faturistas_UsuarioId",
                table: "Faturistas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalAtendimentos_EnderecoId",
                table: "LocalAtendimentos",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_PlanoSaudeId",
                table: "Pacientes",
                column: "PlanoSaudeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_UsuarioId",
                table: "Pacientes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Secretarias_LocalAtendimentoId",
                table: "Secretarias",
                column: "LocalAtendimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Secretarias_PlanoSaudeId",
                table: "Secretarias",
                column: "PlanoSaudeId");

            migrationBuilder.CreateIndex(
                name: "IX_Secretarias_UsuarioId",
                table: "Secretarias",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_LocalAtendimentos_LocalAtendimentoId",
                table: "Telefones",
                column: "LocalAtendimentoId",
                principalTable: "LocalAtendimentos",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_LocalAtendimentos_LocalAtendimentoId",
                table: "Telefones");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_Usuario_UsuarioId",
                table: "Telefones");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Enderecos_EnderecoId",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "Faturistas");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Secretarias");

            migrationBuilder.DropTable(
                name: "LocalAtendimentos");

            migrationBuilder.DropTable(
                name: "PlanosSaude");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Telefones",
                table: "Telefones");

            migrationBuilder.DropIndex(
                name: "IX_Telefones_LocalAtendimentoId",
                table: "Telefones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "LocalAtendimentoId",
                table: "Telefones");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Telefones");

            migrationBuilder.RenameTable(
                name: "Telefones",
                newName: "Telefone");

            migrationBuilder.RenameTable(
                name: "Enderecos",
                newName: "Endereco");

            migrationBuilder.RenameIndex(
                name: "IX_Telefones_UsuarioId",
                table: "Telefone",
                newName: "IX_Telefone_UsuarioId");

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Telefone",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fixo",
                table: "Telefone",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Telefone",
                table: "Telefone",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Telefone_Usuario_UsuarioId",
                table: "Telefone",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Endereco_EnderecoId",
                table: "Usuario",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
