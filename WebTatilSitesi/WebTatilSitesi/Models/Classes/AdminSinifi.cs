using System.ComponentModel.DataAnnotations;

namespace WebTatilSitesi.Models.Classes
{
	public class AdminSinifi
	{
		[Key]
		public int ID { get; set; }
		public string? Kullanici { get; set; }
		public string? Sifre { get; set; }
	}
}
