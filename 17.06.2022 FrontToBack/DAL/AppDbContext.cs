using _17._06._2022_FrontToBack.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _17._06._2022_FrontToBack.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
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
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SalesProduct> SalesProducts { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
              new IdentityRole
              {
                  Id = "04673540-4499-4d5f-8f4d-96910ad750b6",
                  Name = "Member"
              },
              new IdentityRole
              {
                  Id = "05248ae5-b5a7-4738-b2c8-10a22a35a133",
                  Name = "Admin"
              },
              new IdentityRole
              {
                  Id = "72a18405-9054-48e1-867b-0a9731fd771c",
                  Name = "SuperAdmin"
              }
          );
            modelBuilder.Entity<About>().HasData(
                new About
                {
                    Id = 1,
                    VideoUrl= "h3 - video - img.jpg",
                    Title = "Suprise Your <span>Valentine!</span> Let us arrange a smile.",
                    Desc= "Where flowers are our inspiration to create lasting memories. Whatever the occasion..."
                }
          );
            modelBuilder.Entity<AboutContent>().HasData(
                new AboutContent 
                { 
                    Id= 1,
                    ImageUrl= "h1-custom-icon.png",
                    Desc = "Hand picked just for you.",
                },
                new AboutContent
                {
                    Id = 2,
                    ImageUrl = "h1-custom-icon.png",
                    Desc = "Unique flower arrangements",
                },
                new AboutContent
                {
                    Id = 3,
                    ImageUrl = "h1-custom-icon.png",
                    Desc = "Best way to say you care.",
                }
            );

            modelBuilder.Entity<Bio>().HasData(
                new Bio
                {
                    Id=1,
                    ImageUrl = "logo.png",
                    AuthorName= "Elgun Guluzada",
                    Linkedin= "www.linkedin.com",
                    Facebook= "www.facebook.com",
                }
            );
            modelBuilder.Entity<Blog>().HasData(
                new Blog
                {
                    Id =1,
                    Title= "From our Blog",
                    Desc = "A perfect blend of creativity, energy, communication, happiness and love.Let us arrange  a smile for you"
                }
            );
            modelBuilder.Entity<BlogContent>().HasData(
                new BlogContent
                {
                    Id=1,
                    ImageUrl= "blog-feature-img-1.jpg",
                    Date = "29.12.2019",
                    Title = "Flower Power",
                    Desc = "Class aptent taciti sociosqu ad litora torquent per conubia  nostra, per"
                },
                new BlogContent
                {
                    Id = 2,
                    ImageUrl = "blog-feature-img-3.jpg",
                    Date = "29.12.2019",
                    Title = "Local Florists",
                    Desc = "Class aptent taciti sociosqu ad litora torquent per conubia  nostra, per"
                },
                new BlogContent
                {
                    Id = 3,
                    ImageUrl = "blog-feature-img-1.jpg",
                    Date = "29.12.2019",
                    Title = "Flower Power",
                    Desc = "Class aptent taciti sociosqu ad litora torquent per conubia  nostra, per"
                }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id  = 1,
                    Name= "POPULAR",
                    Description= "They are Popular Flowers",
                },
                new Category
                {
                    Id = 2,
                    Name= "WINTER",
                    Description = "They are Winter's Flowers",
                }, 
                new Category
                {
                    Id = 3,
                    Name = "VARIOUS",
                    Description = "They are Various Flowers",
                },
                new Category
                {
                    Id = 4,
                    Name = "EXOTIC",
                    Description = "They are Exotic Flowers",
                },
                new Category
                {
                    Id = 5,
                    Name = "GREENS",
                    Description = "They are Green Flowers",
                },
                new Category
                {
                    Id = 6,
                    Name = "CACTUSES",
                    Description = "They are Cactuses",
                }
            );
            modelBuilder.Entity<Expert>().HasData(
                new Expert
                {
                    Id = 1,
                    Title = "Flower Experts",
                    Desc= "A perfect blend of creativity, energy, communication, happiness and love.Let us arrange a smile for you."
                }
            );
            modelBuilder.Entity<ExpertInfo>().HasData(
                new ExpertInfo
                {
                    Id= 1,
                    ImageUrl = "h3-team-img-1.png",
                    Name= "CRYSTAL BROOKS",
                    Position = "Florist",
                }, 
                new ExpertInfo
                {
                    Id = 2,
                    ImageUrl = "h3-team-img-2.png",
                    Name = "SHIRLEY HARRIS",
                    Position = "Manager",
                },
                new ExpertInfo 
                { 
                    Id = 3,
                    ImageUrl = "h3-team-img-3.png",
                    Name = "BEVERLY CLARK",
                    Position = "Florist",
                },
                new ExpertInfo
                {
                    Id = 4,
                    ImageUrl = "h3-team-img-4.png",
                    Name = "AMANDA WATKINS",
                    Position = "Florist",
                }
            );
            modelBuilder.Entity<Instagram>().HasData(
                new Instagram
                {
                    Id = 1,
                    ImageUrl = "instagram1.jpg",
                },
                new Instagram
                {
                    Id = 2,
                    ImageUrl = "instagram2.jpg",
                },
                new Instagram
                {
                    Id = 3,
                    ImageUrl = "instagram3.jpg",
                },
                new Instagram
                {
                    Id = 4,
                    ImageUrl = "instagram4.jpg",
                },
                new Instagram
                {
                    Id = 5,
                    ImageUrl = "instagram5.jpg",
                },
                new Instagram
                {
                    Id = 6,
                    ImageUrl = "instagram6.jpg",
                },
                new Instagram
                {
                    Id = 7,
                    ImageUrl = "instagram7.jpg",
                },
                new Instagram
                {
                    Id = 8,
                    ImageUrl = "instagram8.jpg",
                }
            );
            modelBuilder.Entity<Slider>().HasData(
                new Slider
                {
                    Id = 1,
                    ImageUrl = "h3-slider-background.jpg"
                },
                new Slider
                {
                    Id = 2,
                    ImageUrl = "h3-slider-background-2.jpg"
                },
                new Slider
                {
                    Id = 3,
                    ImageUrl = "h3-slider-background-3.jpg"
                }
            );
            modelBuilder.Entity<SliderContent>().HasData(
                new SliderContent
                {
                    Id  = 1,
                    Title = "Send <span>flowers</span> like you mean it",
                    Desc = "Where flowers are our inspiration to create lasting memories. Whatever the occasion, our flowers will make it special cursus a sit amet mauris.",
                    ImageUrl = "h2-sign-img.png"
                }
            );
        }

    }
}
