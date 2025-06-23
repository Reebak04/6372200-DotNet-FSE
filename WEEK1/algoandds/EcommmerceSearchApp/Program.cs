using System;
using System.Linq;

namespace EcommerceSearchApp
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }

        public Product(int productId, string productName, string category)
        {
            ProductId = productId;
            ProductName = productName;
            Category = category;
        }

        public override string ToString()
        {
            return $"ID: {ProductId}, Name: {ProductName}, Category: {Category}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Product[] products = new Product[]
            {
                new Product(1, "Laptop", "Electronics"),
                new Product(2, "Shoes", "Footwear"),
                new Product(3, "Watch", "Accessories"),
                new Product(4, "Mouse", "Electronics"),
                new Product(5, "T-Shirt", "Clothing")
            };

            Console.WriteLine("Enter product name to search:");
            string searchTerm = Console.ReadLine();

            Console.WriteLine("\n Linear Search:");
            var result1 = LinearSearch(products, searchTerm);
            Console.WriteLine(result1 != null ? $"Found: {result1}" : "Product not found.");

            Console.WriteLine("\n Binary Search (sorted by ProductName):");
            var sortedProducts = products.OrderBy(p => p.ProductName).ToArray();
            var result2 = BinarySearch(sortedProducts, searchTerm);
            Console.WriteLine(result2 != null ? $"Found: {result2}" : "Product not found.");
        }

        static Product LinearSearch(Product[] products, string name)
        {
            foreach (var product in products)
            {
                if (product.ProductName.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return product;
                }
            }
            return null;
        }

        static Product BinarySearch(Product[] sortedProducts, string name)
        {
            int left = 0;
            int right = sortedProducts.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int comparison = string.Compare(sortedProducts[mid].ProductName, name, true);

                if (comparison == 0)
                    return sortedProducts[mid];
                else if (comparison < 0)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return null;
        }
    }
}
