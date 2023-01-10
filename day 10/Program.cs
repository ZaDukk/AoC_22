using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace day_10
{
    internal class Program
    {
        static void solve()
        {
            List<int> x = new List<int>() {1};
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    if (line == "noop")
                    {
                        x.Add(x[x.Count()-1]); 
                    }
                    else
                    {
                        x.AddRange(new List<int>() { x[x.Count() - 1], x[x.Count() - 1] + int.Parse(line.Split(' ')[1])});
                    }
                }
            }
            Console.WriteLine(x[19]*20 + x[59] * 60 + x[99]*100 + x[139]*140 + x[179]*180 + x[219]*220);

            //part 2 as it requires part 1 
            int i = 0;

            for (int j = 0; j < 6; j++)
            {
                for (int k =0; k<40; k++)
                {
                    var temp = new List<int>() { x[i] - 1, x[i], x[i] + 1 };
                    if (temp.Contains(k))
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                    i++;
                }
                Console.WriteLine();
            }

        }

        static void Main(string[] args)
        {
            solve();

            Console.ReadKey();
        }
    }
}
