using Microsoft.EntityFrameworkCore;
using PieShop.API.Entities;

namespace PieShop.API.Data
{
    public class PieShopDbContext : DbContext
    {
        public DbSet<Pie> Pies { get; set; }

        public PieShopDbContext(DbContextOptions<PieShopDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pie>()
                .HasData(

                    new Pie
                    {
                        Id = Guid.Parse("{70822596-265D-49E3-8CCC-CD996093E601}"),
                        InStock = true,
                        ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/applepiesmall.jpg",
                        Name = "Apple Pie",
                        Price = 15.95,
                        PurchasePrice = 9.5,
                        Description = "Our famous apple pies!"
                    },
                    new Pie
                    {
                        Id = Guid.Parse("{11DB10F5-C461-490F-A7A3-5BA5AF3A58AF}"),
                        InStock = true,
                        ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/blueberrycheesecakesmall.jpg",
                        Name = "Blueberry cheese cake",
                        Price = 18.95,
                        PurchasePrice = 11.95,
                        Description = "You'll love it!"
                    },
                    new Pie
                    {
                        Id = Guid.Parse("{0AC44F1C-84FB-4BCC-8E1F-49FCC8F2A17C}"),
                        InStock = true,
                        ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cheesecakesmall.jpg",
                        Name = "Cheese cake",
                        Price = 12.95,
                        PurchasePrice = 7.5,
                        Description = "Plain cheese cake. Plain pleasure."
                    },

                    new Pie
                    {
                        Id = Guid.Parse("{71A9453F-7A6B-40AC-9D66-E659296EF128}"),
                        InStock = true,
                        ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cherrypiesmall.jpg",
                        Name = "Cherry pie",
                        Price = 15.95,
                        PurchasePrice = 9.5,
                        Description = "A summer classic!"
                    },
                    new Pie
                    {
                        Id = Guid.Parse("{27629373-72AA-40CC-9819-993440356585}"),
                        InStock = true,
                        ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/christmasapplepiesmall.jpg",
                        Name = "Christmas apple pie",
                        Price = 12.95,
                        PurchasePrice = 6.5,
                        Description = "Happy holidays with this pie!"
                    },
                    new Pie
                    {
                        Id = Guid.Parse("{27629374-72AA-40CC-9819-993440356585}"),
                        InStock = true,
                        ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/peachpiesmall.jpg",
                        Name = "Peach pie",
                        Price = 12.95,
                        PurchasePrice = 6.5,
                        Description = "Sweet as peach!"
                    },
                    new Pie
                    {
                        Id = Guid.Parse("{FAA549E9-F940-4A2D-B5FE-93D3A9EDBCE7}"),
                        InStock = true,
                        ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/pumpkinpiesmall.jpg",
                        Name = "Pumpkin Pie",
                        Price = 12.95,
                        PurchasePrice = 6.5,
                        Description = "Our Halloween favorite"
                    },

                    new Pie
                    {
                        Id = Guid.Parse("{CAA2A5D5-99D4-423C-B1F3-1B0E48C483C3}"),
                        InStock = true,
                        ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cranberrypiesmall.jpg",
                        Name = "Cranberry pie",
                        Price = 12.95,
                        PurchasePrice = 6.5,
                        Description = "A Christmas favorite"
                    },
                    new Pie
                    {
                        Id = Guid.Parse("{27529374-72AA-40CC-9819-993440356582}"),
                        InStock = true,
                        ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/rhubarbpiesmall.jpg",
                        Name = "Rhubarb pie",
                        Price = 12.95,
                        PurchasePrice = 6.5,
                        Description = "My God, so sweet!"
                    },
                    new Pie
                    {
                        Id = Guid.Parse("{C956B141-3FC7-4176-9FED-A726A9EB47FA}"),
                        InStock = true,
                        ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/strawberrycheesecakesmall.jpg",
                        Name = "Strawberry cheese cake",
                        Price = 12.95,
                        PurchasePrice = 6.5,
                        Description = "You'll love it!"
                    },
                    new Pie
                    {
                        Id = Guid.Parse("{8C9AC766-BC2F-40F0-ACB1-B0AD6157C07B}"),
                        InStock = true,
                        ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/strawberrypiesmall.jpg",
                        Name = "Strawberry pie",
                        Price = 12.95,
                        PurchasePrice = 7.5,
                        Description = "Our delicious strawberry pie!"
                    }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}