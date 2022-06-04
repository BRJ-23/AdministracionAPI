using Microsoft.EntityFrameworkCore;

namespace AdministracionAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opciones) : base(opciones) { }

        //Cargamos los modelos de las tablas
        public DbSet<EstrategiaMes> EstrategiaMes { get; set; }

        public DbSet<Estrategias> Estrategias { get; set; }

        public DbSet<Inversiones> Inversiones { get; set; }

        public DbSet<Movimientos> Movimientos { get; set; }

        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
