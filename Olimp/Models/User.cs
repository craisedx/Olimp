using Microsoft.AspNetCore.Identity;

namespace Olimp.Models
{
    public class User : IdentityUser
    {
        public string UserImage { get; set; }
    }
}