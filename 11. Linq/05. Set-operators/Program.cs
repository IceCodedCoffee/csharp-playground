namespace _05._Set
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] cities = ["Aachen", "Köln", "Bonn", "Aachen", "Bonn", "Hof"];

            var distinctCities = (from p in cities select p).Distinct();

            foreach (string city in distinctCities)
                Console.WriteLine(city);
            Console.WriteLine();


            var distinctCities2 = cities.Distinct();

            foreach (string city in distinctCities2)
                Console.WriteLine(city);
            Console.WriteLine();

            // -----------------------------------------------------------------------------------------------------
            
            string[] namen = ["Peter", "Peter", "Willi", "Willi", "Hans", "Hans"];


            var listeCities = from c in cities
                              select c;

            var listeNamen = from n in namen
                             select n;

            var listeComplete = listeCities.Union(listeNamen);

            foreach (var p in listeComplete)
                Console.WriteLine(p);
            Console.WriteLine();


            var listeCities2 = cities;

            var listeNamen2 = namen;

            var listeComplete2 = listeCities.Union(listeNamen);

            foreach (var p in listeComplete)
                Console.WriteLine(p);
            Console.WriteLine();

            // -----------------------------------------------------------------------------------------------------

            string[] citiesA = ["Aachen", "Köln", "Bonn", "Bonn", "Aachen", "Frankfurt"];
            string[] citiesB = ["Düsseldorf", "Bonn", "Bremen", "Köln", "Köln"];


            var listeCitiesA = from c in citiesA
                               select c;
            var listeCitiesB = from n in citiesB
                               select n;

            var commonListe = listeCitiesA.Intersect(listeCitiesB);

            foreach (var p in commonListe)
                Console.WriteLine(p);
            Console.WriteLine();

            // -----------------------------------------------------------------------------------------------------

            var listeCitiesC = listeCitiesA.Except(listeCitiesB);

            foreach (var p in listeCitiesC)
                Console.WriteLine(p);
            Console.WriteLine();
        }
    }
}