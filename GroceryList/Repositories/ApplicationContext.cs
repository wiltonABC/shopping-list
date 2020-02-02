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
            modelBuilder.Entity<Category>().HasMany(t => t.Products)
                .WithOne(t => t.Category);
            modelBuilder.Entity<Category>().HasMany(t => t.SupermarketCategories)
                .WithOne(t => t.Category);
            modelBuilder.Entity<Category>().Property(p => p.CreationDate)
                .HasDefaultValueSql("getdate()").IsRequired();

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
            modelBuilder.Entity<ListItem>().Property(p => p.CreationDate)
                .HasDefaultValueSql("getdate()").IsRequired();

            modelBuilder.Entity<Supermarket>().HasKey(t => t.Id);
            modelBuilder.Entity<Supermarket>()
                .HasMany(t => t.SupermarketCategories)
                .WithOne(t => t.Supermarket);
            modelBuilder.Entity<Supermarket>().Property(p => p.CreationDate)
                .HasDefaultValueSql("getdate()").IsRequired();

            modelBuilder.Entity<SupermarketCategories>().HasKey(t => t.Id);
            modelBuilder.Entity<SupermarketCategories>()
                .HasOne(t => t.Category)
                .WithMany(t => t.SupermarketCategories).IsRequired()
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<SupermarketCategories>()
                .HasOne(t => t.Supermarket)
                .WithMany(t => t.SupermarketCategories).IsRequired()
                .HasForeignKey(t => t.SupermarketId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<SupermarketCategories>().Property(p => p.CreationDate)
                .HasDefaultValueSql("getdate()").IsRequired();
        }
    }
}
