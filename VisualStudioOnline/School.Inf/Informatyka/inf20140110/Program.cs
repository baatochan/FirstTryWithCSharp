using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inf20140110
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] testArray = { 24, 24, 1, 24, 2, -6, 90, 24, 65, 24, 24, 24, 56, 2, 24, 19, 24 };
            Tuple<bool, double> searchResult = FindLeader(testArray);
            if (searchResult.Item1 == false) Console.WriteLine("Brak lidera.");
            else Console.WriteLine("Lider: " + searchResult.Item2);
            Console.ReadKey();
        }

        static Tuple<bool,double> FindLeader(double[] inputArray)
        {
            if (inputArray.Length < 1) return new Tuple<bool, double>(false, 0);

            if (inputArray.Length < 2)
            {
                return new Tuple<bool, double>(true, inputArray[0]);
            }

            else
            {
                int i = 1;
                for (i = 1; i < inputArray.Length; i++)
                {
                    if (inputArray[0] != inputArray[i]) break;
                }
                if (i >= inputArray.Length) return new Tuple<bool, double>(true, inputArray[0]);
                else
                {
                    List<double> processedList = new List<double>();
                    for (int k = 1; k < inputArray.Length; k++)
                    {
                        if (k != i) processedList.Add(inputArray[k]);
                    }
                    Tuple<bool, double> processedResult = FindLeader(processedList.ToArray());
                    if (processedResult.Item1 == false) return new Tuple<bool, double>(false, 0);
                    else
                    {
                        int count = 0;
                        for (int j = 0; j < inputArray.Length; j++)
                        {
                            if (inputArray[j] == processedResult.Item2) count++;
                        }
                        if (count > inputArray.Length / 2) return new Tuple<bool, double>(true, processedResult.Item2);
                        else return new Tuple<bool, double>(false, 0);
                    }
                }
            }
        }
    }
}
