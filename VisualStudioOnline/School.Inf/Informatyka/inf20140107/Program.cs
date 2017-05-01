using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inf20140107
{
    class Program
    {
        static void Main(string[] args)
        {
            tasksel:
            Selector TaskSel = new Selector(new string[] { "Sprawdz, czy wszystkie elementy sa podzielne przez 3", "Sprawdz, czy wszystkie elementy sa wieksze od 11", "Sprawdz, czy w tablicy znajduje sie liczba nie mniejsza od 20", "Sprawdz, czy wszystkie liczby znajduja sie w przedziale <-4;28>" });
            int selection = TaskSel.Select();
            switch (selection)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    
                case 2:
                    
                case 3:
                    
                case 4:
                    
                default:
                    goto tasksel;
            }
        }
    }
}
