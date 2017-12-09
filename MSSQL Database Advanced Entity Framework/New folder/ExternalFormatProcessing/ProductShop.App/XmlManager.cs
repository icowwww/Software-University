using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop.App
{
    public class XmlManager
    {
        public static string ImportUsers()
        {
            var text = File.ReadAllText("Filles/users.xml");

            var xml = XDocument.Parse(text);

            var users = xml.Root?.Elements();
            var affected = 0;

            using (var context = new ProductShopContext())
            {
                foreach (var xElement in users)
                {
                    var firstName = xElement.Attribute("firstName")?.Value;
                    var lastName = xElement.Attribute("lastName")?.Value;
                    //var age = xElement.Attribute("age")?.Value;
                    int? age = null;
                    if (xElement.Attribute("age")?.Value != null)
                        age = int.Parse(xElement.Attribute("age")?.Value);
                    var user = new User
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age
                    };
                    affected++;
                    context.Users.Add(user);
                }
                context.SaveChanges();
                return $"{affected} users has been added to database!";
            }
        }

        public static string ImportCategories()
        {
            var text = File.ReadAllText("Filles/categories.xml");

            var xml = XDocument.Parse(text);

            var categories = xml.Root?.Elements();
            var affected = 0;

            using (var context = new ProductShopContext())
            {
                foreach (var category in categories)
                {
                    var newCategory = new Category
                    {
                        Name = category.Element("name")?.Value
                    };
                    affected++;
                    context.Categories.Add(newCategory);
                }
                context.SaveChanges();
            }
            return $"{affected} categories has been added to database!";
        }

        public static string ImportProducts()
        {
            var text = File.ReadAllText("Filles/products.xml");
            var products = XDocument.Parse(text).Root?.Elements();
            var random = new Random();
            var affected = 0;

            using (var context = new ProductShopContext())
            {
                var usersCount = context.Users.Count();
                foreach (var product in products)
                {
                    var sellerId = random.Next(1, usersCount);
                    var buyerId = random.Next(1, usersCount);
                    var newProduct = new Product
                    {
                        Name = product.Element("name").Value,
                        Price = decimal.Parse(product.Element("price").Value),
                        SellerId = sellerId
                    };
                    if (sellerId - buyerId < 5)
                        newProduct.BuyerId = buyerId;
                    affected++;
                    context.Products.Add(newProduct);
                    context.SaveChanges();
                }
            }
            return $"{affected} products has been added to database!";
        }

        public static string SeedCategoryProducts()
        {
            return JsonManager.SeedCategoryProducts();
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

        public static string ProductsInRange()
        {
            // Query 1:
            using (var context = new ProductShopContext())
            {
                var products = context
                    .Products
                    .Include(p => p.Buyer)
                    .Where(p => p.Price >= 1000 && p.Price <= 2000 && p.Buyer != null)
                    .Select(p => new
                    {
                        productName = p.Name,
                        price = p.Price,
                        buyer = $"{p.Buyer.FirstName} {p.Buyer.LastName}"
                    })
                    .ToArray();

                var document = new XDocument();
                document.Add(
                    new XElement("products"));

                foreach (var product in products)
                    document.Root.Add(
                        new XElement("product",
                            new XAttribute("name", $"{product.productName}"),
                            new XAttribute("price", $"{product.price}"),
                            new XAttribute("buyer", $"{product.buyer}")));

                document.Save("ExportedData/productsInRange.xml");

                return "Products in given range successfully exported into ExportedData/productsInRange.xml!";
            }
        }

        public static string SoldProducts()
        {
            //Query 2:
            using (var context = new ProductShopContext())
            {
                var users = context
                    .Users
                    .Include(u => u.ProductsSold)
                    .ThenInclude(p => p.Buyer)
                    .Where(u => u.ProductsSold.Count(p => p.Buyer != null) >= 1)
                    .Select(u => new
                    {
                        u.FirstName,
                        u.LastName,
                        Products = u.ProductsSold.Where(p => p.Buyer != null)
                            .Select(p => new
                            {
                                p.Name,
                                p.Price
                            })
                            .ToArray()
                    })
                    .OrderBy(u => u.FirstName)
                    .ThenBy(u => u.LastName)
                    .ToArray();

                var document = new XDocument();
                document.Add(new XElement("users"));

                foreach (var user in users)
                {
                    document.Root.Add(
                        new XElement("user",
                            new XAttribute("first-name", $"{user.FirstName}"),
                            new XAttribute("last-name", $"{user.LastName}"),
                            new XElement("sold-products")));

                    var productElements = document.Root.Elements()
                        .SingleOrDefault(e => e.Name == "user"
                                              && e.Attribute("first-name").Value == $"{user.FirstName}"
                                              && e.Attribute("last-name").Value == $"{user.LastName}")
                        .Element("sold-products");

                    foreach (var p in user.Products)
                        productElements
                            .Add(new XElement("product",
                                new XElement("name", $"${p.Name}"),
                                new XElement("price", $"{p.Price}")));
                }

                document.Save("ExportedData/succesfullySold.xml");

                return "Successfully Sold Products exported into ExportedData/succesfullySold.xml!";
            }
        }

        public static string CategoriesByProducts()
        {
            //Query 3:
            using (var context = new ProductShopContext())
            {
                var products = context.Categories.Select(c => new
                {
                    c.Name,
                    productCount = c.Products.Count,
                    averagePrice = c.Products.Average(p => p.Product.Price),
                    totalRevenue = c.Products.Sum(p => p.Product.Price)
                }).OrderBy(e => e.productCount).ToList();


                var document = new XDocument();
                document.Add(new XElement("categories"));

                foreach (var c in products)
                    document.Root.Add(new XElement("category",
                        new XAttribute("name", $"{c.Name}"),
                        new XElement("products-count", $"{c.productCount}"),
                        new XElement("average-price", $"{c.averagePrice}"),
                        new XElement("total-revenue", $"{c.totalRevenue}")));

                document.Save("ExportedData/categoriesByProducts.xml");

                return "Categories By Products Count successfully exported into ExportedData/categoriesByProducts.xml!";
            }
        }

        public static string UsersAndProducts()
        {
            //Query 4:
            using (var context = new ProductShopContext())
            {
                var users =
                    context
                        .Users
                        .Include(u => u.ProductsSold)
                        .ThenInclude(p => p.Buyer)
                        .Where(u => u.ProductsSold.Count(p => p.Buyer != null) >= 1)
                        .ToArray();

                var xmlArray = new
                {
                    usersCount = users.Length,
                    users = users.Select(u => new
                        {
                            u.FirstName,
                            u.LastName,
                            u.Age,
                            soldProducts = new
                            {
                                Count = u.ProductsSold.Count(p => p.Buyer != null),
                                Products = u.ProductsSold.Where(p => p.Buyer != null).Select(p => new
                                    {
                                        name = p.Name,
                                        price = p.Price
                                    })
                                    .ToArray()
                            }
                        }).ToArray()
                        .OrderByDescending(up => up.soldProducts.Count)
                        .ThenBy(up => up.LastName)
                };

                var document = new XDocument();
                document.Add(new XElement("users", new XAttribute("count", $"{xmlArray.usersCount}")));

                foreach (var u in xmlArray.users)
                {
                    document.Root.Add(new XElement("user",
                        new XAttribute("first-name", $"{u.FirstName}"),
                        new XAttribute("last-name", $"{u.LastName}"),
                        new XAttribute("age", $"{u.Age}"),
                        new XElement("sold-products",
                            new XAttribute("count", $"{u.soldProducts.Count}"))));

                    var element =
                        document.Root.Elements()
                            .SingleOrDefault(e => e.Name == "user"
                                                  && e.Attribute("first-name").Value == $"{u.FirstName}"
                                                  && e.Attribute("last-name").Value == $"{u.LastName}"
                                                  && e.Attribute("age").Value == $"{u.Age}")
                            .Elements()
                            .SingleOrDefault(e => e.Name == "sold-products");

                    foreach (var p in u.soldProducts.Products)
                        element.Add(new XElement("product",
                            new XAttribute("name", $"{p.name}"),
                            new XAttribute("price", $"{p.price}")));
                }

                document.Save("ExportedData/usersWithProducts.xml");

                return "Users and Products successfully exported into ExportedData/usersWithProducts.xml!";
            }
        }
    }
}