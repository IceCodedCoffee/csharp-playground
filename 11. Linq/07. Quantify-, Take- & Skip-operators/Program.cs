using Musterdaten;

namespace _07._Boolean____split_operators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer[] customers = Service.GetCustomers();

            bool result = (from cust in customers
                           from ord in cust.Orders
                           where cust.Name == "Willi"
                           select new { ord.ProductID })
                           .Any(ord => ord.ProductID == 7);

            if (result)
                Console.WriteLine("ProductID=7 is present");
            else
                Console.WriteLine("ProductID=7 is not present");
            Console.WriteLine();

            // -----------------------------------------------------------------------------------------------------

            Product[] products = Service.GetProducts();

            double maxPrice = 1.2;

            bool result2 = (from prod in products
                            select prod)
                            .All(p => p.Price > maxPrice);

            if (result2)
                Console.WriteLine($"All prices are > {maxPrice}");
            else
                Console.WriteLine($"At least one price is not > {maxPrice}");
            Console.WriteLine();

            // -----------------------------------------------------------------------------------------------------

            var result4 = products.Take(3);

            foreach (var prod in result4)
                Console.WriteLine(prod.ProductName);
            Console.WriteLine();


            var result5 = (from prod in products
                           where prod.Price > 3
                           select new { prod.ProductName, prod.Price })
                           .Take(3);

            foreach (var prod in result5)
                Console.WriteLine("{0,-7}{1}", prod.ProductName, prod.Price);
            Console.WriteLine();

            // -----------------------------------------------------------------------------------------------------

            var result6 = (from prod in products
                           select new { prod.ProductName, prod.Price })
                           .TakeWhile(n => n.Price > 3);

            foreach (var prod in result6)
                Console.WriteLine("{0,-9}{1}", prod.ProductName, prod.Price);
            Console.WriteLine();

            // -----------------------------------------------------------------------------------------------------

            var result7 = (from prod in products
                           select new { prod.ProductName, prod.Price })
                           .Skip(2);

            foreach (var prod in result7)
                Console.WriteLine("{0,-9}{1}", prod.ProductName, prod.Price);
            Console.WriteLine();

            // -----------------------------------------------------------------------------------------------------

            var result8 = (from prod in products
                           select new { prod.ProductName, prod.Price })
                           .SkipWhile(x => x.Price > 3);

            foreach (var prod in result8)
                Console.WriteLine("{0,-9}{1}", prod.ProductName, prod.Price);
            Console.WriteLine();
        }
    }
}