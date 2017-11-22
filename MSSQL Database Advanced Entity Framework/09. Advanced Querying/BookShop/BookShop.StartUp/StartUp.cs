using System;
using System.Globalization;
using System.Linq;
using System.Text;
using BookShop.Data;
using BookShop.Models;

namespace BookShop.StartUp
{
    public class StartUp
    {
        private static void Main()
        {
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            //Age restriction
            var input = command.ToLower();
            var ageRestriction = -1;
            switch (input)
            {
                case "minor":
                    ageRestriction = 0;
                    break;
                case "teen":
                    ageRestriction = 1;
                    break;
                case "adult":
                    ageRestriction = 2;
                    break;
            }
            var books = context.Books
                .Where(b => b.AgeRestriction == (AgeRestriction) ageRestriction)
                .Select(b => b.Title).OrderBy(b => b).ToList();
            return string.Join(Environment.NewLine, books);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            //0. Golden Books
            var books = context.Books
                .Where(e => e.Copies < 5000 && e.EditionType == EditionType.Gold)
                .OrderBy(e => e.BookId)
                .Select(e => e.Title).ToList();
            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            //1. Books by Price
            var books = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .ToList();
            var sb = new StringBuilder();
            foreach (var book in books)
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            return sb.ToString();
        }

        public static string GetBooksNotRealeasedIn(BookShopContext context, int year)
        {
            //2. Not Released In
            var books = context.Books
                .Where(b => !b.ReleaseDate.ToString().Contains(year.ToString()))
                .OrderBy(b => b.BookId)
                .Select(b => b.Title).ToList();
            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            //3. Book Titles by Category
            var category = input.ToLower().Split(" ").ToList();

            var books = context.Books
                .Where(b => b.BookCategories.Select(c => c.Category.Name.ToLower()).Any(x => category.Contains(x)))
                .Select(b => b.Title).OrderBy(b => b).ToList();
            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            //4. Released before Date
            var sb = new StringBuilder();
            var books = context.Books
                .Where(b => b.ReleaseDate < DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price,
                    b.ReleaseDate
                })
                .OrderByDescending(e => e.ReleaseDate).ToList();
            foreach (var book in books)
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            return sb.ToString().Trim();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            //5. Author Search
            var books = context.Authors.Where(a => a.FirstName.EndsWith(input))
                .Select(a => a.FirstName + " " + a.LastName).OrderBy(a => a).ToList();
            return string.Join(Environment.NewLine, books);
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            //6. Book Search
            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b).ToList();
            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            //7. Book Search by Author
            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => b.Title + " (" + b.Author.FirstName + " " + b.Author.LastName + ")")
                .ToList();
            return string.Join(Environment.NewLine, books);
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            //8. Count Books 
            var bookCount = context.Books.Count(b => b.Title.Length > lengthCheck);
            return bookCount;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            //9. Total book Copies
            var booksCount = context.Books.Select(b => new
                {
                    Name = b.Author.FirstName + " " + b.Author.LastName,
                    b.Copies
                }).GroupBy(e => e.Name)
                .OrderByDescending(b => b.Sum(x => x.Copies))
                .Select(e => e.Key + " - " + e.Sum(x => x.Copies)).ToList();
            return string.Join(Environment.NewLine, booksCount);
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            //10. Profit by Category
            var profit = context.Categories.Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks.Sum(e => e.Book.Copies * e.Book.Price)
                })
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.Name)
                .Select(c => c.Name + " $" + c.Profit)
                .ToList();
            return string.Join(Environment.NewLine, profit);
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            //11. Most Recent Books
            var sb = new StringBuilder();
            var categories = context.Categories.OrderBy(x => x.Name);
            foreach (var category in categories)
            {
                sb.AppendLine("--" + category.Name);
                var currentLine = context.Books
                    .Where(b => b.BookCategories.Select(x => x.Category.CategoryId).First() == category.CategoryId)
                    .OrderByDescending(b => b.ReleaseDate).Select(b => b.Title + " (" + b.ReleaseDate.Value.Year + ")")
                    .Take(3).ToList();
                sb.AppendLine(string.Join(Environment.NewLine, currentLine));
            }
            return sb.ToString().Trim();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            //12. Increase Prices
            var books = context.Books.Where(b => b.ReleaseDate.Value.Year < 2010).ToList();
            foreach (var book in books)
                book.Price += 5;
            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            //13. Remove Books
            var books = context.Books.Where(b => b.Copies < 4200).ToList();
            foreach (var book in books)
                context.Books.Remove(book);
            context.SaveChanges();
            return books.Count;
        }
    }
}