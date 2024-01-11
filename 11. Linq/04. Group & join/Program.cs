using Musterdaten;

namespace _03._Group___join
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer[] customers = Service.GetCustomers();
            Order[] orders = Service.GetOrders();
            Product[] products = Service.GetProducts();


            var result14 = customers.GroupBy(customer => customer.City);

            foreach (IGrouping<Cities, Customer> group in result14)
            {
                Console.WriteLine(new string('=', 40));
                Console.WriteLine($"Stadt: {group.Key}");
                Console.WriteLine(new string('-', 40));

                foreach (Customer customer in group)
                    Console.WriteLine($" {customer.Name}");
                Console.WriteLine();
            }


            var result15 = from customer in customers
                           group customer by customer.City;

            foreach (IGrouping<Cities, Customer> group in result15)
            {
                Console.WriteLine(new string('=', 40));
                Console.WriteLine($"Stadt: {group.Key}");
                Console.WriteLine(new string('-', 40));

                foreach (Customer customer in group)
                    Console.WriteLine($" {customer.Name}");
                Console.WriteLine();
            }

            // -----------------------------------------------------------------------------------------------------

            var joinedList1 = orders
                             .Join(products,
                                 ord => ord.ProductID,
                                 prod => prod.ProductID, (order, product) => new
                                 {
                                     order.OrderID,
                                     order.ProductID,
                                     product.ProductName,
                                     product.Price,
                                     order.Quantity
                                 });

            foreach (var m in joinedList1)
                Console.WriteLine($"Order: {m.OrderID,-3} Product: {m.ProductID} Name: {m.ProductName,-9} Menge: {m.Quantity} Preis: {m.Price}");
            Console.WriteLine();


            var joinedList2 = from ord in orders
                              join prod in products
                              on ord.ProductID equals prod.ProductID
                              select new { ord.OrderID, ord.ProductID, prod.ProductName, prod.Price, ord.Quantity };

            foreach (var m in joinedList2)
                Console.WriteLine($"Order: {m.OrderID,-3} Product: {m.ProductID} Name: {m.ProductName,-9} Menge: {m.Quantity} Preis: {m.Price}");
            Console.WriteLine();

            // -----------------------------------------------------------------------------------------------------

            var joinedList3 = products
                              .GroupJoin(customers.SelectMany(cust => cust.Orders),
                              prod => prod.ProductID,
                              ord => ord.ProductID,
                              (product, correspondingOrders) => new { product.ProductID, CorrespondingOrders = correspondingOrders });

            foreach (var group in joinedList3)
            {
                Console.WriteLine($"ProductID: {group.ProductID}");

                foreach (var order in group.CorrespondingOrders)
                    Console.WriteLine($" OrderID: {order.OrderID}");
                Console.WriteLine();
            }
            Console.WriteLine();


            var customerOrders = from customer in customers
                                 from order in customer.Orders
                                 select order;

            var joinedList4 = from product in products
                              join order in customerOrders
                              on product.ProductID equals order.ProductID into correspondingOrders
                              select new { product.ProductID, CorrespondingOrders = correspondingOrders };

            foreach (var group in joinedList4)
            {
                Console.WriteLine($"ProductID: {group.ProductID}");

                foreach (var order in group.CorrespondingOrders)
                    Console.WriteLine($" OrderID: {order.OrderID}");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}