using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using WebTatilSitesi.Areas.Identity;

namespace WebTatilSitesi.Models
{
    public class RoleModel
    {
        [Required]
        public string Name { get; set; }
    }
    class RoleDetails
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<User> Members { get; set; }
        public IEnumerable<User> NonMembers { get; set; }
    }
    public class RoleEditModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string[] IdsToAdd { get; set; }
        public string[] IdsToDelete { get;}
    }
}
