using FoodTekEF.Entities;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace FoodTekEF.Context
{
    public class FoodTekDbContext: DbContext
    {
        public FoodTekDbContext(DbContextOptions options) : base(options)
        { 
        
        }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ClientLocation> ClientLocations { get; set; }
        public DbSet<Clientdeteile> Clientdeteiles { get; set; }
        public DbSet<DiscountCategory> DiscountCategories { get; set; }
        public DbSet<DiscountsOffer> DiscountsOffers { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemOption> ItemOptions { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Otp> Otps { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
