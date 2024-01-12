using Musterdaten;

namespace _06._Aggregate_operators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Order[] orders = Service.GetOrders();


            var anzahl = (from x in orders select x).Count();

            var anzahl2 = orders.Count();

            Console.WriteLine($"Anzahl der Bestellungen gesamt = {anzahl}");
            Console.WriteLine($"Anzahl der Bestellungen gesamt = {anzahl2}");
            Console.WriteLine();

            // -----------------------------------------------------------------------------------------------------

            int[] arr = [1, 3, 7, 4, 99];

            var sumInt = arr.Sum();

            Console.WriteLine("Integer-Summe = {0}", sumInt);
            Console.WriteLine();

            // -----------------------------------------------------------------------------------------------------

            Customer[] customers = Service.GetCustomers();
            Product[] products = Service.GetProducts();

            var customerOrders = from cust in customers
                                 from ord in cust.Orders
                                 join prod in products
                                 on ord.ProductID equals prod.ProductID
                                 select new
                                 {
                                     cust.Name,
                                     ord.ProductID,
                                     prod.ProductName,
                                     TotalPrice = ord.Quantity * prod.Price
                                 };

            var customerOrderGroups = from cust in customers
                                      join customerOrder in customerOrders
                                      on cust.Name equals customerOrder.Name into correspondingOrders
                                      select new { cust.Name, CorrespondingOrders = correspondingOrders, allOrdersSum = correspondingOrders.Sum(productOrder => productOrder.TotalPrice) };

            foreach (var customerOrderSet in customerOrderGroups)
                Console.WriteLine("Name: {0,-7} Ordersum: {1}", customerOrderSet.Name, customerOrderSet.allOrdersSum);
            Console.WriteLine();


            foreach (var customerOrderGroup in customerOrderGroups)
            {
                Console.WriteLine($"Customer: {customerOrderGroup.Name}");

                foreach (var productOrder in customerOrderGroup.CorrespondingOrders)
                {
                    Console.Write($"{productOrder.ProductName, -19}");
                    Console.WriteLine($"{productOrder.TotalPrice:F2}");
                }
                Console.WriteLine($"{new string(' ', 19)}------");

                Console.WriteLine("Sum of all orders: {0}", customerOrderGroup.allOrdersSum);
                Console.WriteLine();

            }
            Console.WriteLine();

            // -----------------------------------------------------------------------------------------------------

            var max = (from p in products
                       select p.Price).Max();

            var max2 = (from p in products
                       select new { p.Price }).Max(x => x.Price);

            var min1 = (from p in products
                       select p.Price).Min();

            var min2 = (from p in products
                       select new { p.Price }).Min(x => x.Price);

            var avg1 = (from p in products
                       select p.Price).Average();

            var avg2 = (from p in products
                       select new { p.Price }).Average(x => x.Price);

            Console.WriteLine($"Max price: {max:F2}");
            Console.WriteLine($"Max price: {max2:F2}");
            Console.WriteLine($"Min price: {min1:F2}");
            Console.WriteLine($"Min price: {min2:F2}");
            Console.WriteLine($"Avg price: {avg1:F2}");
            Console.WriteLine($"Avg price: {avg2:F2}");
        }
    }
}