using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace _17._06._2022_FrontToBack.Models

{
    public class AppUser : IdentityUser
    {
        public string Fullname { get; set; }
        public DateTime UserCreateTime { get; set; }
        public DateTime ConfirmMailTime { get; set; }

        public List<Sale> Sales { get; set; }
    }
}
