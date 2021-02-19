﻿// <auto-generated />
using System;
using CarForSale.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarForSale.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20210219164217_VeiculosV1")]
    partial class VeiculosV1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarForSale.Model.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cpf")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("Senha")
                        .IsRequired();

                    b.Property<string>("Sobrenome")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("CarForSale.Model.Fornecedor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Codigo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("CarForSale.Model.Pedidos", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ClienteId");

                    b.Property<Guid>("VeiculoId");

                    b.HasKey("Id");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("CarForSale.Model.Veiculo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cor")
                        .IsRequired();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<Guid?>("FornecedorId");

                    b.Property<string>("Modelo")
                        .IsRequired();

                    b.Property<string>("Motor")
                        .IsRequired();

                    b.Property<string>("Tipo")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("FornecedorId");

                    b.ToTable("Veiculo");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Veiculo");
                });

            modelBuilder.Entity("CarForSale.Model.Carro", b =>
                {
                    b.HasBaseType("CarForSale.Model.Veiculo");

                    b.Property<string>("LitrosPortaMalas")
                        .IsRequired();

                    b.ToTable("Carro");

                    b.HasDiscriminator().HasValue("Carro");
                });

            modelBuilder.Entity("CarForSale.Model.Moto", b =>
                {
                    b.HasBaseType("CarForSale.Model.Veiculo");

                    b.Property<string>("Cilindradas")
                        .IsRequired();

                    b.ToTable("Moto");

                    b.HasDiscriminator().HasValue("Moto");
                });

            modelBuilder.Entity("CarForSale.Model.Veiculo", b =>
                {
                    b.HasOne("CarForSale.Model.Fornecedor")
                        .WithMany("Veiculos")
                        .HasForeignKey("FornecedorId");
                });
#pragma warning restore 612, 618
        }
    }
}
