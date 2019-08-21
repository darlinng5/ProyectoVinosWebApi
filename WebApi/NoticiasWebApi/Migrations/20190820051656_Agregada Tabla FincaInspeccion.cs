using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoticiasWebApi.Migrations
{
    public partial class AgregadaTablaFincaInspeccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropTable(
                name: "Nombres");

            migrationBuilder.RenameColumn(
                name: "fechaEvaluacion",
                table: "FincaEvaluacion",
                newName: "fechaVisita");

            migrationBuilder.AlterColumn<string>(
                name: "Observacion",
                table: "LlamadasAFinca",
                maxLength: 2147483647,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Observacion",
                table: "FincaEvaluacion",
                maxLength: 2147483647,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FincaInspeccion",
                columns: table => new
                {
                    idInspeccion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Observacion = table.Column<string>(maxLength: 2147483647, nullable: true),
                    fechaVisita = table.Column<DateTime>(type: "Datetime", nullable: false),
                    fechaCompra = table.Column<DateTime>(type: "Datetime", nullable: false),
                    estado = table.Column<string>(maxLength: 20, nullable: true),
                    idProceso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FincaInspeccion", x => x.idInspeccion);
                    table.ForeignKey(
                        name: "FK_FincaInspeccion_FincaProceso_idProceso",
                        column: x => x.idProceso,
                        principalTable: "FincaProceso",
                        principalColumn: "idProceso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FincaInspeccion_idProceso",
                table: "FincaInspeccion",
                column: "idProceso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FincaInspeccion");

            migrationBuilder.DropColumn(
                name: "Observacion",
                table: "FincaEvaluacion");

            migrationBuilder.RenameColumn(
                name: "fechaVisita",
                table: "FincaEvaluacion",
                newName: "fechaEvaluacion");

            migrationBuilder.AlterColumn<string>(
                name: "Observacion",
                table: "LlamadasAFinca",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 2147483647,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    AutorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Apellido = table.Column<string>(maxLength: 50, nullable: true),
                    Nombre = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.AutorID);
                });

            migrationBuilder.CreateTable(
                name: "Nombres",
                columns: table => new
                {
                    NombreID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nombres", x => x.NombreID);
                });
        }
    }
}
