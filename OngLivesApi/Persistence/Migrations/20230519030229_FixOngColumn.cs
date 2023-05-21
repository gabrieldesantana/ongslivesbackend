using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ONGLIVES.API.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixOngColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ongs_OngFinanceiros_FinanceiroId",
                table: "Ongs");

            migrationBuilder.DropIndex(
                name: "IX_Ongs_FinanceiroId",
                table: "Ongs");

            migrationBuilder.DropColumn(
                name: "FinanceiroId",
                table: "Ongs");

            migrationBuilder.AddColumn<int>(
                name: "OngId",
                table: "OngFinanceiros",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OngFinanceiros_OngId",
                table: "OngFinanceiros",
                column: "OngId");

            migrationBuilder.AddForeignKey(
                name: "FK_OngFinanceiros_Ongs_OngId",
                table: "OngFinanceiros",
                column: "OngId",
                principalTable: "Ongs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OngFinanceiros_Ongs_OngId",
                table: "OngFinanceiros");

            migrationBuilder.DropIndex(
                name: "IX_OngFinanceiros_OngId",
                table: "OngFinanceiros");

            migrationBuilder.DropColumn(
                name: "OngId",
                table: "OngFinanceiros");

            migrationBuilder.AddColumn<int>(
                name: "FinanceiroId",
                table: "Ongs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ongs_FinanceiroId",
                table: "Ongs",
                column: "FinanceiroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ongs_OngFinanceiros_FinanceiroId",
                table: "Ongs",
                column: "FinanceiroId",
                principalTable: "OngFinanceiros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
