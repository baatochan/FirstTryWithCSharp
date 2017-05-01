using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inf20131213
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            int[] testArray = LoadIntData();
            Console.Write("Podaj liczbe calkowita do sprawdzenia: ");
            int testNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Wynik: " + InArray(testArray, testNumber).ToString());
            Console.ReadKey();
        }

        public static bool InArray(int[] inputArray, int a)
        {
            if (inputArray.Length == 0) return false;
            Array.Sort(inputArray);
            List<int> ETP = inputArray.ToList<int>();
            while (ETP.Count > 1)
            {
                int half = ETP.Count / 2;
                if (ETP[half] == a) return true;
                else if (ETP[half] > a)
                {
                    ETP.RemoveRange(half, ETP.Count - half);
                    return InArray(ETP.ToArray(), a);
                }
                else
                {
                    ETP.RemoveRange(0, half);
                    return InArray(ETP.ToArray(), a);
                }
            }
            if (ETP[0] == a) return true;
            else return false;
        }

        public static int[] LoadIntData()
        {
            Console.Write("Podaj nazwe pliku z danymi: ");
            string filePath = Console.ReadLine();
            if (!System.IO.File.Exists(filePath)) return new int[0];
            string[] rawInput = System.IO.File.ReadAllLines(filePath);
            int[] processedInput = new int[rawInput.Length];
            for (int i = 0; i < rawInput.Length; i++) if (!int.TryParse(rawInput[i], out processedInput[i])) return new int[0];
            return processedInput;
        }
    }
}
