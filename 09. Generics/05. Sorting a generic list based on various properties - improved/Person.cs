namespace _05._Sorting_a_generic_list_based_on_various_properties___improved
{
    class Person
    {
        public string Name { get; set; }

        public string City { get; set; }


        public static int CompareByName(Person x, Person y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            return x.Name.CompareTo(y.Name);
        }

        public static int CompareByCity(Person x, Person y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            return x.City.CompareTo(y.City);
        }
    }
}
