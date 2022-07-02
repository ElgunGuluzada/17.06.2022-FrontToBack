using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _17._06._2022_FrontToBack.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Don't Empty!"), MinLength(5, ErrorMessage = "Min: 3 character")]
        public string Name { get; set; }
        [Required, MaxLength(150)]
        public string Description { get; set; }
        public List<Product>  Products{ get; set; }
    }
}
