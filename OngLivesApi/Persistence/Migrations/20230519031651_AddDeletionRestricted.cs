using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ONGLIVES.API.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDeletionRestricted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Actived",
                table: "Voluntarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Actived",
                table: "Vagas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Actived",
                table: "Ongs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Actived",
                table: "OngFinanceiros",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Actived",
                table: "Experiencias",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Actived",
                table: "Endereco",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Actived",
                table: "Voluntarios");

            migrationBuilder.DropColumn(
                name: "Actived",
                table: "Vagas");

            migrationBuilder.DropColumn(
                name: "Actived",
                table: "Ongs");

            migrationBuilder.DropColumn(
                name: "Actived",
                table: "OngFinanceiros");

            migrationBuilder.DropColumn(
                name: "Actived",
                table: "Experiencias");

            migrationBuilder.DropColumn(
                name: "Actived",
                table: "Endereco");
        }
    }
}
