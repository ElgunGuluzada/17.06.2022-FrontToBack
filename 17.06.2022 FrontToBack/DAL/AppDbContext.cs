using _17._06._2022_FrontToBack.Models;
using Microsoft.EntityFrameworkCore;

namespace _17._06._2022_FrontToBack.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderContent> SliderContents { get; set; }
    }
}
