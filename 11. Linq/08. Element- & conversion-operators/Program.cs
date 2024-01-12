using Musterdaten;

namespace _08._Element____conversion_operators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product[] prods = Service.GetProducts();


            var result = (from prod in prods
                          select new { prod.ProductName })
                          .First();

            Console.WriteLine($"{result.ProductName}");
            Console.WriteLine();

            // -----------------------------------------------------------------------------------------------------

            var result2 = (from prod in prods
                           select new { prod.ProductName, prod.Price })
                           .First(item => item.Price < 10);

            Console.WriteLine($"{result2.ProductName}");
            Console.WriteLine();


            var result3 = (from prod in prods
                           where prod.Price < 10
                           select new { prod.ProductName, prod.Price }).First();

            Console.WriteLine($"{result3.ProductName}");
            Console.WriteLine();

            // -----------------------------------------------------------------------------------------------------

            var result4 = (from prod in prods
                           select new { prod.ProductName, prod.Price })
                           .FirstOrDefault(item => item.Price < 1);

            if (result4 == null)
                Console.WriteLine("No element satisfies the condition!");
            else
                Console.WriteLine($"{result4.ProductName}");
            Console.WriteLine();

            // -----------------------------------------------------------------------------------------------------

            var result5 = (from prod in prods
                           select new { prod.ProductID, prod.ProductName })
                           .Single(p => p.ProductID == 2);

            if (result5 == null)
                Console.WriteLine("No element satisfies the condition!");
            else
                Console.WriteLine($"{result5.ProductName}");
            Console.WriteLine();


            Order[] orders = Service.GetOrders();


            var result6 = (from order in orders
                           select new { order.ProductID, order.Quantity })
                           .SingleOrDefault(p => p.Quantity == 12345);

            if (result6 == null)
                Console.WriteLine("No element satisfies the condition!");
            else
                Console.WriteLine($"{result6.ProductID}");
            Console.WriteLine();


            try
            {
                var result7 = (from order in orders
                               select new { order.ProductID, order.Quantity })
                               .SingleOrDefault(p => p.Quantity == 2);

                if (result7 == null)
                    Console.WriteLine("No element satisfies the condition!");
                else
                    Console.WriteLine($"{result7.ProductID}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            Console.WriteLine();

            // -----------------------------------------------------------------------------------------------------

            var result8 = (from prod in prods
                           select new { prod.ProductID, prod.ProductName })
                          .ElementAtOrDefault(3);

            if (result8 == null)
                Console.WriteLine("No element satisfies the condition!");
            else
                Console.WriteLine($"{result8.ProductName}");
            Console.WriteLine();

            // -----------------------------------------------------------------------------------------------------

            List<string> liste = [];


            foreach (string tempStr in liste.DefaultIfEmpty())
            {
                Console.WriteLine(tempStr + " hallo");
            }
            Console.WriteLine();


            foreach (string tempStr in liste.DefaultIfEmpty("leer"))
            {
                Console.WriteLine(tempStr);
            }
            Console.WriteLine();


            liste = ["Peter", "Uwe"];

            foreach (string tempStr in liste.DefaultIfEmpty("leer"))
            {
                Console.WriteLine(tempStr);
            }
            Console.WriteLine();


            // -----------------------------------------------------------------------------------------------------

            IEnumerable<string> names = (Service.GetCustomers()
                                        .Select(cust => cust.Name).ToArray());


            List<string> customers = (Service.GetCustomers()
                                     .Select(cust => cust.Name).ToList());

            foreach (string n in customers)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine();


            List<string> customers2 = (Service.GetCustomers()
                                     .Select(cust => cust.Name)).ToList();

            foreach (string n in customers2)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine();

        }
    }
}