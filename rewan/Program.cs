using rewan.Models;
using System.Collections;
using static rewan .DataSources.Source;
namespace rewan
{
    public class Program
    {
        static void Main(string[] args)
        {
            // 1. Get all products from the "Seafood" category
            var q1 = ProductList.Where(p => p.Category == "Seafood");
            foreach (var p in q1)
                Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");

            // 2. Get a list of only the product names
            var q2 = ProductList.Select(p => p.ProductName);
            foreach (var name in q2)
                Console.WriteLine(name);

            // 3. Get all products where UnitPrice is between 10 and 30
            var q3 = ProductList.Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30);
            foreach (var p in q3)
                Console.WriteLine(p.ProductName);

            // 4. Get all products that are in stock and belong to "Condiments"
            var q4 = ProductList.Where(p => p.UnitsInStock > 0 && p.Category == "Condiments");
            foreach (var p in q4)
                Console.WriteLine(p.ProductName);

            // 5. Create new anonymous type
            var q5 = ProductList.Select(p => new
            {
                Name = p.ProductName,
                Price = p.UnitPrice,
                StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
            });
            foreach (var p in q5)
                Console.WriteLine($"{p.Name} - {p.Price} - {p.StockStatus}");

            // 6. Print each product's name along with its position (1-based)
            var q6 = ProductList.Select((product, index) => new { product.ProductName, Index = index + 1 });
            foreach (var p in q6)
                Console.WriteLine($"{p.Index}. {p.ProductName}");

        }
    }
}

       
