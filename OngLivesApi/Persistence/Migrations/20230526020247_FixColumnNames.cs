using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ONGLIVES.API.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixColumnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiencias_Ongs_OngId",
                table: "Experiencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiencias_Voluntarios_VoluntarioId",
                table: "Experiencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Ongs_Endereco_EnderecoId",
                table: "Ongs");

            migrationBuilder.DropForeignKey(
                name: "FK_Vagas_Ongs_OngId",
                table: "Vagas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vagas_Voluntarios_VoluntarioId",
                table: "Vagas");

            migrationBuilder.DropForeignKey(
                name: "FK_Voluntarios_Endereco_EnderecoId",
                table: "Voluntarios");

            migrationBuilder.DropTable(
                name: "OngFinanceiros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Voluntarios",
                table: "Voluntarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vagas",
                table: "Vagas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ongs",
                table: "Ongs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Experiencias",
                table: "Experiencias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco");

            migrationBuilder.RenameTable(
                name: "Voluntarios",
                newName: "TB_Voluntarios");

            migrationBuilder.RenameTable(
                name: "Vagas",
                newName: "TB_Vagas");

            migrationBuilder.RenameTable(
                name: "Ongs",
                newName: "TB_Ongs");

            migrationBuilder.RenameTable(
                name: "Experiencias",
                newName: "TB_Experiencias");

            migrationBuilder.RenameTable(
                name: "Endereco",
                newName: "TB_Enderecos");

            migrationBuilder.RenameIndex(
                name: "IX_Voluntarios_EnderecoId",
                table: "TB_Voluntarios",
                newName: "IX_TB_Voluntarios_EnderecoId");

            migrationBuilder.RenameIndex(
                name: "IX_Vagas_VoluntarioId",
                table: "TB_Vagas",
                newName: "IX_TB_Vagas_VoluntarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Vagas_OngId",
                table: "TB_Vagas",
                newName: "IX_TB_Vagas_OngId");

            migrationBuilder.RenameIndex(
                name: "IX_Ongs_EnderecoId",
                table: "TB_Ongs",
                newName: "IX_TB_Ongs_EnderecoId");

            migrationBuilder.RenameIndex(
                name: "IX_Experiencias_VoluntarioId",
                table: "TB_Experiencias",
                newName: "IX_TB_Experiencias_VoluntarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Experiencias_OngId",
                table: "TB_Experiencias",
                newName: "IX_TB_Experiencias_OngId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_Voluntarios",
                table: "TB_Voluntarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_Vagas",
                table: "TB_Vagas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_Ongs",
                table: "TB_Ongs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_Experiencias",
                table: "TB_Experiencias",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_Enderecos",
                table: "TB_Enderecos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TB_OngFinanceiros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOng = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Origem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OngId = table.Column<int>(type: "int", nullable: true),
                    Actived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_OngFinanceiros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_OngFinanceiros_TB_Ongs_OngId",
                        column: x => x.OngId,
                        principalTable: "TB_Ongs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_OngFinanceiros_OngId",
                table: "TB_OngFinanceiros",
                column: "OngId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Experiencias_TB_Ongs_OngId",
                table: "TB_Experiencias",
                column: "OngId",
                principalTable: "TB_Ongs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Experiencias_TB_Voluntarios_VoluntarioId",
                table: "TB_Experiencias",
                column: "VoluntarioId",
                principalTable: "TB_Voluntarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Ongs_TB_Enderecos_EnderecoId",
                table: "TB_Ongs",
                column: "EnderecoId",
                principalTable: "TB_Enderecos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Vagas_TB_Ongs_OngId",
                table: "TB_Vagas",
                column: "OngId",
                principalTable: "TB_Ongs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Vagas_TB_Voluntarios_VoluntarioId",
                table: "TB_Vagas",
                column: "VoluntarioId",
                principalTable: "TB_Voluntarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Voluntarios_TB_Enderecos_EnderecoId",
                table: "TB_Voluntarios",
                column: "EnderecoId",
                principalTable: "TB_Enderecos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_Experiencias_TB_Ongs_OngId",
                table: "TB_Experiencias");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_Experiencias_TB_Voluntarios_VoluntarioId",
                table: "TB_Experiencias");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_Ongs_TB_Enderecos_EnderecoId",
                table: "TB_Ongs");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_Vagas_TB_Ongs_OngId",
                table: "TB_Vagas");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_Vagas_TB_Voluntarios_VoluntarioId",
                table: "TB_Vagas");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_Voluntarios_TB_Enderecos_EnderecoId",
                table: "TB_Voluntarios");

            migrationBuilder.DropTable(
                name: "TB_OngFinanceiros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_Voluntarios",
                table: "TB_Voluntarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_Vagas",
                table: "TB_Vagas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_Ongs",
                table: "TB_Ongs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_Experiencias",
                table: "TB_Experiencias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_Enderecos",
                table: "TB_Enderecos");

            migrationBuilder.RenameTable(
                name: "TB_Voluntarios",
                newName: "Voluntarios");

            migrationBuilder.RenameTable(
                name: "TB_Vagas",
                newName: "Vagas");

            migrationBuilder.RenameTable(
                name: "TB_Ongs",
                newName: "Ongs");

            migrationBuilder.RenameTable(
                name: "TB_Experiencias",
                newName: "Experiencias");

            migrationBuilder.RenameTable(
                name: "TB_Enderecos",
                newName: "Endereco");

            migrationBuilder.RenameIndex(
                name: "IX_TB_Voluntarios_EnderecoId",
                table: "Voluntarios",
                newName: "IX_Voluntarios_EnderecoId");

            migrationBuilder.RenameIndex(
                name: "IX_TB_Vagas_VoluntarioId",
                table: "Vagas",
                newName: "IX_Vagas_VoluntarioId");

            migrationBuilder.RenameIndex(
                name: "IX_TB_Vagas_OngId",
                table: "Vagas",
                newName: "IX_Vagas_OngId");

            migrationBuilder.RenameIndex(
                name: "IX_TB_Ongs_EnderecoId",
                table: "Ongs",
                newName: "IX_Ongs_EnderecoId");

            migrationBuilder.RenameIndex(
                name: "IX_TB_Experiencias_VoluntarioId",
                table: "Experiencias",
                newName: "IX_Experiencias_VoluntarioId");

            migrationBuilder.RenameIndex(
                name: "IX_TB_Experiencias_OngId",
                table: "Experiencias",
                newName: "IX_Experiencias_OngId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Voluntarios",
                table: "Voluntarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vagas",
                table: "Vagas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ongs",
                table: "Ongs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Experiencias",
                table: "Experiencias",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "OngFinanceiros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Actived = table.Column<bool>(type: "bit", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdOng = table.Column<int>(type: "int", nullable: false),
                    OngId = table.Column<int>(type: "int", nullable: true),
                    Origem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OngFinanceiros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OngFinanceiros_Ongs_OngId",
                        column: x => x.OngId,
                        principalTable: "Ongs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OngFinanceiros_OngId",
                table: "OngFinanceiros",
                column: "OngId");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiencias_Ongs_OngId",
                table: "Experiencias",
                column: "OngId",
                principalTable: "Ongs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiencias_Voluntarios_VoluntarioId",
                table: "Experiencias",
                column: "VoluntarioId",
                principalTable: "Voluntarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ongs_Endereco_EnderecoId",
                table: "Ongs",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Voluntarios_Endereco_EnderecoId",
                table: "Voluntarios",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id");
        }
    }
}
