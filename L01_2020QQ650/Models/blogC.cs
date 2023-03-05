using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace L01_2020QQ650.Models
{
    public class blogC : DbContext
    {
        public blogC(DbContextOptions<blogC> options) : base(options) 
        {

        }
        public DbSet<usuarios> usuarios { get; set; }
        public DbSet<calificaciones> calificaciones { get; set; }

        public DbSet<comentarios> comentarios { get; set; }
    }
}
