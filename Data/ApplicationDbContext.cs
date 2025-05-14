using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DSD603VM2025.Models;

namespace DSD603VM2025.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DSD603VM2025.Models.StaffNames> StaffNames { get; set; } = default!;
        public DbSet<DSD603VM2025.Models.Visitors> Visitors { get; set; } = default!;
    }
}
