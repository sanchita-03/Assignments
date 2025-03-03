namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> product = new List<Product>
            {
                new Product { Id = 101, Name = "Smartphone", Category = "Electronics", Price = 15000 },
                new Product { Id = 102, Name = "Laptop", Category = "Electronics", Price = 55000 },
                new Product { Id = 103, Name = "Television", Category = "Electronics", Price = 32000 },
                new Product { Id = 104, Name = "Washing Machine", Category = "Home Appliance", Price = 25000 },
                new Product { Id = 105, Name = "Microwave Oven", Category = "Home Appliance", Price = 12000 },
                new Product { Id = 106, Name = "Headphones", Category = "Electronics", Price = 2000 },
                new Product { Id = 107, Name = "Refrigerator", Category = "Home Appliance", Price = 30000 }
            };
            var electronicproduct = from prod in product
                                    where prod.Category == "Electronics" && prod.Price > 1000
                                    select prod;
            var highestValueProduct = product.MaxBy(p => p.Price);
            foreach (var products in electronicproduct)
            {
                Console.WriteLine($"Product Id :{products.Id} Product Name : {products.Name}");
            }
            Console.WriteLine("highest Valued Product is :");
            Console.WriteLine($"Name::{highestValueProduct.Name}\tPrice::{highestValueProduct.Price}");

        }
        internal class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public double Price { get; set; }
        }
    }
}
