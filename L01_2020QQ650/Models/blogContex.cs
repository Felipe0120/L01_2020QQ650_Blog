using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace L01_2020QQ650.Models
{
    public class blogContex : DbContext
    {
        public blogContex(DbContextOptions<blogContex> options) : base(options) 
        {

        }
        public DbSet<usuarios> usuarios { get; set; }
    }
}
