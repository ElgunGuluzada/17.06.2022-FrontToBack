using System.Collections.Generic;

namespace _17._06._2022_FrontToBack.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product>  Products{ get; set; }
    }
}
