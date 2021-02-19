using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarForSale.Migrations
{
    public partial class VeiculosV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motos_Fornecedores_FornecedorId",
                table: "Motos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId",
                table: "Pedidos");

            migrationBuilder.DropTable(
                name: "Carros");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Motos",
                table: "Motos");

            migrationBuilder.RenameTable(
                name: "Motos",
                newName: "Veiculo");

            migrationBuilder.RenameIndex(
                name: "IX_Motos_FornecedorId",
                table: "Veiculo",
                newName: "IX_Veiculo_FornecedorId");

            migrationBuilder.AlterColumn<Guid>(
                name: "VeiculoId",
                table: "Pedidos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ClienteId",
                table: "Pedidos",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "FornecedorId",
                table: "Veiculo",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "Cilindradas",
                table: "Veiculo",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "LitrosPortaMalas",
                table: "Veiculo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Veiculo",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Veiculo",
                table: "Veiculo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculo_Fornecedores_FornecedorId",
                table: "Veiculo",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculo_Fornecedores_FornecedorId",
                table: "Veiculo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Veiculo",
                table: "Veiculo");

            migrationBuilder.DropColumn(
                name: "LitrosPortaMalas",
                table: "Veiculo");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Veiculo");

            migrationBuilder.RenameTable(
                name: "Veiculo",
                newName: "Motos");

            migrationBuilder.RenameIndex(
                name: "IX_Veiculo_FornecedorId",
                table: "Motos",
                newName: "IX_Motos_FornecedorId");

            migrationBuilder.AlterColumn<string>(
                name: "VeiculoId",
                table: "Pedidos",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "ClienteId",
                table: "Pedidos",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "FornecedorId",
                table: "Motos",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cilindradas",
                table: "Motos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Motos",
                table: "Motos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Cor = table.Column<string>(nullable: false),
                    FornecedorId = table.Column<Guid>(nullable: false),
                    LitrosPortaMalas = table.Column<string>(nullable: false),
                    Modelo = table.Column<string>(nullable: false),
                    Motor = table.Column<string>(nullable: false),
                    Tipo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carros_Fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Carros_FornecedorId",
                table: "Carros",
                column: "FornecedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Motos_Fornecedores_FornecedorId",
                table: "Motos",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId",
                table: "Pedidos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
