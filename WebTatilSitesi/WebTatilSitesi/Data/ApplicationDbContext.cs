using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebTatilSitesi.Areas.Identity;
using WebTatilSitesi.Models.Classes;

namespace WebTatilSitesi.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebTatilSitesi.Models.Classes.BlogSinifi> BlogSinifi { get; set; } = default!;

        
    }
}