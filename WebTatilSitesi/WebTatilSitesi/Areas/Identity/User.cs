using Microsoft.AspNetCore.Identity;

namespace WebTatilSitesi.Areas.Identity
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
