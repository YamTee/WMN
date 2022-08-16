using Microsoft.EntityFrameworkCore;

namespace WMN.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext (DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
