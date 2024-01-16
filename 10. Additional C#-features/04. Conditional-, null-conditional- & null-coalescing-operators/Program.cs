namespace _04._Nullable_types__conditional____null_operators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = 10;

            string result = (number > 5) ? "Greater than 5" : "Less than or equal to 5";

            Console.WriteLine(result);
            Console.WriteLine();

            
            int y, x = 5;
            y = (x == 0) ? 1 : x;


            string test = null;

            int length = test != null ? test.Length : -1;

            // ---------------------------------------------------------------------------------

            Person person = null;
            string personName = person?.Name;

            Console.WriteLine(personName);
            Console.WriteLine();

            // ---------------------------------------------------------------------------------

            string expression = null;
            string defaultValue = "Expression 1 is null";

            result = expression ?? defaultValue;

            Console.WriteLine(result);
            Console.WriteLine();

            // ---------------------------------------------------------------------------------

            string defaultValue2 = "Person instance is null";

            result = person?.Name ?? defaultValue2;

            Console.WriteLine(result);
            Console.WriteLine();
        }

        class Person
        {
            public string Name { get; set; }
        }
    }
}