using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Olimp.Models;

namespace Olimp.Migrations
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
        

        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketStoreWarehouse> BasketStoreWarehouses { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStoreWarehouses> OrderStoreWarehouses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<StoreWarehouse> StoreWarehouses { get; set; }
    }
}