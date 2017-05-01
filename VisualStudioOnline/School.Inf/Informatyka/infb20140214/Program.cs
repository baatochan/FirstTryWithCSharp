using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infb20140214
{
    class Program
    {
        static void Main(string[] args)
        {
            //ArrayLoader AL = new ArrayLoader();
            Console.WriteLine("Podaj liczbe n");
            //int[] a = AL.LoadIntArray();
            int[] a = new int[3];
            a[0] = 2;
            a[1] = 5;
            a[2] = 7;

            string y1 = Console.ReadLine();
            int y = int.Parse(y1);
            int[] b = new int[y];
            int[] t = Tablica(a, b, y);
            Console.WriteLine(t);
            Console.ReadKey();
        }
        static int[] Tablica(int[] a, int[] b, int n) {
            for (int i = 0; i < n; i++)
            {
                b[i] = i;
            }
            int[] t = new int[n];
            for (int i = 0; i < n; i++)
            {
                t[i] = 0;
            }
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.Length; j++) {
                    if (j > 2)
                    {
                        if (a[i] % b[j] == 0)
                        {
                            t[j] = 1;
                        }
                    }
                }
            }
            return t;

        }
    }
}
