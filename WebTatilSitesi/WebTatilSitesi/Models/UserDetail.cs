using Microsoft.AspNetCore.Identity;

namespace WebTatilSitesi.Models
{
    public class UserDetail:IdentityUser
    {
        public string UserAd { get; set; }
        public string UserSoyad { get; set; }
    }
}
