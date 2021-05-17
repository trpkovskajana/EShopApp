using EShop.Domain.Domain;
using EShop.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace EShop.Repository
{
    public class ApplicationDbContext : IdentityDbContext<EShopApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //ova e za kreiranjeto na tabelite vo data bazata
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCart { get; set; }
        public virtual DbSet<ProductInShoppingCart> ProductsInShoppingCart { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //-------- ova se fluent api --------------

            //ova e isto kako da stavam [Required] vo smata klasa
            //builder.Entity<Product>()
            //    .Property(x => x.Id)
            //    .IsRequired();

            builder.Entity<Product>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<ShoppingCart>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            //ova vaka za da go kreirame primary key za relacijata
            builder.Entity<ProductInShoppingCart>()
                .HasKey(x => new { x.ProductId, x.ShoppingCartId });

            // ova e many to many relacijata kako se povrzuva
            builder.Entity<ProductInShoppingCart>()
                .HasOne(x => x.product)
                .WithMany(x => x.products)
                .HasForeignKey(x => x.ShoppingCartId);

            builder.Entity<ProductInShoppingCart>()
                .HasOne(x => x.cart)
                .WithMany(x => x.products)
                .HasForeignKey(x => x.ProductId);

            // ova e za one to one relacijata megju korisnik i kosnicka
            builder.Entity<ShoppingCart>()
                .HasOne<EShopApplicationUser>(x => x.owner)
                .WithOne(x => x.UserCart)
                .HasForeignKey<ShoppingCart>(x => x.OwnerId);

            // sea pravime relacija za order so product\

            // prvo kompoziten kluc
            builder.Entity<ProductInOrder>()
                .HasKey(x => new { x.ProductId, x.OrderId });

            //pa many many relacija
            builder.Entity<ProductInOrder>()
                .HasOne(x => x.product)
                .WithMany(x => x.productsInOrders)
                .HasForeignKey(x => x.ProductId);

            builder.Entity<ProductInOrder>()
                .HasOne(x => x.order)
                .WithMany(x => x.products)
                .HasForeignKey(x => x.OrderId);
        }
    }
}
