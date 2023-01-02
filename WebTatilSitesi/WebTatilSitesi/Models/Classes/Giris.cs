using System.ComponentModel.DataAnnotations;

namespace WebTatilSitesi.Models.Classes
{
    public class Giris
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Mail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Sifre { get; set; }
       
        
    }
}
