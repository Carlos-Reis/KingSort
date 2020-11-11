using java.lang;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using StringBuilder = System.Text.StringBuilder;

namespace KingSortNS
{
    public class Helper
    {
        /// <summary>
        /// Converte o número de forma recursiva
        /// Verifica do maior para o menor os valores 
        /// Concatena com as substrings 
        /// Soma os valores
        /// </summary>
        /// <param name="romanNumber">String de um número romano, ex.: I,IV,X,L, etc </param>
        /// <returns>Inteiro equivalente ao número inserido, ex.: 1,4,10,50, etc</returns>
        private static int RecursiveConvertion(string romanNumber)
        {
            if (string.IsNullOrEmpty(romanNumber)) 
                return 0;

            if (romanNumber.StartsWith("M")) 
                return 1000 + RecursiveConvertion(romanNumber.Substring(1));

            else if (romanNumber.StartsWith("CM")) 
                return 900 + RecursiveConvertion(romanNumber.Substring(2));

            else if (romanNumber.StartsWith("D")) 
                return 500 + RecursiveConvertion(romanNumber.Substring(1));

            else if (romanNumber.StartsWith("CD")) 
                return 400 + RecursiveConvertion(romanNumber.Substring(2));

            else if (romanNumber.StartsWith("C")) 
                return 100 + RecursiveConvertion(romanNumber.Substring(1));

            else if (romanNumber.StartsWith("XC")) 
                return 90 + RecursiveConvertion(romanNumber.Substring(2));

            else if (romanNumber.StartsWith("L")) 
                return 50 + RecursiveConvertion(romanNumber.Substring(1));

            else if (romanNumber.StartsWith("XL")) 
                return 40 + RecursiveConvertion(romanNumber.Substring(2));

            else if (romanNumber.StartsWith("X")) 
                return 10 + RecursiveConvertion(romanNumber.Substring(1));

            else if (romanNumber.StartsWith("IX")) 
                return 9 + RecursiveConvertion(romanNumber.Substring(2));

            else if (romanNumber.StartsWith("V")) 
                return 5 + RecursiveConvertion(romanNumber.Substring(1));

            else if (romanNumber.StartsWith("IV")) 
                return 4 + RecursiveConvertion(romanNumber.Substring(2));

            else if (romanNumber.StartsWith("I")) 
                return 1 + RecursiveConvertion(romanNumber.Substring(1));

            throw new IllegalArgumentException("Numeral Romano não esperado");
        }

        /// <summary>
        /// Converteum número romano para decimal
        /// </summary>
        /// <param name="romanNumber">String de um número romano, ex.: I,IV,X,L, etc </param>
        /// <returns>Inteiro equivalente ao número inserido, ex.: 1,4,10,50, etc</returns>
        public static int RomanToDecimalConverter(string romanNumber)
        {
            //Valida a string com o número romano a ser convertido
            if (string.IsNullOrEmpty(romanNumber) || !Regex.IsMatch(romanNumber, "^(M{0,3})(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$"))
                return -1;
            return RecursiveConvertion(romanNumber);
        }

        /// <summary>
        /// cria uma base com todos os números que podem ser gerados
        /// </summary>
        /// <returns></returns>
        static Tuple<IList<Tuple<string, int>>, int> GenerateBaseNumbers()
        {
            const string letters = "IVXLCDM";

            var tuples = new List<Tuple<string, int>>();
            Tuple<string, int> subtractor = null;

            int num = 1;
            int maxNumber = 0;

            for (int i = 0; i < letters.Length; i++)
            {
                string currentLetter = letters[i].ToString();

                if (subtractor != null)
                {
                    tuples.Add(Tuple.Create(subtractor.Item1 + currentLetter, num - subtractor.Item2));
                }

                tuples.Add(Tuple.Create(currentLetter, num));
                bool isEven = i % 2 == 0;

                if (isEven)
                {
                    subtractor = tuples[tuples.Count - 1];
                }

                maxNumber += isEven ? num * 3 : num;
                num *= isEven ? 5 : 2;
            }

            return Tuple.Create((IList<Tuple<string, int>>)new ReadOnlyCollection<Tuple<string, int>>(tuples), maxNumber);
        }

        static readonly Tuple<IList<Tuple<string, int>>, int> RomanBaseNumbers = GenerateBaseNumbers();

        /// <summary>
        /// Converte um inteiro para número romano
        /// </summary>
        /// <param name="num">2</param>
        /// <returns>II</returns>
        public static string DecimalToRomanConverter(int num)
        {
            if (num <= 0 || num > RomanBaseNumbers.Item2)
            {
                throw new ArgumentOutOfRangeException();
            }

            StringBuilder sb = new StringBuilder();

            int i = RomanBaseNumbers.Item1.Count - 1;

            while (i >= 0)
            {
                var current = RomanBaseNumbers.Item1[i];

                if (num >= current.Item2)
                {
                    sb.Append(current.Item1);
                    num -= current.Item2;
                }
                else
                {
                    i--;
                }
            }

            return sb.ToString();
        }
    }
}
