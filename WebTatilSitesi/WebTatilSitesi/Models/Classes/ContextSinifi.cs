using Microsoft.EntityFrameworkCore;


namespace WebTatilSitesi.Models.Classes
{
	public class ContextSinifi: DbContext
	{
		public DbSet<AdminSinifi> AdminSinifis { get; set; }
		public DbSet<AdresSinifi> AdresSinifis { get; set; }
		public DbSet<BlogSinif> BlogSinifs { get; set; }
		public DbSet<HakkimizdaSinif> HakkimizdaSinifs { get; set; }
		public DbSet<Iletisim> Iletisims { get; set; }
		public DbSet<YorumSinifi> YorumSinifis { get; set; }
	}
}
