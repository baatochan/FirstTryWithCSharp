using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ArrayLoader
{

    public int[] LoadIntArray()
    {
        Console.Clear();
        loadint:
        Console.Write("Podaj nazwe/sciezke pliku > ");
        string path = Console.ReadLine();
        if (System.IO.File.Exists(path))
        {
            string[] rawData = System.IO.File.ReadAllLines(path);
            int[] processedData = new int[rawData.Length];
            for (int i = 0; i < rawData.Length; i++)
            {
                if (!int.TryParse(rawData[i], out processedData[i]))
                {
                    Console.WriteLine("Plik nie zawiera TYLKO liczb calkowitych.");
                    goto loadint;
                }
            }
            return processedData;
        }
        else
        {
            Console.WriteLine("Plik nie istnieje.");
            goto loadint;
        }
    }

    public string[] LoadStringArray()
    {
        Console.Clear();
        loadstr:
        Console.Write("Podaj nazwe/sciezke pliku > ");
        string path = Console.ReadLine();
        if (System.IO.File.Exists(path))
        {
            string[] rawData = System.IO.File.ReadAllLines(path);
            return rawData;
        }
        else
        {
            Console.WriteLine("Plik nie istnieje.");
            goto loadstr;
        }
    }

    public double[] LoadDoubleArray()
    {
        Console.Clear();
        loaddbl:
        Console.Write("Podaj nazwe/sciezke pliku > ");
        string path = Console.ReadLine();
        if (System.IO.File.Exists(path))
        {
            string[] rawData = System.IO.File.ReadAllLines(path);
            double[] processedData = new double[rawData.Length];
            for (int i = 0; i < rawData.Length; i++)
            {
                if (!double.TryParse(rawData[i], out processedData[i]))
                {
                    Console.WriteLine("Plik nie zawiera TYLKO liczb.");
                    goto loaddbl;
                }
            }
            return processedData;
        }
        else
        {
            Console.WriteLine("Plik nie istnieje.");
            goto loaddbl;
        }
    }
}
