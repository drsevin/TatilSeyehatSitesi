using System.ComponentModel.DataAnnotations;

namespace WebTatilSitesi.Models.Classes
{
	public class HakkimizdaSinifi
	{
		[Key]
		public int ID { get; set; }
		public string? GorselUrl { get; set; }

        [Display(Name = "Açıklama")]
        public string? Aciklama { get; set; }

    }
}
