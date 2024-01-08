namespace _04._Custom_sorting_a_generic_list
{
    class NameComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            return x.Name.CompareTo(y.Name);
        }
    }
}
