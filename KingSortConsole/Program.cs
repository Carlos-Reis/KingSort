using KingSortNS;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KingSortConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string[]> kings = new List<string[]>();

            kings.Add(new string[] { "Louis IX", "Louis VIII" });
            kings.Add(new string[] { "Louis IX", "Philippe II" });
            kings.Add(new string[] { "Richard III", "Richard I", "Richard II" });
            kings.Add(new string[] { "John X", "John I", "John L", "John V" });
            kings.Add(new string[] { "Philippe VI", "Jean II", "Charles V", "Charles VI", "Charles VII", "Louis XI" });

            foreach (var array in kings)
            {
                KingSort sortKings = new KingSort(array);

                var actual = sortKings.getSortedList(array);

                Console.WriteLine("Lista: " + "[{0}]", string.Join(", ", array));
                Console.WriteLine("Ordenada: " + "[{0}]", string.Join(", ", actual));
                Console.WriteLine("\n");
            }
        }
    }
}
