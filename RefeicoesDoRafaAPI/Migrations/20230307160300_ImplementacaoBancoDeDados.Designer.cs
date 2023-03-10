﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RefeicoesDoRafaAPI.Dao;

#nullable disable

namespace RefeicoesDoRafaAPI.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230307160300_ImplementacaoBancoDeDados")]
    partial class ImplementacaoBancoDeDados
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RefeicoesDoRafaAPI.Models.Cliente", b =>
                {
                    b.Property<string>("cpf")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("enderecoid")
                        .HasColumnType("int");

                    b.Property<string>("nomeCompletoCliente")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("whatsapp")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("cpf");

                    b.HasIndex("enderecoid");

                    b.ToTable("cliente");
                });

            modelBuilder.Entity("RefeicoesDoRafaAPI.Models.Endereco", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("cep")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("complemento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("numero")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("endereco");
                });

            modelBuilder.Entity("RefeicoesDoRafaAPI.Models.Pedido", b =>
                {
                    b.Property<int>("idPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idPedido"));

                    b.Property<string>("clientecpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime>("horaSolicitacao")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isPedidoEntregue")
                        .HasColumnType("bit");

                    b.Property<string>("observacoesDoCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("refeicaoidRefeicao")
                        .HasColumnType("int");

                    b.HasKey("idPedido");

                    b.HasIndex("clientecpf");

                    b.HasIndex("refeicaoidRefeicao");

                    b.ToTable("pedido");
                });

            modelBuilder.Entity("RefeicoesDoRafaAPI.Models.Refeicao", b =>
                {
                    b.Property<int>("idRefeicao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idRefeicao"));

                    b.Property<string>("nomeRefeicao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("preco")
                        .HasPrecision(6, 2)
                        .HasColumnType("decimal(6,2)");

                    b.Property<string>("tipoAcompanhamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tipoProteina")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idRefeicao");

                    b.ToTable("refeicao");
                });

            modelBuilder.Entity("RefeicoesDoRafaAPI.Models.Cliente", b =>
                {
                    b.HasOne("RefeicoesDoRafaAPI.Models.Endereco", "endereco")
                        .WithMany()
                        .HasForeignKey("enderecoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("endereco");
                });

            modelBuilder.Entity("RefeicoesDoRafaAPI.Models.Pedido", b =>
                {
                    b.HasOne("RefeicoesDoRafaAPI.Models.Cliente", "cliente")
                        .WithMany()
                        .HasForeignKey("clientecpf")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RefeicoesDoRafaAPI.Models.Refeicao", "refeicao")
                        .WithMany()
                        .HasForeignKey("refeicaoidRefeicao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cliente");

                    b.Navigation("refeicao");
                });
#pragma warning restore 612, 618
        }
    }
}