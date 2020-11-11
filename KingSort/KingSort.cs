using com.sun.tools.javac.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace KingSortNS
{
    public class KingSort
    {
        public KingSort() { }

        public KingSort(string[] kings) 
        {
            this.kings = kings;
        }

        public string[] kings { get; }


        public string[] getSortedList(string[] kings)
        {
            var newList = new List<string>();
            var orderedKings = new List<string>();

            foreach (var name in kings)
            {
                //converte para decimal
                var inteiro = Helper.RomanToDecimalConverter(name.Split(" ")[1]);

                //substitui na string
                var newName = name.Split(" ")[0] + " " + inteiro;

                newList.Add(newName);
            }

            //ordena a lista
            newList.Sort();
            var newOrderedList = newList.OrderBy(x => PadNumbers(x));

            foreach (var name in newOrderedList)
            {
                //converte para romano
                var romano = Helper.DecimalToRomanConverter(int.Parse(name.Split(" ")[1]));

                //substitui na string
                var newName = name.Split(" ")[0] + " " + romano;

                orderedKings.Add(newName);
            }

            return orderedKings.ToArray();
        }

        /// <summary>
        /// Acrescenta '0's pra qualquer número na string input para que o comparador veja "ABC0000000010", "ABC0000000001"
        /// </summary>
        /// <param name="input">ABC10</param>
        /// <returns>ABC0000000010</returns>
        public static string PadNumbers(string input)
        {
            return Regex.Replace(input, "[0-9]+", match => match.Value.PadLeft(10, '0'));
        }
    }
}
