using System.ComponentModel.DataAnnotations;

namespace WebTatilSitesi.Models.Classes
{
	public class AdresSinifi
	{
		[Key]
		public int ID { get; set; }
		public string? AnaBaslik { get; set; }
		public string? Aciklama { get; set; }
		public string? TelNum { get; set; }
		public string? Konum { get; set; }
		public string? AdresAcik { get; set; }
		public string? Mail { get; set; }

	}
		
		
}
