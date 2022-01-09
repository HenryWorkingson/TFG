using Microsoft.EntityFrameworkCore;
using System;

namespace Restaurante
{
    internal class DatabaseContext : DbContext
    {
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Direccion_Envio> DireccionEnvios { get; set; }
        public DbSet<LineaPedido> LineaPedidos { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Plato> Platos { get; set; }
        public DbSet<Tarjeta> Tarjetas { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Pedido>()
        //        .HasMany(p => p.lineas);
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                string mySqlConnection = "Server = localhost; Database = tfg; Uid = root; Pwd = 1234";
                optionsBuilder.UseMySQL(mySqlConnection); 
                //optionsBuilder.UseSqlServer(mySqlConnection);
            }
            base.OnConfiguring(optionsBuilder);
        }

    }
}
