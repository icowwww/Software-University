using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop.App
{
    public static class JsonManager
    {
        public const string UsersPath = "Filles/users.json";
        public const string CategoriesPath = "Filles/categories.json";
        public const string ProductsPath = "Filles/products.json";

        public static string ImportUsers()
        {
            var text = File.ReadAllText(UsersPath);
            var users = JsonConvert.DeserializeObject<User[]>(text);

            using (var context = new ProductShopContext())
            {
                context.Users.AddRange(users);
                context.SaveChanges();
            }

            return $"{users.Length} users added to database!";
        }

        public static string ImportCategories()
        {
            var text = File.ReadAllText(CategoriesPath);
            var categories = JsonConvert.DeserializeObject<Category[]>(text);

            using (var context = new ProductShopContext())
            {
                context.Categories.AddRange(categories);
                context.SaveChanges();
            }

            return $"{categories.Length} categories added to database!";
        }

        public static string ImportProducts()
        {
            var text = File.ReadAllText(ProductsPath);
            var products = JsonConvert.DeserializeObject<Product[]>(text);
            var random = new Random();

            using (var context = new ProductShopContext())
            {
                var usersCount = context.Users.Count();
                foreach (var product in products)
                {
                    var sellerId = random.Next(1, usersCount);
                    var buyerId = random.Next(1, usersCount);
                    product.SellerId = sellerId;
                    if (sellerId - buyerId < 5)
                        product.BuyerId = buyerId;

                    context.Products.Add(product);
                    context.SaveChanges();
                }
            }
            return $"{products.Length} products added to database!";
        }

        public static string SeedCategoryProducts()
        {
            using (var context = new ProductShopContext())
            {
                var products = context.Products.Select(p => p.Id).ToList();
                var categories = context.Categories.Select(c => c.Id).ToList();
                var random = new Random();
                var affected = 0;
                foreach (var product in products)
                {
                    var usedCategories = new List<int>();
                    for (var i = 0; i < 3; i++)
                    {
                        var categoryIndex = random.Next(0, categories.Count);
                        if (!usedCategories.Contains(categoryIndex))
                        {
                            context.CategoryProducts.Add(new CategoryProduct
                            {
                                ProductId = product,
                                CategoryId = categories[categoryIndex]
                            });
                            affected++;
                            usedCategories.Add(categoryIndex);
                            context.SaveChanges();
                        }
                    }
                }
                return $"{affected} category products added to database!";
            }
        }

        public static string SeedDatabase()
        {
            var sb = new StringBuilder();
            sb.AppendLine(ImportUsers());
            sb.AppendLine(ImportCategories());
            sb.AppendLine(ImportProducts());
            sb.AppendLine(SeedCategoryProducts());
            return sb.ToString().Trim();
        }

        public static string GetProductsInRange()
        {
            using (var context = new ProductShopContext())
            {
                var products = context.Products.Where(p => p.Price >= 500 && p.Price <= 1000).Select(p =>
                    new
                    {
                        p.Name,
                        p.Price,
                        Seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                    }).ToList();

                var text = JsonConvert.SerializeObject(products, Formatting.Indented);
                File.WriteAllText("ExportedData/productsInRange.json", text);
                return "Products in given range successfully exported into ExportedData/productsInRange.json!";
            }
        }

        public static string GetSuccessfullySold()
        {
            using (var context = new ProductShopContext())
            {
                var users = context.Users.Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                    .OrderBy(u => u.LastName)
                    .ThenBy(u => u.FirstName).Select(u => new
                    {
                        u.FirstName,
                        u.LastName,
                        SoldProducts = u.ProductsSold.Where(p => p.BuyerId != null).Select(p => new
                        {
                            p.Name,
                            p.Price,
                            p.Buyer.FirstName,
                            p.Buyer.LastName
                        })
                    });
                var text = JsonConvert.SerializeObject(users, Formatting.Indented);
                File.WriteAllText("ExportedData/succesfullySold.json", text);
                return "Successfully Sold Products exported into ExportedData/succesfullySold.json!";
            }
        }

        public static string GetCategoriesByProducts()
        {
            using (var context = new ProductShopContext())
            {
                var products = context.Categories.OrderBy(e => e.Name).Select(c => new
                {
                    c.Name,
                    productCount = c.Products.Count,
                    averagePrice = c.Products.Average(p => p.Product.Price),
                    totalRevenue = c.Products.Sum(p => p.Product.Price)
                });
                var text = JsonConvert.SerializeObject(products, Formatting.Indented);
                File.WriteAllText("ExportedData/categoriesByProducts.json", text);
                return
                    "Categories By Products Count successfully exported into ExportedData/categoriesByProducts.json!";
            }
        }

        public static string GetUsersAndProducts()
        {
            using (var context = new ProductShopContext())
            {
                var users =
                    context
                        .Users
                        .Include(u => u.ProductsSold)
                        .ThenInclude(p => p.Buyer)
                        .Where(u => u.ProductsSold.Count(p => p.Buyer != null) >= 1)
                        .ToArray();

                var products = new
                {
                    usersCount = users.Length,
                    users = users.Select(u => new
                        {
                            firstName = u.FirstName,
                            lastName = u.LastName,
                            age = u.Age,
                            soldProducts = new
                            {
                                count = u.ProductsSold.Count(p => p.Buyer != null),
                                products = u.ProductsSold.Where(p => p.Buyer != null).Select(p => new
                                    {
                                        name = p.Name,
                                        price = p.Price
                                    })
                                    .ToArray()
                            }
                        }).ToArray()
                        .OrderByDescending(up => up.soldProducts.count)
                        .ThenBy(up => up.lastName)
                };

                var text = JsonConvert.SerializeObject(products, Formatting.Indented);
                File.WriteAllText("ExportedData/usersWithProducts.json", text);
                return "Users and Products successfully exported into ExportedData/usersWithProducts.json!";
            }
        }
    }
}