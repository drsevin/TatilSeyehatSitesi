using System.ComponentModel.DataAnnotations;

namespace WebTatilSitesi.Models.Classes
{
	public class AnaSayfa
	{
		[Key]
		public int ID { get; set; }
		public string? AnaBaslik { get; set; }
		public string? Aciklama { get; set; }
	}
}
