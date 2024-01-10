using Musterdaten;

namespace _02._Linq_query_operators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer[] customers = Service.GetCustomers();

            var query = from customer in customers
                        where customer.Name.Length < 6
                        select new { customer.Name, customer.City };

            foreach (var item in query)
                Console.WriteLine($"Name: {item.Name}, Ort: {item.City}");


            var query2 = customers.Where(customer => customer.Name.Length < 6);

            foreach (var item in query2)
                Console.WriteLine($"Name: {item.Name}, Ort: {item.City}");

            Console.WriteLine();
            // -----------------------------------------------------------------------------------------------------

            var query3 = from customer in customers
                         where customer.Name == "Hans"
                         from order in customer.Orders
                         where order.Quantity > 6
                         select new { order.OrderID, order.ProductID };

            foreach (var item in query3)
                Console.WriteLine($"OrderID: {item.OrderID}, ProductID: {item.OrderID} ");


            var query4 = customers
                        .Where(c => c.Name == "Hans")
                        .SelectMany(c => c.Orders)
                        .Where(order => order.Quantity > 6)
                        .Select(order => new { order.OrderID, order.ProductID });

            foreach (var item in query4)
                Console.WriteLine($"OrderID: {item.OrderID}, ProductID: {item.OrderID} ");

            Console.WriteLine();
            // -----------------------------------------------------------------------------------------------------

            var query5 = from cust in customers
                         where cust.City == Cities.Aachen
                         select cust.Name;

            foreach (var item in query5)
                Console.WriteLine(item);

            var query6 = customers
                         .Where(cust => cust.City == Cities.Aachen)
                         .Select(c => c.Name);

            foreach (var item in query6)
                Console.WriteLine(item);

            Console.WriteLine();
            // -----------------------------------------------------------------------------------------------------

            Order[] orders = Service.GetOrders();

            var query7 = from order in orders
                         where order.Quantity > 3 && order.Shipped == false
                         select order.OrderID;

            foreach (var item in query7)
                Console.WriteLine(item);

            var query8 = orders
                        .Where(order => order.Quantity > 3 && order.Shipped == false)
                        .Select(ord => ord.OrderID);

            foreach (var item in query8)
                Console.WriteLine(item);

            Console.WriteLine();
            // -----------------------------------------------------------------------------------------------------

            var query9 = orders
                         .Where((order, index) => order.Quantity > 3 && index < 10)
                         .Select(order => new { order.OrderID, order.ProductID, order.Quantity });

            foreach (var item in query9)
                Console.WriteLine($"{item.OrderID,-5}{item.ProductID,-5}{item.Quantity}");
        }
    }
}