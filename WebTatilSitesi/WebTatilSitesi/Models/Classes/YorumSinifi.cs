using System.ComponentModel.DataAnnotations;

namespace WebTatilSitesi.Models.Classes
{
	public class YorumSinifi
	{
		[Key]
		public int ID { get; set; }
		public string? KullaniciAdi { get; set; }
		public string? Mail { get; set; }
		public string? Yorum { get; set; }
		public int Blogid { get; set; }
		public virtual BlogSinifi? Blog { get; set; }

	}
}
