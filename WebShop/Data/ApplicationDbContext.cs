using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebShop.Models;

namespace WebShop.Data
{
    


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().HasData
                (

                    new Product
                    {
                        Id = 1,
                        ProductName = "Test Product 1",
                        ProductDescription = "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.",
                        Price = 1M,
                        Quantity = 1M,
                        ProductImage = "product1.jpeg",
                    },
                    new Product
                    {
                        Id = 2,
                        ProductName = "Test Product 2",
                        ProductDescription = "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.",
                        Price = 2M,
                        Quantity = 2M,
                        ProductImage = "product2.jpeg"
                    },
                    new Product
                    {
                        Id = 3,
                        ProductName = "Test Product 3",
                        ProductDescription = "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.",
                        Price = 3M,
                        Quantity = 3M,
                        ProductImage = "product3.jpeg",
                    },
                    new Product
                    {
                        Id = 4,
                        ProductName = "Test Product 4",
                        ProductDescription = "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.",
                        Price = 4M,
                        Quantity = 4M,
                        ProductImage = "product4.jpeg",
                    },
                    new Product
                    {
                        Id = 5,
                        ProductName = "Test Product 5",
                        ProductDescription = "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.",
                        Price = 5M,
                        Quantity = 5M,
                        ProductImage = "product5.jpeg"
                    },
                    new Product
                    {
                        Id = 6,
                        ProductName = "Test Product 6",
                        ProductDescription = "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.",
                        Price = 6M,
                        Quantity = 6M,
                        ProductImage = "product6.jpeg",
                    },
                    new Product
                    {
                        Id = 7,
                        ProductName = "Test Product 7",
                        ProductDescription = "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.",
                        Price = 7M,
                        Quantity = 7M,
                        ProductImage = "product7.jpeg",
                    },
                    new Product
                    {
                        Id = 8,
                        ProductName = "Test Product 8",
                        ProductDescription = "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.",
                        Price = 8M,
                        Quantity = 8M,
                        ProductImage = "product8.jpeg",
                    },
                    new Product
                    {
                        Id = 9,
                        ProductName = "Test Product 9",
                        ProductDescription = "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.",
                        Price = 9M,
                        Quantity = 9M,
                        ProductImage = "product9.jpeg",
                    },
                    new Product
                    {
                        Id = 10,
                        ProductName = "Test Product 10",
                        ProductDescription = "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.",
                        Price = 10M,
                        Quantity = 10M,
                        ProductImage = "product10.jpeg",
                    },
                    new Product
                    {
                        Id = 11,
                        ProductName = "Test Product 11",
                        ProductDescription = "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.",
                        Price = 11M,
                        Quantity = 11M,
                        ProductImage = "product11.jpeg",
                    },
                    new Product
                    {
                        Id = 12,
                        ProductName = "Test Product 12",
                        ProductDescription = "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.",
                        Price = 12M,
                        Quantity = 12M,
                        ProductImage = "product12.jpeg",
                    },
                    new Product
                    {
                        Id = 13,
                        ProductName = "Test Product 13",
                        ProductDescription = "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.",
                        Price = 13M,
                        Quantity = 13M,
                        ProductImage = "product13.jpeg",
                    },
                    new Product
                    {
                        Id = 14,
                        ProductName = "Test Product 14",
                        ProductDescription = "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.",
                        Price = 14M,
                        Quantity = 14M,
                        ProductImage = "product14.jpeg",
                    },
                    new Product
                    {
                        Id = 15,
                        ProductName = "Test Product 15",
                        ProductDescription = "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.",
                        Price = 15M,
                        Quantity = 15M,
                        ProductImage = "product15.jpeg",
                    },
                    new Product
                    {
                        Id = 16,
                        ProductName = "Test Product 16",
                        ProductDescription = "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.",
                        Price = 16M,
                        Quantity = 16M,
                        ProductImage = "product16.jpeg",
                    },
                    new Product
                    {
                        Id = 17,
                        ProductName = "Test Product 17",
                        ProductDescription = "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.",
                        Price = 17M,
                        Quantity = 17M,
                        ProductImage = "product17.jpeg",
                    },
                    new Product
                    {
                        Id = 18,
                        ProductName = "Test Product 18",
                        ProductDescription = "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.",
                        Price = 18M,
                        Quantity = 18M,
                        ProductImage = "product18.jpeg",
                    },
                    new Product
                    {
                        Id = 19,
                        ProductName = "Test Product 19",
                        ProductDescription = "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.",
                        Price = 19M,
                        Quantity = 19M,
                        ProductImage = "product19.jpeg",
                    },
                    new Product
                    {
                        Id = 20,
                        ProductName = "Test Product 20",
                        ProductDescription = "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.",
                        Price = 20M,
                        Quantity = 20M,
                        ProductImage = "product20.jpeg",
                    }
                    );

            builder.Entity<Category>().HasData
                (
                new Category
                {
                    Id = 1,
                    CategoryName = "Test Category 1",
                    CategoryDescription = "Lorem ipsum dolor sit amet. Non earum optio et quibusdam dolor aut modi possimus aut autem facere ea possimus eius et voluptatibus suscipit. ",
                    CategoryImage = "category1.jpeg"
                },
                new Category
                {
                    Id = 2,
                    CategoryName = "Test Category 2",
                    CategoryDescription = "Lorem ipsum dolor sit amet. Non earum optio et quibusdam dolor aut modi possimus aut autem facere ea possimus eius et voluptatibus suscipit. ",
                    CategoryImage = "category2.jpeg"
                },
                new Category
                {
                    Id = 3,
                    CategoryName = "Test Category 3",
                    CategoryDescription = "Lorem ipsum dolor sit amet. Non earum optio et quibusdam dolor aut modi possimus aut autem facere ea possimus eius et voluptatibus suscipit. ",
                    CategoryImage = "category3.jpeg"
                },
                new Category
                {
                    Id = 4,
                    CategoryName = "Test Category 4",
                    CategoryDescription = "Lorem ipsum dolor sit amet. Non earum optio et quibusdam dolor aut modi possimus aut autem facere ea possimus eius et voluptatibus suscipit. ",
                    CategoryImage = "category4.jpeg"
                },
                new Category
                {
                    Id = 5,
                    CategoryName = "Test Category 5",
                    CategoryDescription = "Lorem ipsum dolor sit amet. Non earum optio et quibusdam dolor aut modi possimus aut autem facere ea possimus eius et voluptatibus suscipit. ",
                    CategoryImage = "category5.jpeg"
                },
                new Category
                {
                    Id = 6,
                    CategoryName = "Test Category 6",
                    CategoryDescription = "Lorem ipsum dolor sit amet. Non earum optio et quibusdam dolor aut modi possimus aut autem facere ea possimus eius et voluptatibus suscipit. ",
                    CategoryImage = "category6.jpeg"
                },
                new Category
                {
                    Id = 7,
                    CategoryName = "Test Category 7",
                    CategoryDescription = "Lorem ipsum dolor sit amet. Non earum optio et quibusdam dolor aut modi possimus aut autem facere ea possimus eius et voluptatibus suscipit. ",
                    CategoryImage = "category7.jpeg"
                },
                new Category
                {
                    Id = 8,
                    CategoryName = "Test Category 8",
                    CategoryDescription = "Lorem ipsum dolor sit amet. Non earum optio et quibusdam dolor aut modi possimus aut autem facere ea possimus eius et voluptatibus suscipit. ",
                    CategoryImage = "category8.jpeg"
                },
                new Category
                {
                    Id = 9,
                    CategoryName = "Test Category 9",
                    CategoryDescription = "Lorem ipsum dolor sit amet. Non earum optio et quibusdam dolor aut modi possimus aut autem facere ea possimus eius et voluptatibus suscipit. ",
                    CategoryImage = "category9.jpeg"
                },
                new Category
                {
                    Id = 10,
                    CategoryName = "Test Category 10",
                    CategoryDescription = "Lorem ipsum dolor sit amet. Non earum optio et quibusdam dolor aut modi possimus aut autem facere ea possimus eius et voluptatibus suscipit. ",
                    CategoryImage = "category10.jpeg"
                }
                );

            builder.Entity<ProductCategory>().HasData
                (

            new ProductCategory
            {
                Id = 1,
                ProductId = 1,
                CategoryId = 1,
            },
                new ProductCategory
                {
                    Id = 2,
                    ProductId = 2,
                    CategoryId = 2,
                },
                new ProductCategory
                {
                    Id = 3,
                    ProductId = 3,
                    CategoryId = 3,
                },
                new ProductCategory
                {
                    Id = 4,
                    ProductId = 4,
                    CategoryId = 4,
                },
                new ProductCategory
                {
                    Id = 5,
                    ProductId = 5,
                    CategoryId = 5,
                },
                new ProductCategory
                {
                    Id = 6,
                    ProductId = 6,
                    CategoryId = 6,
                },
                new ProductCategory
                {
                    Id = 7,
                    ProductId = 7,
                    CategoryId = 7,
                },
                new ProductCategory
                {
                    Id = 8,
                    ProductId = 8,
                    CategoryId = 8,
                },
                new ProductCategory
                {
                    Id = 9,
                    ProductId = 9,
                    CategoryId = 9,
                },
                new ProductCategory
                {
                    Id = 10,
                    ProductId = 10,
                    CategoryId = 10,
                },
                new ProductCategory
                {
                    Id = 11,
                    ProductId = 11,
                    CategoryId = 1,
                },
                new ProductCategory
                {
                    Id = 12,
                    ProductId = 12,
                    CategoryId = 2,
                },
                new ProductCategory
                {
                    Id = 13,
                    ProductId = 13,
                    CategoryId = 3,
                },
                new ProductCategory
                {
                    Id = 14,
                    ProductId = 14,
                    CategoryId = 4,
                },
                new ProductCategory
                {
                    Id = 15,
                    ProductId = 15,
                    CategoryId = 5,
                },
                new ProductCategory
                {
                    Id = 16,
                    ProductId = 16,
                    CategoryId = 6,
                },
                new ProductCategory
                {
                    Id = 17,
                    ProductId = 17,
                    CategoryId = 7,
                },
                new ProductCategory
                {
                    Id = 18,
                    ProductId = 18,
                    CategoryId = 8,
                },
                new ProductCategory
                {
                    Id = 19,
                    ProductId = 19,
                    CategoryId = 9,
                },
                new ProductCategory
                {
                    Id = 20,
                    ProductId = 20,
                    CategoryId = 10,
                }



                );
            base.OnModelCreating(builder);
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }

    }
}