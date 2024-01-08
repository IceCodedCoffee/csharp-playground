namespace _02._Anonymous_types
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var obj = new { Name = "Peter", Ort = "Hamburg" };


            var obj1 = new { Name = "Peter", Ort = "Hamburg" };
            var obj2 = new { Name = "Uwe", Ort = "München" };
            var obj3 = new { Ort = "Berlin", Name = "Hans" };

            Console.WriteLine(obj.GetType());
            Console.WriteLine(obj1.GetType());
            Console.WriteLine(obj2.GetType());
            Console.WriteLine(obj3.GetType());
        }
    }
}
