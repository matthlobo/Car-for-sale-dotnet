using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarForSale.Migrations
{
    public partial class PedidosV4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Fornecedores_FornecedorId",
                table: "Carros");

            migrationBuilder.DropForeignKey(
                name: "FK_Motos_Fornecedores_FornecedorId",
                table: "Motos");

            migrationBuilder.DropColumn(
                name: "CodigoFornecedor",
                table: "Motos");

            migrationBuilder.DropColumn(
                name: "CodigoFornecedor",
                table: "Carros");

            migrationBuilder.AlterColumn<Guid>(
                name: "FornecedorId",
                table: "Motos",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "FornecedorId",
                table: "Carros",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClienteId = table.Column<Guid>(nullable: true),
                    VeiculoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Fornecedores_FornecedorId",
                table: "Carros",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Motos_Fornecedores_FornecedorId",
                table: "Motos",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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
                name: "Pedidos");

            migrationBuilder.AlterColumn<Guid>(
                name: "FornecedorId",
                table: "Motos",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<string>(
                name: "CodigoFornecedor",
                table: "Motos",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "FornecedorId",
                table: "Carros",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<string>(
                name: "CodigoFornecedor",
                table: "Carros",
                nullable: false,
                defaultValue: "");

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
    }
}
