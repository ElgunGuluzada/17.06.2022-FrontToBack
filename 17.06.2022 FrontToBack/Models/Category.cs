using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _17._06._2022_FrontToBack.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Don't be Empty!"), MinLength(3, ErrorMessage = "Min: 3 character"),MaxLength(30,ErrorMessage ="MaxLength: 30 character")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Don't be Empty"), MaxLength(150)]
        public string Description { get; set; }
        public List<Product>  Products{ get; set; }
    }
}
