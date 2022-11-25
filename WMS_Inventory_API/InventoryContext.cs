using WMS_Inventory_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace WMS_Inventory_API
{
    public class InventoryContext : DbContext
    {
        public DbSet<Account>? Account { get; set; }
        public DbSet<StorageLocation>? StorageLocation { get; set; }
        public DbSet<Container>? Container { get; set; }
        public DbSet<Content>? Content { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            var connectionString = "Server=localhost,1433;Database=InventoryAPI;user=sa;pwd=jk$19550829";
            // var connectionString = "Server=(localdb)\\mssqllocaldb;Database=InventoryAPI;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Account>().HasData(
                new Account() { Id = 1, Name = "Charles Baker", Address1 = "5814 N 17th St", Address2 = "", City = "Tampa", State = "FL", ZipCode = 33610, Email = "charles.baker@gmail.com", Password = "password"});

            model.Entity<StorageLocation>().HasData(
                new StorageLocation() { Id = 1, LocationName = "Home Shop", Address1 = "5814 N 17th St", Address2 = "", City = "Tampa", State = "FL", ZipCode = 33610, Longitude = 27.995778, Latitude = -82.440322, AccountId = 1 },
                new StorageLocation() { Id = 2, LocationName = "Extra Space Storage", Address1 = "1711 E Hillsborough Ave", Address2 = "", City = "Tampa", State = "FL", ZipCode = 33610, Longitude = 28.000687, Latitude = -82.441528, AccountId = 1 });


            model.Entity<Container>().HasData(
                new Container() { Id = 1, Type = "Box", Description = "Brown corrugated box containing hand tools", StorageLocationId = 2 },
                new Container() { Id = 2, Type = "Tote", Description = "Clear plastic w/ blue lid - metal fasteners", StorageLocationId = 2 },
                new Container() { Id = 3, Type = "Chest", Description = "Blue painted wooden chest - fishing tackle", StorageLocationId = 1 },
                new Container() { Id = 4, Type = "Cabinet", Description = "Far left cabinet under built in work bench", StorageLocationId = 1 });

            model.Entity<Content>().HasData(
                new Content() { Id = 1, Quantity = 1, Description = "5 lbs box 2 inch cut nails", ContainerId = 1 },
                new Content() { Id = 2, Quantity = 3, Description = "1 lbs box 2 1/2 in cut nails", ContainerId = 1 },
                new Content() { Id = 3, Quantity = 6, Description = "Misc boxes of cut nails - finish, box, brad", ContainerId = 1 },
                new Content() { Id = 4, Quantity = 4, Description = "Misc boxes wood screws, brass/bronze, #8/9, 3/4 in - 1 1/2 in", ContainerId = 1 },
                new Content() { Id = 5, Quantity = 25, Description = "Mom's winter clothes - slacks, tops, sweaters", ContainerId = 2 },
                new Content() { Id = 6, Quantity = 1, Description = "Box of fly reels - Berkley, Ross, Pflueger", ContainerId = 3 },
                new Content() { Id = 7, Quantity = 1, Description = "Leonard 37H flyrod", ContainerId = 3 },
                new Content() { Id = 8, Quantity = 1, Description = "Orvis Fullflex fly/spin rod", ContainerId = 3 },
                new Content() { Id = 9, Quantity = 1, Description = "Box of spinning reels - Shakespeare, Micron, Mitchell", ContainerId = 3 },
                new Content() { Id = 10, Quantity = 1, Description = "Makita 7 1/4 in track saw", ContainerId = 4 },
                new Content() { Id = 11, Quantity = 1, Description = "Parallel guides for Makita track", ContainerId = 4 },
                new Content() { Id = 12, Quantity = 1, Description = "Makita 10 in circular saw", ContainerId = 4 },
                new Content() { Id = 13, Quantity = 1, Description = "Skilsaw 5 1/2 in circular saw", ContainerId = 4 },
                new Content() { Id = 14, Quantity = 3, Description = "Ryobi One+ tools - 1/2 in drill, finish sander, brad nailer", ContainerId = 4 },
                new Content() { Id = 15, Quantity = 1, Description = "Milwaukee 7 1/4 in circular saw", ContainerId = 4 });

            base.OnModelCreating(model);
        }
    }

}

