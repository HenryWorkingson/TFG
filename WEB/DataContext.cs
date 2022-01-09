using Microsoft.EntityFrameworkCore;
using Restaurante;

namespace WEB
{
    public class DataContext: DbContext
    {
        public DbSet<Cuenta> Cuentas { get; set; }
        //public DbSet<Direccion_Envio> DireccionEnvios { get; set; }
        public DbSet<LineaPedido> LineaPedidos { get; set; }
        public DbSet<Menu> Menus { get; set; }
        //public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Plato> Platos { get; set; }
        public DbSet<Tarjeta> Tarjetas { get; set; }
        
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {


        }
    }
}
