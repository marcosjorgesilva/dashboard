﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WebDashboard.Models;

namespace WebDashboard.Migrations
{
    [DbContext(typeof(WebDashboardContext))]
    [Migration("20190524024415_PrimeiraMigration")]
    partial class PrimeiraMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebDashboard.Models.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TipoCategoria");

                    b.HasKey("IdCategoria");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("WebDashboard.Models.Endereco", b =>
                {
                    b.Property<int>("IdEndereco")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro");

                    b.Property<string>("Cep");

                    b.Property<string>("Cidade");

                    b.Property<string>("Complemento");

                    b.Property<string>("Estado");

                    b.Property<string>("Logradouro");

                    b.Property<int>("Numero");

                    b.Property<int>("RefIdUsuario");

                    b.Property<string>("Referencia");

                    b.HasKey("IdEndereco");

                    b.HasIndex("RefIdUsuario");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("WebDashboard.Models.FormaPagamento", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TipoCategoria");

                    b.HasKey("IdCategoria");

                    b.ToTable("FormaPagamento");
                });

            modelBuilder.Entity("WebDashboard.Models.ItensPedido", b =>
                {
                    b.Property<int>("RefIdIPedido");

                    b.Property<int>("RefIdProduto");

                    b.Property<int>("Quantidade");

                    b.Property<int?>("RefIdProdutos");

                    b.Property<double>("ValorTotal");

                    b.HasKey("RefIdIPedido", "RefIdProduto");

                    b.HasIndex("RefIdProdutos");

                    b.ToTable("ItensPedido");
                });

            modelBuilder.Entity("WebDashboard.Models.Pedido", b =>
                {
                    b.Property<int>("IdPedido")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Estoque");

                    b.Property<string>("Nome");

                    b.Property<int>("RefIdFormaPagamento");

                    b.Property<string>("Tamanho");

                    b.Property<double>("ValorProduto");

                    b.HasKey("IdPedido");

                    b.HasIndex("RefIdFormaPagamento");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("WebDashboard.Models.Produto", b =>
                {
                    b.Property<int>("IdProduto")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Estoque");

                    b.Property<string>("Nome");

                    b.Property<int>("RefIdCategoria");

                    b.Property<string>("Tamanho");

                    b.Property<double>("ValorProduto");

                    b.HasKey("IdProduto");

                    b.HasIndex("RefIdCategoria");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("WebDashboard.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cpf");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Email");

                    b.Property<string>("Login");

                    b.Property<string>("NomeUsuario");

                    b.Property<string>("Senha");

                    b.Property<string>("TelefoneCelular");

                    b.Property<string>("TelefoneFixo");

                    b.Property<string>("TipoUsuario");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("WebDashboard.Models.Endereco", b =>
                {
                    b.HasOne("WebDashboard.Models.Usuario", "Usuario")
                        .WithMany("Enderecos")
                        .HasForeignKey("RefIdUsuario")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebDashboard.Models.ItensPedido", b =>
                {
                    b.HasOne("WebDashboard.Models.Pedido", "Pedido")
                        .WithMany("ItensPedidos")
                        .HasForeignKey("RefIdIPedido")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebDashboard.Models.Produto", "Produto")
                        .WithMany("ItensPedidos")
                        .HasForeignKey("RefIdProdutos");
                });

            modelBuilder.Entity("WebDashboard.Models.Pedido", b =>
                {
                    b.HasOne("WebDashboard.Models.FormaPagamento", "FormaPagamento")
                        .WithMany("Pedidos")
                        .HasForeignKey("RefIdFormaPagamento")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebDashboard.Models.Produto", b =>
                {
                    b.HasOne("WebDashboard.Models.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("RefIdCategoria")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
