namespace _01._Linq_extension_methods
{
    internal class Program1
    {
        delegate bool FilterHandler(string name);

        static void Main1(string[] args)
        {
            string[] arr = ["Peter", "Uwe", "Willi", "Udo", "Gernot"];

            FilterHandler del = FilterName;

            GetShortNames(arr, del);

            Console.ReadLine();
        }


        static void GetShortNames(string[] arr, FilterHandler del)
        {
            foreach (string name in arr)
                if (del(name)) Console.WriteLine(name);
        }


        static bool FilterName(string name)
        {
            return name.Length < 4;
        }
    }
}