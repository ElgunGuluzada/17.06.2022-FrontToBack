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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<AboutContent> AboutContent { get; set; }
        public DbSet<Expert> Expert { get; set; }
        public DbSet<ExpertInfo> ExpertsInfo { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<BlogContent> BlogsContent { get; set; }
        public DbSet<Instagram> Instagram { get; set; }
        public DbSet<Bio> Bios { get; set; }

    }
}
