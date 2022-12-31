using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace WebTatilSitesi.Models.Classes
{
    public class TatilDbContext : DbContext
    {
        public DbSet<AdminSinifi> AdminSinifis { get; set; }
        public DbSet<AdresSinifi> AdresSinifis { get; set; }
        public DbSet<AnaSayfa> AnaSayfas { get; set; }
        public DbSet<BlogSinifi> BlogSinifis { get; set; }
        public DbSet<HakkimizdaSinifi> HakkimizdaSinifis { get; set; }
        public DbSet<Iletisim> Iletisims { get; set; }
        public DbSet<YorumSinifi> YorumSinifis { get; set; }
        public DbSet<Kayit> Kayits { get; set; }
        public DbSet<Giris> Girises { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder
            optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
           Database=TatilSitesiDb;Trusted_Connection=True;");
        }
    }
}
