using _17._06._2022_FrontToBack.Models;
using System.Collections.Generic;

namespace _17._06._2022_FrontToBack.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public SliderContent SliderContent { get; set; }
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
    }
}
