﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebMVC;

namespace WebMVC.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    [Migration("20211209234616_v1.3")]
    partial class v13
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("Restaurante.Carro", b =>
                {
                    b.Property<int>("idLPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("NombreProducto")
                        .HasColumnType("longtext");

                    b.Property<double>("PrecioProductoUnitario")
                        .HasColumnType("double");

                    b.Property<double>("PrecioTotal")
                        .HasColumnType("double");

                    b.Property<int>("idPlato")
                        .HasColumnType("int");

                    b.HasKey("idLPedido");

                    b.ToTable("Carro");
                });

            modelBuilder.Entity("Restaurante.Cuenta", b =>
                {
                    b.Property<int>("id_Cuenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellido_Cuenta")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Correo_Cuenta")
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre_Cuenta")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password_Cuenta")
                        .HasColumnType("longtext");

                    b.HasKey("id_Cuenta");

                    b.ToTable("Cuentas");
                });

            modelBuilder.Entity("Restaurante.Direccion_Envio", b =>
                {
                    b.Property<int>("id_DireccionEnvio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DNI_Cliente_Rceiv")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Municipal")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nombre_Cliente_Rec")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nombre_Direccion")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Provincia")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telefono_Cliente")
                        .HasColumnType("longtext");

                    b.HasKey("id_DireccionEnvio");

                    b.ToTable("DireccionEnvios");
                });

            modelBuilder.Entity("Restaurante.LineaPedido", b =>
                {
                    b.Property<int>("id_LineaPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int?>("Pedidoid_Pedido")
                        .HasColumnType("int");

                    b.Property<double>("PrecioProductoUnitario")
                        .HasColumnType("double");

                    b.Property<double>("PrecioTotal")
                        .HasColumnType("double");

                    b.Property<int>("id_Pedido")
                        .HasColumnType("int");

                    b.Property<int>("id_Plato")
                        .HasColumnType("int");

                    b.HasKey("id_LineaPedido");

                    b.HasIndex("Pedidoid_Pedido");

                    b.ToTable("LineaPedidos");
                });

            modelBuilder.Entity("Restaurante.Menu", b =>
                {
                    b.Property<int>("IdMenu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DescripcionMenu")
                        .HasColumnType("longtext");

                    b.Property<string>("NombreMenu")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<double>("PrecioMenu")
                        .HasColumnType("double");

                    b.HasKey("IdMenu");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("Restaurante.Pedido", b =>
                {
                    b.Property<int>("id_Pedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion_Pedido")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("Id_Direccion")
                        .HasColumnType("int");

                    b.Property<double>("Precio_Total")
                        .HasColumnType("double");

                    b.Property<int>("Tarjeta")
                        .HasColumnType("int");

                    b.HasKey("id_Pedido");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("Restaurante.Plato", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DescripcionPlato")
                        .HasColumnType("longtext");

                    b.Property<int?>("LineaPedidoid_LineaPedido")
                        .HasColumnType("int");

                    b.Property<string>("NombrePlato")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<double>("PrecioBase")
                        .HasColumnType("double");

                    b.Property<string>("TipoPlato")
                        .HasColumnType("longtext");

                    b.HasKey("IdProducto");

                    b.HasIndex("LineaPedidoid_LineaPedido");

                    b.ToTable("Platos");
                });

            modelBuilder.Entity("Restaurante.Tarjeta", b =>
                {
                    b.Property<int>("id_Tarjeta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FechaCadu_Tarjeta")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nom_Propietario")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Numero_Tarjeta")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("id_Tarjeta");

                    b.ToTable("Tarjetas");
                });

            modelBuilder.Entity("Restaurante.LineaPedido", b =>
                {
                    b.HasOne("Restaurante.Pedido", null)
                        .WithMany("lineas")
                        .HasForeignKey("Pedidoid_Pedido");
                });

            modelBuilder.Entity("Restaurante.Plato", b =>
                {
                    b.HasOne("Restaurante.LineaPedido", null)
                        .WithMany("Lista_Pedidos")
                        .HasForeignKey("LineaPedidoid_LineaPedido");
                });

            modelBuilder.Entity("Restaurante.LineaPedido", b =>
                {
                    b.Navigation("Lista_Pedidos");
                });

            modelBuilder.Entity("Restaurante.Pedido", b =>
                {
                    b.Navigation("lineas");
                });
#pragma warning restore 612, 618
        }
    }
}
