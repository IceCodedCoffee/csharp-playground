namespace _01._Implicitely_typed_variables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var x = 5;

            var city = "Aachen";

            var arr = new[] { 0, 1, 2 };


            //var x;

            //var x = null;

            //class Person
            //{
            //    var Age;
            //}

            //public var ChangeName(var Name) { }



            for (var y = 0; y < 100; y++)
            {
                Console.WriteLine(y);
            }

            foreach (var element in arr) 
            {
                Console.WriteLine(element);
            }
        }
    }
}
