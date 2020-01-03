using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Prontuario.Infra.Data.Migrations
{
    public partial class InsercaoNoContexto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Senha = table.Column<string>(nullable: true),
                    EspecialidadesMedicas = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InscricaoConselhosMedicina",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Numero = table.Column<string>(nullable: true),
                    MedicoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InscricaoConselhosMedicina", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InscricaoConselhosMedicina_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocalAtendimentoMedico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MedicoId = table.Column<int>(nullable: false),
                    LocalAtendimentoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalAtendimentoMedico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocalAtendimentoMedico_LocalAtendimentos_LocalAtendimentoId",
                        column: x => x.LocalAtendimentoId,
                        principalTable: "LocalAtendimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocalAtendimentoMedico_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InscricaoConselhosMedicina_MedicoId",
                table: "InscricaoConselhosMedicina",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalAtendimentoMedico_LocalAtendimentoId",
                table: "LocalAtendimentoMedico",
                column: "LocalAtendimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalAtendimentoMedico_MedicoId",
                table: "LocalAtendimentoMedico",
                column: "MedicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InscricaoConselhosMedicina");

            migrationBuilder.DropTable(
                name: "LocalAtendimentoMedico");

            migrationBuilder.DropTable(
                name: "Medicos");
        }
    }
}
