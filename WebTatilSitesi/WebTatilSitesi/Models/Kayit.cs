using System.ComponentModel.DataAnnotations;

namespace WebTatilSitesi.Models
{
    public class Kayit
    {
        [Required]
        public string? Ad { get; set; }
        [Required]

        public string? Soyad { get; set; }

        [Required]

        public string? Mail { get; set; }

        [Required]
        [DataType(DataType.Password)]

        public string? Sifre { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Sifre")]
        public string? SifreTekrar { get; set; }
    }
}
