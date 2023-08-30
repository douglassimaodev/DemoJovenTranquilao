using DemoJovenTranquilao.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoJovenTranquilao.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Client> Clienties { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
    }
}
