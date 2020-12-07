using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pizza.Models;
using Microsoft.AspNetCore.Identity;

namespace Pizza.Database
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Pizza.Models.Pizza> Pizzas { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderPizza> OrderPizzas { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Cascade;
            }

            modelBuilder.Entity<OrderPizza>()
               .HasKey(b => b.Id);

            modelBuilder.Entity<OrderPizza>()
                .HasOne(sc => sc.Order)
                .WithMany(s => s.Pizzas)
                .HasForeignKey(sc => sc.OrderId);

            modelBuilder.Entity<OrderPizza>()
                .HasOne(sc => sc.Pizza)
                .WithMany(s => s.Orders)
                .HasForeignKey(sc => sc.PizzaId);


            modelBuilder.Entity<Pizza.Models.Pizza>()
                .HasMany(pizza => pizza.Prices)
                .WithOne(price => price.Pizza);

            modelBuilder.Entity<Pizza.Models.Pizza>()
                .HasMany(pizza => pizza.Prices)
                .WithOne(price => price.Pizza)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

    }

}
