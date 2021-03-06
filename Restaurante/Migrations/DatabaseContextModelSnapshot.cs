// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Restaurante;

namespace Restaurante.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Restaurante.Cuenta", b =>
                {
                    b.Property<int>("id_Cuenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido_Cuenta")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Correo_Cuenta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identificador_Cuenta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre_Cuenta")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password_Cuenta")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_Cuenta");

                    b.ToTable("Cuentas");
                });

            modelBuilder.Entity("Restaurante.Direccion_Envio", b =>
                {
                    b.Property<int>("id_DireccionEnvio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_DireccionEnvio");

                    b.ToTable("DireccionEnvios");
                });

            modelBuilder.Entity("Restaurante.LineaPedido", b =>
                {
                    b.Property<int>("id_LineaPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int?>("Pedidoid_Pedido")
                        .HasColumnType("int");

                    b.Property<double>("PrecioProductoUnitario")
                        .HasColumnType("float");

                    b.Property<double>("PrecioTotal")
                        .HasColumnType("float");

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
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescripcionMenu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreMenu")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<double>("PrecioMenu")
                        .HasColumnType("float");

                    b.HasKey("IdMenu");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("Restaurante.Pedido", b =>
                {
                    b.Property<int>("id_Pedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion_Pedido")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("Id_Direccion")
                        .HasColumnType("int");

                    b.Property<double>("Precio_Total")
                        .HasColumnType("float");

                    b.Property<int>("Tarjeta")
                        .HasColumnType("int");

                    b.HasKey("id_Pedido");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("Restaurante.Plato", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescripcionPlato")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LineaPedidoid_LineaPedido")
                        .HasColumnType("int");

                    b.Property<string>("NombrePlato")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<double>("PrecioBase")
                        .HasColumnType("float");

                    b.Property<int>("TipoPlato")
                        .HasColumnType("int");

                    b.HasKey("IdProducto");

                    b.HasIndex("LineaPedidoid_LineaPedido");

                    b.ToTable("Platos");
                });

            modelBuilder.Entity("Restaurante.Tarjeta", b =>
                {
                    b.Property<int>("id_Tarjeta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
