using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace WebTatilSitesi.Models.Classes
{
	public class ContextSinifi: DbContext
	{
		public DbSet<AdminSinifi> AdminSinifis { get; set; }
		public DbSet<AdresSinifi> AdresSinifis { get; set; }
		public DbSet<AnaSayfa> AnaSayfas { get; set; }
		public DbSet<BlogSinifi> BlogSinifis { get; set; }
		public DbSet<HakkimizdaSinifi> HakkimizdaSinifis { get; set; }
		public DbSet<Iletisim> Iletisims { get; set; }
		public DbSet<YorumSinifi> YorumSinifis { get; set; }
	}
}
