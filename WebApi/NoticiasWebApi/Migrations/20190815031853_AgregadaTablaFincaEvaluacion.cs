using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoticiasWebApi.Migrations
{
    public partial class AgregadaTablaFincaEvaluacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FincaEvaluacion",
                columns: table => new
                {
                    idEvaluacion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fechaEvaluacion = table.Column<DateTime>(type: "Datetime", nullable: false),
                    valoracionTerreno = table.Column<string>(maxLength: 20, nullable: true),
                    fechaInspeccion = table.Column<DateTime>(type: "Datetime", nullable: false),
                    idProceso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FincaEvaluacion", x => x.idEvaluacion);
                    table.ForeignKey(
                        name: "FK_FincaEvaluacion_FincaProceso_idProceso",
                        column: x => x.idProceso,
                        principalTable: "FincaProceso",
                        principalColumn: "idProceso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FincaEvaluacion_idProceso",
                table: "FincaEvaluacion",
                column: "idProceso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FincaEvaluacion");
        }
    }
}
