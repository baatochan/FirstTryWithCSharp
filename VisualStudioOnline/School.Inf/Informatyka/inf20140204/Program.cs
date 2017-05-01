using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inf20140204
{
    class Program
    {
        static void Main(string[] args)
        {
            Selector TaskSel = new Selector(new string[] { "Konwersja liczby w systemie o podstawie <2,9> na system dziesietny" });
            tasksel:
            int sel = TaskSel.Select();
            switch (sel)
            {
                case 1:
                    goto pconv;
                case 0:
                    Environment.Exit(0);
                    break;
            }

            pconv:
            Console.Clear();
            Console.Write("Podaj liczbe naturalna > ");
            string input = Console.ReadLine();
            int dummy = 0;
            if (!int.TryParse(input, out dummy)) goto pconv;

            byte sysBase = 0;
            Console.Write("Podaj podstawe systemu, w jakim zostala zapisana > ");
            string sysBaseStr = Console.ReadLine();
            if (!byte.TryParse(sysBaseStr, out sysBase)) goto pconv;

            foreach (char num in input) if (int.Parse(num.ToString()) >= sysBase) goto pconv;

            Console.WriteLine("Wynik w systemie dziesietnym:");
            Console.WriteLine(PConvert(input, sysBase));
            Console.ReadKey();
            goto tasksel;
        }

        static int PConvert(string input, byte sysBase)
        {
            int basePow = 1;
            int result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                result += byte.Parse(input[input.Length - 1 - i].ToString()) * basePow;
                basePow *= sysBase;
            }
            return result;
        }
    }
}
