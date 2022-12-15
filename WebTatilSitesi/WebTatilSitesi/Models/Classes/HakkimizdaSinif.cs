using System.ComponentModel.DataAnnotations;

namespace WebTatilSitesi.Models.Classes
{
	public class HakkimizdaSinif
	{
		[Key]
		public int ID { get; set; }
		public string? GorselUrl { get; set; }
		public string? Aciklama { get; set; }
	}
}
