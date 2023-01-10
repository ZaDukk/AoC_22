using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace day1
{
    internal class Program
    {

        static void partB()
        {
            int currentTotal = 0;
            int biggestTotal = 0;

            List<int> elfCals = new List<int>();

           using (StreamReader sr = new StreamReader("d12022.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    //Console.WriteLine(line);
                    try
                    {
                        currentTotal+=int.Parse(line);
                    }
                    catch
                    {
                        elfCals.Add(currentTotal);
                        currentTotal = 0;
                    }
                }
                elfCals = elfCals.OrderByDescending(x => x).ToList();
                Console.WriteLine(elfCals[0] + elfCals[1] + elfCals[2]);
            }
        }

        static void Main(string[] args)
        {
            partB();

            Console.WriteLine('a'-'b');

            Console.ReadKey();   

        }
    }
}
