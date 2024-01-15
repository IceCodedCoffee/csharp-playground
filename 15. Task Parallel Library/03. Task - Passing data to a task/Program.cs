using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _03._Passing_data_to_a_task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int value = 110;
            string name = "Peter";

            Person person = new();
            person.Name = "Peter";

            // ----------------------------------------------------------------------------------------------

            Task task1 = new Task(number =>
            {
                Console.WriteLine($"Resultat = {Math.Sqrt((int)number)}");
            }, value);

            task1.Start();
            Console.WriteLine();

            // ----------------------------------------------------------------------------------------------

            Task<int> task2 = Task.Factory.StartNew(x =>
            {
                return 2 * (int)x;
            }, 3);

            Console.WriteLine(task2.Result);
            Console.WriteLine();

            // 3----------------------------------------------------------------------------------------------

            Task.Factory.StartNew(str =>
            {
                Console.WriteLine(str);
            }, name);

            // ----------------------------------------------------------------------------------------------

            Task.Factory.StartNew(str =>
            {
                Console.WriteLine(((string)str).Length);
            }, name);


            Task.Factory.StartNew(state =>
            {
                Person personState = state as Person;
                Console.WriteLine(personState.Name);
            }, person);
            Console.WriteLine();

            // ----------------------------------------------------------------------------------------------

            Task task3 = new Task(number =>
            {
                Console.WriteLine($"Resultat = {Math.Sqrt(value)}");
            }, value);

            task3.Start();
            Console.WriteLine();


            Task.Factory.StartNew(state =>
            {
                Console.WriteLine(person.Name);
            }, person);
            Console.WriteLine();

            // ----------------------------------------------------------------------------------------------

            Task.Factory.StartNew(Console.WriteLine, value);
        }

        class Person
        {
            public string Name { get; set; }
        }
    }
}