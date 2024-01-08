namespace _05._Sorting_a_generic_list_based_on_various_properties___improved
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


            list.Sort(Person.CompareByCity);

            Console.WriteLine("Sort by City:");
            foreach (Person tempPerson in list)
            {
                if (tempPerson != null)
                {
                    Console.Write($"Name = {tempPerson.Name,-12}");
                    Console.WriteLine($"City = {tempPerson.City}");
                }
            }


            list.Sort(Person.CompareByName);

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
