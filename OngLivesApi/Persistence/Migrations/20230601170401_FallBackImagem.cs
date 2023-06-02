using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ONGLIVES.API.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FallBackImagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_TB_Ongs_TB_Imagens_ImagemId",
            //     table: "TB_Ongs");

            // migrationBuilder.DropForeignKey(
            //     name: "FK_TB_Voluntarios_TB_Imagens_ImagemId",
            //     table: "TB_Voluntarios");

            // migrationBuilder.DropIndex(
            //     name: "IX_TB_Voluntarios_ImagemId",
            //     table: "TB_Voluntarios");

            // migrationBuilder.DropIndex(
            //     name: "IX_TB_Ongs_ImagemId",
            //     table: "TB_Ongs");

            // migrationBuilder.DropColumn(
            //     name: "ImagemId",
            //     table: "TB_Voluntarios");

            // migrationBuilder.DropColumn(
            //     name: "ImagemId",
            //     table: "TB_Ongs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImagemId",
                table: "TB_Voluntarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImagemId",
                table: "TB_Ongs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TB_Voluntarios_ImagemId",
                table: "TB_Voluntarios",
                column: "ImagemId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Ongs_ImagemId",
                table: "TB_Ongs",
                column: "ImagemId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Ongs_TB_Imagens_ImagemId",
                table: "TB_Ongs",
                column: "ImagemId",
                principalTable: "TB_Imagens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Voluntarios_TB_Imagens_ImagemId",
                table: "TB_Voluntarios",
                column: "ImagemId",
                principalTable: "TB_Imagens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
