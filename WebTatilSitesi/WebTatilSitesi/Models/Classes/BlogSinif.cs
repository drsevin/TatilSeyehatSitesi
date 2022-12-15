using System.ComponentModel.DataAnnotations;

namespace WebTatilSitesi.Models.Classes
{
	public class BlogSinif
	{
		[Key]
		public int ID { get; set; }
		public string? AnaBaslik { get; set; }	
		public string? Aciklama { get; set; }
		public string? BlogGorsel { get; set; }
		public DateTime Tarih { get; set; }

	}
}
