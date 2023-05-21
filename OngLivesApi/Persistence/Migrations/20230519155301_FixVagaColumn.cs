using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ONGLIVES.API.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixVagaColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vagas_Ongs_OngId",
                table: "Vagas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vagas_Voluntarios_VoluntarioId",
                table: "Vagas");

            migrationBuilder.AlterColumn<int>(
                name: "VoluntarioId",
                table: "Vagas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OngId",
                table: "Vagas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdOng",
                table: "Vagas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdVoluntario",
                table: "Vagas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Vagas_Ongs_OngId",
                table: "Vagas",
                column: "OngId",
                principalTable: "Ongs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vagas_Voluntarios_VoluntarioId",
                table: "Vagas",
                column: "VoluntarioId",
                principalTable: "Voluntarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vagas_Ongs_OngId",
                table: "Vagas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vagas_Voluntarios_VoluntarioId",
                table: "Vagas");

            migrationBuilder.DropColumn(
                name: "IdOng",
                table: "Vagas");

            migrationBuilder.DropColumn(
                name: "IdVoluntario",
                table: "Vagas");

            migrationBuilder.AlterColumn<int>(
                name: "VoluntarioId",
                table: "Vagas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OngId",
                table: "Vagas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vagas_Ongs_OngId",
                table: "Vagas",
                column: "OngId",
                principalTable: "Ongs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vagas_Voluntarios_VoluntarioId",
                table: "Vagas",
                column: "VoluntarioId",
                principalTable: "Voluntarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
