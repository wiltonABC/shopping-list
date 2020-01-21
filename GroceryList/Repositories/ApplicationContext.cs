using GroceryList.Models;
using Microsoft.EntityFrameworkCore;

namespace GroceryList.Repositories
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasKey(t => t.Id);
            
            modelBuilder.Entity<Product>().HasKey(t => t.Id);
            modelBuilder.Entity<Product>().HasOne(t => t.Category)
                .WithMany(t => t.Products).HasForeignKey(t => t.CategoryId)
                .IsRequired().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Product>().Property(p => p.CreationDate)
                .HasDefaultValueSql("getdate()").IsRequired();

            modelBuilder.Entity<ShoppingList>().HasKey(t => t.Id);
            modelBuilder.Entity<ShoppingList>().HasMany(t => t.Items)
                .WithOne(t => t.ShoppingList);
            modelBuilder.Entity<ShoppingList>().Property(p => p.CreationDate)
                .HasDefaultValueSql("getdate()").IsRequired();

            modelBuilder.Entity<ListItem>().HasKey(t => t.Id);
            modelBuilder.Entity<ListItem>().HasOne(t => t.ShoppingList)
                .WithMany(t => t.Items).IsRequired()
                .HasForeignKey(t => t.ShoppingListId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ListItem>().HasOne(t => t.Product)
                .WithMany(t => t.Items).IsRequired()
                .HasForeignKey(t => t.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
