using Microsoft.EntityFrameworkCore;
using PatioMulasApp.Models;

namespace PatioMulasApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Unidad> Unidades { get; set; }

        public DbSet<Conductor> Conductores { get; set; }

        public DbSet<Movimiento> Movimientos { get; set; }
    }
}