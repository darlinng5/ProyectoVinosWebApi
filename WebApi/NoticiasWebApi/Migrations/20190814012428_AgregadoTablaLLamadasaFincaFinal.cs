using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoticiasWebApi.Migrations
{
    public partial class AgregadoTablaLLamadasaFincaFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LlamadasAFinca",
                columns: table => new
                {
                    idLLamada = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fechaLLamada = table.Column<DateTime>(type: "Datetime", nullable: false),
                    Observacion = table.Column<string>(maxLength: 20, nullable: true),
                    fechaVisita = table.Column<DateTime>(type: "Datetime", nullable: false),
                    idProceso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LlamadasAFinca", x => x.idLLamada);
                    table.ForeignKey(
                        name: "FK_LlamadasAFinca_FincaProceso_idProceso",
                        column: x => x.idProceso,
                        principalTable: "FincaProceso",
                        principalColumn: "idProceso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LlamadasAFinca_idProceso",
                table: "LlamadasAFinca",
                column: "idProceso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LlamadasAFinca");
        }
    }
}
