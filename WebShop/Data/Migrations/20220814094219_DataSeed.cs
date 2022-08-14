using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShop.Data.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CategoryDescription", "CategoryImage", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet. Non earum optio et quibusdam dolor aut modi possimus aut autem facere ea possimus eius et voluptatibus suscipit. ", "category1.jpg", "Test Category 1" },
                    { 2, "Lorem ipsum dolor sit amet. Non earum optio et quibusdam dolor aut modi possimus aut autem facere ea possimus eius et voluptatibus suscipit. ", "category2.jpg", "Test Category 2" },
                    { 3, "Lorem ipsum dolor sit amet. Non earum optio et quibusdam dolor aut modi possimus aut autem facere ea possimus eius et voluptatibus suscipit. ", "category3.jpg", "Test Category 3" },
                    { 4, "Lorem ipsum dolor sit amet. Non earum optio et quibusdam dolor aut modi possimus aut autem facere ea possimus eius et voluptatibus suscipit. ", "category4.jpg", "Test Category 4" },
                    { 5, "Lorem ipsum dolor sit amet. Non earum optio et quibusdam dolor aut modi possimus aut autem facere ea possimus eius et voluptatibus suscipit. ", "category5.jpg", "Test Category 5" },
                    { 6, "Lorem ipsum dolor sit amet. Non earum optio et quibusdam dolor aut modi possimus aut autem facere ea possimus eius et voluptatibus suscipit. ", "category6.jpg", "Test Category 6" },
                    { 7, "Lorem ipsum dolor sit amet. Non earum optio et quibusdam dolor aut modi possimus aut autem facere ea possimus eius et voluptatibus suscipit. ", "category7.jpg", "Test Category 7" },
                    { 8, "Lorem ipsum dolor sit amet. Non earum optio et quibusdam dolor aut modi possimus aut autem facere ea possimus eius et voluptatibus suscipit. ", "category8.jpg", "Test Category 8" },
                    { 9, "Lorem ipsum dolor sit amet. Non earum optio et quibusdam dolor aut modi possimus aut autem facere ea possimus eius et voluptatibus suscipit. ", "category9.jpg", "Test Category 9" },
                    { 10, "Lorem ipsum dolor sit amet. Non earum optio et quibusdam dolor aut modi possimus aut autem facere ea possimus eius et voluptatibus suscipit. ", "category10.jpg", "Test Category 10" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Price", "ProductDescription", "ProductImage", "ProductName", "Quantity" },
                values: new object[,]
                {
                    { 1, 1m, "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.", "product1.jpg", "Test Product 1", 1m },
                    { 2, 2m, "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.", "product2.jpg", "Test Product 2", 2m },
                    { 3, 3m, "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.", "product3.jpg", "Test Product 3", 3m },
                    { 4, 4m, "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.", "product4.jpg", "Test Product 4", 4m },
                    { 5, 5m, "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.", "product5.jpg", "Test Product 5", 5m },
                    { 6, 6m, "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.", "product6.jpg", "Test Product 6", 6m },
                    { 7, 7m, "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.", "product7.jpg", "Test Product 7", 7m },
                    { 8, 8m, "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.", "product8.jpg", "Test Product 8", 8m },
                    { 9, 9m, "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.", "product9.jpg", "Test Product 9", 9m },
                    { 10, 10m, "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.", "product10.jpg", "Test Product 10", 10m },
                    { 11, 11m, "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.", "product11.jpg", "Test Product 11", 11m },
                    { 12, 12m, "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.", "product12.jpg", "Test Product 12", 12m },
                    { 13, 13m, "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.", "product13.jpg", "Test Product 13", 13m },
                    { 14, 14m, "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.", "product14.jpg", "Test Product 14", 14m },
                    { 15, 15m, "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.", "product15.jpg", "Test Product 15", 15m },
                    { 16, 16m, "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.", "product16.jpg", "Test Product 16", 16m },
                    { 17, 17m, "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.", "product17.jpg", "Test Product 17", 17m },
                    { 18, 18m, "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.", "product18.jpg", "Test Product 18", 18m },
                    { 19, 19m, "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.", "product19.jpg", "Test Product 19", 19m },
                    { 20, 20m, "Lorem ipsum dolor sit amet. Tenetur sint cum doloremque saepe vel eius ullam et minima nihil sit harum delectus et quas reiciendis aut voluptatibus dolore.", "product20.jpg", "Test Product 20", 20m }
                });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "Id", "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 5 },
                    { 6, 6, 6 },
                    { 7, 7, 7 },
                    { 8, 8, 8 },
                    { 9, 9, 9 },
                    { 10, 10, 10 },
                    { 11, 1, 11 },
                    { 12, 2, 12 },
                    { 13, 3, 13 },
                    { 14, 4, 14 },
                    { 15, 5, 15 },
                    { 16, 6, 16 },
                    { 17, 7, 17 },
                    { 18, 8, 18 },
                    { 19, 9, 19 },
                    { 20, 10, 20 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
