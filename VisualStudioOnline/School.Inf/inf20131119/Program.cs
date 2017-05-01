using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inf20131119
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.Clear();
            Init:
            System.Console.Write("Podaj numer zadania (1-5): ");
            string exc = System.Console.ReadLine();
            int excercise = 0;
            if (!int.TryParse(exc, out excercise)) goto Init;

            switch (excercise) {
                case 1:
                    Uno();
                    break;
                default:
                    goto Init;
            }
            System.Console.ReadKey();
        }

        static void Uno()
        {
            StartUno:
            System.Console.Write("Podaj liczbe calkowita wieksza od 0: ");
            string input = System.Console.ReadLine();
            int n = 0;
            if (!int.TryParse(input, out n)) goto StartUno;
            else if (n <= 0) goto StartUno;
            int p = 2 * n;
            int r = 0;
            for (int i = 0; i < n; i++)
            {
                r += i + 1;
            }
            double m = (double)p / (double)r;
            System.Console.WriteLine("Wynik dzialania 2*n / (1+2+3+...+n) = " + m.ToString());
        }
    }
}
