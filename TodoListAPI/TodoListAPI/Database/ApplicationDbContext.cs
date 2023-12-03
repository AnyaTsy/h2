using TodoListAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace TodoListAPI.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Device> Devices { get; set; }

        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
