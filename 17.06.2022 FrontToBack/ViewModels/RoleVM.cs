using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace _17._06._2022_FrontToBack.ViewModels
{
    public class RoleVM
    {
        public string FullName { get; set; }
        public List<IdentityRole> roles { get; set; }
        public IList<string> userRoles { get; set; }
        public string UserId { get; set; }
    }
}
