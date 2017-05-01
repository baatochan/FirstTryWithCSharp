using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infb20140211
{
    class Program
    {
        /* Zamiana liczby z dowolnego sytemu na dziesiętny za pomocą schematu Hernera
         * Dane: xxx - liczba, n - podstawa systemu
         * Cel: Zamiana liczby z dowolnego sytemu na dziesiętny za pomocą schematu Hernera
         * Wynik: yyy - liczba w systemie dziesiętnym
         */
        static void Main(string[] args)
        {
            tasksel:
            Console.WriteLine("Ten program zamieni liczbę z dowolnego systemu na dzisiętny");
            Console.WriteLine("Aby kontynuować kliknij 'y'");
            string x = Console.ReadLine();
            if (x == "y")
            {
                Console.WriteLine("Podaj liczbę, którą chcesz skonwertować (upewnij się, że jest ona zapisana poprawnie):");
                string xxx = Console.ReadLine();
                Console.WriteLine("Podaj system, w którym jest ona zapisana:");
                string n1 = Console.ReadLine();
                int n = int.Parse(n1);
                int yyy = Zamiana(xxx, n);
                Console.WriteLine("Liczba w dzisiętnym wynosi: $0", yyy);
                Console.ReadKey();
            }
            else {
                Console.WriteLine("Czy na pewno chcesz wyjść?");
                Console.WriteLine("Jeśli tak kliknij 'y'");
                string x1 = Console.ReadLine();
                if (x1 == "y") Environment.Exit(0);
                else goto tasksel;
            }
        }

        /*static int Zamiana(string xxx, int n) { 
            int y = 
            foreach (char x in xxx) {
                
            }
        };*/
    }
}
