using Microsoft.EntityFrameworkCore;

namespace TFG
{
    public class DatabaseContext : DbContext
    {
        //public DbSet<Comentario> Comentario { get; set; }

   
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
    }
}
