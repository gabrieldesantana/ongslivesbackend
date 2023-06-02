using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ONGLIVES.API.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeExpAndVaga : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Disponivel",
                table: "TB_Vagas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Nota",
                table: "TB_Experiencias",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disponivel",
                table: "TB_Vagas");

            migrationBuilder.DropColumn(
                name: "Nota",
                table: "TB_Experiencias");
        }
    }
}
