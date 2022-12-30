using System.ComponentModel.DataAnnotations;

namespace WebTatilSitesi.Models
{
    public class Giris
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Mail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Sifre { get; set; }
    }
}
