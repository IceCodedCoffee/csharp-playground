namespace _01._Linq_extension_methods
{
    internal class Program2
    {
        static void Main2(string[] args)
        {
            string[] arr = ["Peter", "Uwe", "Willi", "Udo", "Gernot"];

            GetShortNames(arr, name => name.Length < 4);

            Console.ReadLine();
        }


        static void GetShortNames<T>(T[] names, Func<T, bool> getNames)
        {
            foreach (T name in names)
                if (getNames(name))
                    Console.WriteLine(name);
        }
    }
}