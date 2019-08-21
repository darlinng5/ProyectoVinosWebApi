using Microsoft.EntityFrameworkCore.Migrations;

namespace NoticiasWebApi.Migrations
{
    public partial class ActualizadatablaFincaEvaluacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "estado",
                table: "FincaEvaluacion",
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "estado",
                table: "FincaEvaluacion");
        }
    }
}
