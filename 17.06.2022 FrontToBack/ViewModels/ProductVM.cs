using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _17._06._2022_FrontToBack.Models
{
    public class ProductVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Don't be Empty!"), MinLength(3, ErrorMessage = "Min: 3 character"), MaxLength(30, ErrorMessage = "MaxLength: 30 character")]
        public string Name { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Please, Write Product Price")]
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required(ErrorMessage = "Please, Write Product Count")]
        public int Count { get; set; }
    }
}
