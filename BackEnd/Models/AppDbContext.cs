using Microsoft.EntityFrameworkCore;
using ProyectoGastosAPI.Models;

namespace ProyectoGastosAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Gasto> Gastos { get; set; }
    }
}
