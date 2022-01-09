using Microsoft.EntityFrameworkCore;
using Restaurante;

namespace WebMVC
{
    public class AplicationDbContext : DbContext
    {
        public DbSet<global::Restaurante.Cuenta> Cuentas { get; set; }
        public DbSet<global::Restaurante.Direccion_Envio> DireccionEnvios { get; set; }
        public DbSet<global::Restaurante.LineaPedido> LineaPedidos { get; set; }
        public DbSet<global::Restaurante.Menu> Menus { get; set; }
        public DbSet<global::Restaurante.Pedido> Pedidos { get; set; }
        public DbSet<global::Restaurante.Plato> Platos { get; set; }
        public DbSet<global::Restaurante.Tarjeta> Tarjetas { get; set; }
        public DbSet<global::Restaurante.Carro> Carros { get; set; }
        public DbSet<global::Restaurante.Reserva> Reservas { get; set; }

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }
    }
}