using Microsoft.EntityFrameworkCore;
using UserManagementService.Models;

namespace UserManagementService.Data
{
    public class AuroraDbContext : DbContext
    {
        public AuroraDbContext(DbContextOptions<AuroraDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}