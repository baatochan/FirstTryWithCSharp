using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inf20140121
{
    class Program
    {
        /* Monotoniczność
         * Dane: Ciąg liczb rzeczywistych
         * Cel: Sprawdzić monotoniczność ciągu
         * Wynik: Rodzaj monotoniczności (lub jej brak)
         */

        /* Zadanie 1
         * Dane: Ciąg liczb rzeczywistych
         * Cel: Sprawdzić, czy ciąg jest arytmetyczny
         * Wynik: Stwierdzenie, czy ciag jest arytmetyczny
         */

        /* Zadanie 2
         * Dane: Ciąg liczb rzeczywistych
         * Cel: Sprawdzić, czy ciąg jest geometryczny
         * Wynik: Stwierdzenie, czy ciąg jest geometryczny
         */

        /* Zadanie 3
         * Dane: Liczba naturalna większa od 1
         * Cel: Rozłożyć daną liczbę na czynniki pierwsze
         * Wynik: Czynniki pierwsze składające się na daną liczbę (tablica liczb całkowitych)
         */

        /* Zadanie 4
         * Dane: 2 liczby naturalne (nie mniejsze niż 1)
         * Cel: Obliczyć największy wspólny dzielnik danych liczb
         * Wynik: NWD danych liczb (liczba całkowita)
         */

        /* Zadanie 5
         * Dane: 2 liczby naturalne (nie mniejsze niż 1)
         * Cel: Obliczyć najmniejszą wspólną wielokrotność danych liczb
         * Wynik: NWW danych liczb (liczba całkowita)
         */

        static void Main(string[] args)
        {
            ArrayLoader AL = new ArrayLoader();
            tasksel:
            Selector TaskSel = new Selector(new string[] { "Sprawdz, czy podany ciag jest arytmetyczny", "Sprawdz, czy podany ciag jest geometryczny, z pierwszym wyrazem roznym od 0", "Rozloz liczbe naturalna na czynniki pierwsze", "NWD dwoch liczb naturalnych", "NWW dwoch liczb naturalnych", "Monotonicznosc ciagu" });
            int selection = TaskSel.Select();
            switch (selection)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    goto arithm;
                case 2:
                    goto geom;
                case 3:
                    goto factor;
                case 4:
                    goto NWD;
                case 5:
                    goto NWW;
                case 6:
                    goto mono;
                default:
                    goto tasksel;
            }

            mono:
            double[] monodata = AL.LoadDoubleArray();
            byte mono = Monotonicity(monodata);
            switch (mono)
            {
                case 0:
                    Console.WriteLine("Ciag jest niemonotoniczny.");
                    break;
                case 1:
                    Console.WriteLine("Ciag jest staly.");
                    break;
                case 2:
                    Console.WriteLine("Ciag jest rosnacy.");
                    break;
                case 3:
                    Console.WriteLine("Ciag jest malejacy.");
                    break;
                case 4:
                    Console.WriteLine("Ciag jest niemalejacy.");
                    break;
                case 5:
                    Console.WriteLine("Ciag jest nierosnacy.");
                    break;
            }
            Console.ReadKey();
            goto tasksel;

            arithm:
            double[] arithmetic = AL.LoadDoubleArray();
            if (arithmetic.Length < 3) Console.WriteLine("Nie mozna okreslic, czy ciag jest arytmetyczny.");
            else
            {
                double diff = arithmetic[1] - arithmetic[0];
                for (int i = 2; i < arithmetic.Length; i++)
                {
                    if (arithmetic[i] - diff != arithmetic[i - 1])
                    {
                        Console.WriteLine("Ciag nie jest arytmetyczny.");
                        Console.ReadKey();
                        goto tasksel;
                    }
                }
                Console.WriteLine("Ciag jest arytmetyczny.");
            }
            Console.ReadKey();
            goto tasksel;

            geom:
            double[] geometric = AL.LoadDoubleArray();
            if (geometric.Length < 3) Console.WriteLine("Nie mozna okreslic, czy ciag jest geometryczny.");
            else
            {
                double multiplier = geometric[1] / geometric[0];
                for (int i = 2; i < geometric.Length; i++)
                {
                    if (geometric[i] / multiplier != geometric[i - 1])
                    {
                        Console.WriteLine("Ciag nie jest geometryczny.");
                        Console.ReadKey();
                        goto tasksel;
                    }
                }
                Console.WriteLine("Ciag jest geometryczny.");
            }
            Console.ReadKey();
            goto tasksel;

            factor:
            Console.Clear();
            Console.Write("Podaj liczbe naturalna wieksza od 1: ");
            string factInput = Console.ReadLine();
            int toFactorize = 0;
            if (!int.TryParse(factInput, out toFactorize) || toFactorize <= 1) goto factor;
            Console.WriteLine("Rozklad na czynniki pierwsze:");
            Console.WriteLine(string.Join("  ",Factorize(toFactorize)));
            Console.ReadKey();
            goto tasksel;

            NWD:
            Console.Clear();
            Console.WriteLine("Podaj dwie liczby naturalne dodatnie:"); // Wprawdzie dane są liczby naturalne, ale nie ma sensu liczyć NWD dla 0 i czegokolwiek.
            string nwdInA = Console.ReadLine();
            string nwdInB = Console.ReadLine();
            int nwdNumA = -1;
            int nwdNumB = -1;
            if (!int.TryParse(nwdInA, out nwdNumA) || !int.TryParse(nwdInB, out nwdNumB) || nwdNumA < 1 || nwdNumB < 1) goto NWD;
            Console.WriteLine("Najwiekszy wspolny dzielnik: " + NWD(nwdNumA, nwdNumB));
            Console.ReadKey();
            goto tasksel;

            NWW:
            Console.Clear();
            Console.WriteLine("Podaj dwie liczby naturalne dodatnie:"); // j.w.
            string nwwInA = Console.ReadLine();
            string nwwInB = Console.ReadLine();
            int nwwNumA = -1;
            int nwwNumB = -1;
            if (!int.TryParse(nwwInA, out nwwNumA) || !int.TryParse(nwwInB, out nwwNumB) || nwwNumA < 1 || nwwNumB < 1) goto NWW;
            Console.WriteLine("Najmniejsza wspolna wielokrotnosc: " + NWW(nwwNumA, nwwNumB));
            Console.ReadKey();
            goto tasksel;
        }

        public static byte Monotonicity(double[] inputArray)
        {
            for (int i = 1; i < inputArray.Length; i++)
            {
                if (inputArray[i] != inputArray[i - 1]) goto nodecrement;
            }
            return 1;
            nodecrement:
            for (int i = 1; i < inputArray.Length; i++)
            {
                if (inputArray[i] < inputArray[i - 1]) goto noincrement;
            }
            for (int i = 1; i < inputArray.Length; i++)
            {
                if (inputArray[i] == inputArray[i - 1]) return 4;
            }
            return 2;
            noincrement:
            for (int i = 1; i < inputArray.Length; i++)
            {
                if (inputArray[i] > inputArray[i - 1]) return 0;
            }
            for (int i = 1; i < inputArray.Length; i++)
            {
                if (inputArray[i] == inputArray[i - 1]) return 5;
            }
            return 3;
        }

        public static int[] Factorize(int x)
        {
            List<int> result = new List<int>();
            result.Add(1);
            for (int i = 2; i <= x; i++)
            {
                if (x % i == 0)
                {
                    result.Add(i);
                    x /= i;
                    i = 1;
                }
            }
            return result.ToArray();
        }

        public static int NWD(int x, int y)
        {
            if (x == y) return x;
            int[] factX = Factorize(x);
            int[] factY = Factorize(y);
            List<int> listX = factX.ToList<int>();
            List<int> listY = factY.ToList<int>();
            List<int> commonFactors = new List<int>();
            for (int i = 0; i < listX.Count; i++)
            {
                if (listY.Contains(listX[i]))
                {
                    commonFactors.Add(listX[i]);
                    listY.Remove(listX[i]);
                    listX.Remove(listX[i]);
                    i -= 1;
                }
            }
            int result = 1;
            foreach (int factor in commonFactors) result *= factor;
            return result;
        }

        public static int NWW(int x, int y)
        {
            if (x == y) return x;
            int[] factX = Factorize(x);
            int[] factY = Factorize(y);
            List<int> listX = factX.ToList<int>();
            List<int> listY = factY.ToList<int>();
            List<int> uniqueFactors = factY.ToList<int>();
            for (int i = 0; i < listX.Count; i++)
            {
                if (!listY.Contains(listX[i]))
                {
                    uniqueFactors.Add(listX[i]);
                }
                listY.Remove(listX[i]);
                listX.Remove(listX[i]);
                i -= 1;
            }
            int result = 1;
            foreach (int factor in uniqueFactors) result *= factor;
            return result;
         }
    }
}
