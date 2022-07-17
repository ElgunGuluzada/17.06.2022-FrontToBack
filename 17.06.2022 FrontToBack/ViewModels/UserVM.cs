using _17._06._2022_FrontToBack.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace _17._06._2022_FrontToBack.ViewModels
{
    public class UserVM
    {
        public List<AppUser> Users { get; set; }
        public IList<string> userRoles { get; set; }
    }
}
