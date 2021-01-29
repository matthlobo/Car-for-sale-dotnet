using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarForSale.Migrations
{
    public partial class Cliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FornecedorId",
                table: "Motos",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FornecedorId",
                table: "Carros",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Cpf = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Sobrenome = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Senha = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Motos_FornecedorId",
                table: "Motos",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Carros_FornecedorId",
                table: "Carros",
                column: "FornecedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Fornecedores_FornecedorId",
                table: "Carros",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Motos_Fornecedores_FornecedorId",
                table: "Motos",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Fornecedores_FornecedorId",
                table: "Carros");

            migrationBuilder.DropForeignKey(
                name: "FK_Motos_Fornecedores_FornecedorId",
                table: "Motos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Motos_FornecedorId",
                table: "Motos");

            migrationBuilder.DropIndex(
                name: "IX_Carros_FornecedorId",
                table: "Carros");

            migrationBuilder.DropColumn(
                name: "FornecedorId",
                table: "Motos");

            migrationBuilder.DropColumn(
                name: "FornecedorId",
                table: "Carros");
        }
    }
}
