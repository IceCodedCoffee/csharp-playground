namespace _04._Custom_sorting_a_generic_list
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> list = new()
            {
                new Person { Name = "Meier", City = "Berlin" },
                null,
                new Person { Name = "Schulz", City = "Stuttgart" },
                new Person { Name = "Gerhards", City = "Hamburg" },
                null,
                new Person { Name = "Müller", City = "Bremen" },
            };


            list.Sort(new CityComparer());

            Console.WriteLine("Sort by City:");
            foreach (Person tempPerson in list)
            {
                if (tempPerson != null)
                {
                    Console.Write($"Name = {tempPerson.Name,-12}");
                    Console.WriteLine($"City = {tempPerson.City}");
                }
            }


            list.Sort(new NameComparer());

            Console.WriteLine("Sort by Name:");
            foreach (Person tempPerson in list)
            {
                if (tempPerson != null)
                {
                    Console.Write($"Name = {tempPerson.Name,-12}");
                    Console.WriteLine($"City = {tempPerson.City}");
                }
            }
        }
    }
}