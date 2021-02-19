﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarForSale.Migrations
{
    public partial class Motos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LitrosPortaMalas",
                table: "Carros",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Motos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Modelo = table.Column<string>(nullable: false),
                    Cor = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(nullable: true),
                    Motor = table.Column<string>(nullable: true),
                    CodigoFornecedor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Motos");

            migrationBuilder.DropColumn(
                name: "LitrosPortaMalas",
                table: "Carros");
        }
    }
}