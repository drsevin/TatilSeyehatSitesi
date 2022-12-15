using System.ComponentModel.DataAnnotations;

namespace WebTatilSitesi.Models.Classes
{
	public class Iletisim
	{
		[Key]
		public int ID { get; set; }
		public string? AdiSoyadi { get; set; }
		public string? Mesaj { get; set; }
		public string? Mail { get; set; }
		public string? Konu { get; set; }
		


	}
}
