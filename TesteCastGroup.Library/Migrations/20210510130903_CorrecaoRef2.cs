using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteCastGroup.Library.Migrations
{
    public partial class CorrecaoRef2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Categorias_CategoriaId",
                table: "Cursos");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoriaId",
                table: "Cursos",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Categorias_CategoriaId",
                table: "Cursos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Categorias_CategoriaId",
                table: "Cursos");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoriaId",
                table: "Cursos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Categorias_CategoriaId",
                table: "Cursos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
