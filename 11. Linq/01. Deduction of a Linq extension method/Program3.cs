namespace _01._Linq_extension_methods
{
    internal class Program3
    {
        static void Main3(string[] args)
        {
            string[] arr = ["Peter", "Uwe", "Willi", "Udo", "Gernot"];

            IEnumerable<string> query = arr.Where(name => name.Length < 4);

            foreach (string item in query)
                Console.WriteLine(item);

            Console.ReadLine();
        }
    }

    static class Extensionmethod
    {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> liste, Func<T, bool> filter)
        {
            List<T> result = new List<T>();

            foreach (T name in liste)
                if (filter(name))
                    result.Add(name);

            return result;
        }
    }
}