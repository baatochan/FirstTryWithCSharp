using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inf20140211
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayLoader AL = new ArrayLoader();
            Selector TS = new Selector(new string[] { "Sprawdz, czy liczba jest pierwsza", "Liczby z przedzialu niepodzielne przez liczby z tablicy" });
        tasksel:
            int sel = TS.Select();
            switch (sel)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    goto prime;
                case 2:
                    goto nondiv;
                default:
                    goto tasksel;
            }
        prime:
            Console.Clear();
            Console.Write("Podaj liczbe calkowita > ");
            string primeStr = Console.ReadLine();
            int primeInput = 0;
            if (!int.TryParse(primeStr, out primeInput)) goto prime;
            bool isPrime = Prime(primeInput);
            if (isPrime) Console.WriteLine("Podana liczba jest pierwsza.");
            else Console.WriteLine("Podana liczba nie jest pierwsza.");
            Console.ReadKey();
            goto tasksel;
        nondiv:
            Console.Clear();
            Console.Write("Podaj gorna granice sprawdzania (wieksza lub rowna 2) > ");
            string ndNumberStr = Console.ReadLine();
            int ndNumber = 0;
            if (!int.TryParse(ndNumberStr, out ndNumber)) goto nondiv;
            if (ndNumber < 2) goto nondiv;
            int[] ndArray = AL.LoadIntArray();
            for (int i = 0; i < ndArray.Length; i++)
            {
                if (ndArray[i] > ndNumber)
                {
                    Console.WriteLine("Element #$0 wprowadzonej tablicy jest poza zakresem sprawdzania.", i + 1);
                    Console.ReadKey();
                    goto nondiv;
                }
            }
            Console.Clear();
            Console.WriteLine("Wynik dla przedzialu $0 i podanej tablicy to nastepujace liczby:", ndNumber);
            string ndResult = string.Join(", ", NonDivisible(ndNumber, ndArray));
            Console.WriteLine(ndResult);
            Console.ReadKey();
            goto tasksel;
        }

        static bool Prime(int input)
        {
            if (input <= 1 && input >= -1) return false;
            else if (input < -1) input *= -1;
            for (int i = 2; i < Math.Sqrt(input); i++)
            {
                if (input % i == 0) return false;
            }
            return true;
        }

        static int[] NonDivisible(int n, int[] a)
        {
            List<int> aUnique = new List<int>();
            Array.Sort(a);
            aUnique.Add(a[0]);
            for (int i = 1; i < a.Length; i++) if (a[i] != a[i - 1]) aUnique.Add(a[i]);

            List<int> resultList = new List<int>();
            for (int i = 2; i <= n; i++)
            {
                bool divisible = false;
                for (int k = 0; k < aUnique.Count; k++)
                {
                    if (i < aUnique[k]) break;
                    else if (i % aUnique[k] == 0)
                    {
                        divisible = true;
                        break;
                    }
                }
                if (!divisible) resultList.Add(i);
            }

            return resultList.ToArray();
        }
    }
}
