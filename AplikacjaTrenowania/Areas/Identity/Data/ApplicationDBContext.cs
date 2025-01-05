using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AplikacjaTrenowania.Models;

namespace AplikacjaTrenowania.Areas.Identity.Data;

public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
    {
    }
    public DbSet<Trening> Trening { get; set; }
    public DbSet<Seria> Seria { get; set; }
}