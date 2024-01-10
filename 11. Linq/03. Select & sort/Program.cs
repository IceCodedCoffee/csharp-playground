using Musterdaten;

namespace _03._Select___sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer[] customers = Service.GetCustomers();
            Order[] orders = Service.GetOrders();

            var result1 = from order in orders
                          select order.OrderID;

            foreach (var item in result1)
                Console.WriteLine("result1: " + item);
            Console.WriteLine();


            var result2 = orders.Select(order => order.OrderID);

            foreach (var item in result2)
                Console.WriteLine("result2: " + item);
            Console.WriteLine();

            // -----------------------------------------------------------------------------------------------------

            var result3 = from customer in customers
                          select new { customer.Name, customer.City };

            foreach (var item in result3)
                Console.WriteLine("result3: " + item);
            Console.WriteLine();


            var result4 = customers
                          .Select(customer => new { customer.Name, customer.City });

            foreach (var item in result4)
                Console.WriteLine("result4: " + item);
            Console.WriteLine();

            // -----------------------------------------------------------------------------------------------------

            var result5 = customers
                          .Where(c => c.Name == "Hans")
                          .SelectMany(c => c.Orders)
                          .Where(order => order.Quantity > 6)
                          .Select(order => new { order.OrderID, order.ProductID });

            // -----------------------------------------------------------------------------------------------------

            var result6 = from order in orders
                          orderby order.Quantity
                          select new { order.OrderID, order.Quantity };

            foreach (var item in result6)
                Console.WriteLine($"result6: ID: {item.OrderID,-3}{item.Quantity}");
            Console.WriteLine();


            var result7 = orders
                          .OrderBy(order => order.Quantity)
                          .Select(order => new { order.OrderID, order.Quantity });

            foreach (var item in result7)
                Console.WriteLine($"result7: ID: {item.OrderID,-3}{item.Quantity}");
            Console.WriteLine();

            // -----------------------------------------------------------------------------------------------------

            var result8 = from order in orders
                          orderby order.Quantity descending
                          select new { order.OrderID, order.Quantity };

            foreach (var item in result8)
                Console.WriteLine($"result8: ID: {item.OrderID,-3}{item.Quantity}");
            Console.WriteLine();


            var result9 = orders
                          .OrderByDescending(order => order.Quantity)
                          .Select(order => new { order.OrderID, order.Quantity });

            foreach (var item in result9)
                Console.WriteLine($"result9: ID: {item.OrderID,-3}{item.Quantity}");
            Console.WriteLine();

            // -----------------------------------------------------------------------------------------------------

            var result10 = from order in orders
                           orderby order.Quantity descending, order.Shipped ascending
                           select new { order.OrderID, order.Quantity, order.Shipped };

            foreach (var item in result10)
                Console.WriteLine("result10: ProductID: {0,-3}Quantity:{1,-4} Shipped:{2}", item.OrderID, item.Quantity, item.Shipped);
            Console.WriteLine();


            var result11 = orders
                           .OrderByDescending(order => order.Quantity)
                           .ThenBy(order => order.Shipped)
                           .Select(order => new { order.OrderID, order.Quantity, order.Shipped });

            foreach (var item in result11)
                Console.WriteLine("result11: ProductID: {0,-3}Quantity:{1,-4} Shipped:{2}", item.OrderID, item.Quantity, item.Shipped);
            Console.WriteLine();

            // -----------------------------------------------------------------------------------------------------

            var result12 = (from order in orders
                            orderby order.Quantity descending, order.Shipped descending
                            select new { order.OrderID, order.Quantity, order.Shipped }).Reverse();

            foreach (var item in result12)
                Console.WriteLine("result10: ProductID: {0,-3}Quantity:{1,-4} Shipped:{2}", item.OrderID, item.Quantity, item.Shipped);
            Console.WriteLine();


            var result13 = orders
                           .OrderByDescending(order => order.Quantity)
                           .ThenByDescending(order => order.Shipped)
                           .Select(order => new { order.OrderID, order.Quantity, order.Shipped }).Reverse();

            foreach (var item in result13)
                Console.WriteLine("result11: ProductID: {0,-3}Quantity:{1,-4} Shipped:{2}", item.OrderID, item.Quantity, item.Shipped);
            Console.WriteLine();
        }
    }
}