using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Globalization;
using System.Runtime.InteropServices;

namespace day_15__this_one_is_so_difficult_whyyy_
{
    internal class Program
    {

        static List<(int x, int y)> sensors = new List<(int x, int y)> ();
        static List<(int x, int y)> beacons = new List<(int x, int y)>();

        static int getDistance( (int x, int y ) a,  (int x, int y ) b)
        {
            return Math.Abs(a.x - b.x) + Math.Abs(a.y - b.y);
        }


        static void part1()
        {
            List<int> distances = new List<int>();

            //parsing the input
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                while (!sr.EndOfStream)
                {


                    string[] line = sr.ReadLine().Split(' ');


                    sensors.Add((int.Parse(line[2].Split('=')[1].Trim(',')), int.Parse(line[3].Split('=')[1].Trim(':'))));
                    beacons.Add((int.Parse(line[8].Split('=')[1].Trim(',')), int.Parse(line[9].Split('=')[1].Trim(':'))));
                }
            }


            for (int i =0; i < sensors.Count; i++)
            {
                distances.Add(getDistance(sensors[i], beacons[i])); 
            }

            List<(int x1, int x2)> ranges = new List<(int x, int y)>();  
            int Y = 2000000;

            for (int i = 0; i < sensors.Count; i++)
            {
                var s = sensors[i];

                int dx = distances[i] - Math.Abs(s.y - Y);
                //Console.WriteLine("got here");

                if (dx <= 0)
                {
                    continue;
                }
                //Console.WriteLine("and then here");
                ranges.Add((s.x - dx, s.x + dx));

            }
            List<int> valid = new List<int>();

            foreach ((int x,int y) coord in beacons)
            {
                if (coord.y == Y)
                {
                    valid.Add(coord.x);
                }
            }
            
            int minX = ranges[0].x1; 
            int maxX = ranges[0].x2;

            //get lowest possible x
            foreach ((int x1, int x2) coord in ranges)
            {
                if (coord.x1< minX)
                {
                    minX = coord.x1;
                }
            }
            //get highest possible x
            foreach ((int x1, int x2) coord in ranges)
            {
                if (coord.x2 > maxX)
                {
                    maxX = coord.x2;
                }
            }
            int p1answer = 0;

            for (int i = minX; i <= maxX; i++)
            {
                if (valid.Contains(i))
                {
                    continue;
                }

                foreach ((int left, int right)xValue in ranges)
                {
                    if (xValue.left <= i && i <= xValue.right)
                    {
                        p1answer++;
                        break;
                    }
                }
            }
            Console.WriteLine(p1answer);


        }


        static void part2()
        {
            int postive =0, negative =0;
            List<int> distances = new List<int>();

            //parsing the input
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                while (!sr.EndOfStream)
                {


                    string[] line = sr.ReadLine().Split(' ');


                    sensors.Add((int.Parse(line[2].Split('=')[1].Trim(',')), int.Parse(line[3].Split('=')[1].Trim(':'))));
                    beacons.Add((int.Parse(line[8].Split('=')[1].Trim(',')), int.Parse(line[9].Split('=')[1].Trim(':'))));
                }
            }


            for (int i = 0; i < sensors.Count; i++)
            {
                distances.Add(getDistance(sensors[i], beacons[i]));
            }

            List<int> postiveLines = new List<int>();
            List<int> negativeLines = new List<int>();

            for (int i = 0; i < sensors.Count; i++)
            {
                int d = distances[i];
                (int x, int y) s = sensors[i];

                negativeLines.Add(s.x + s.y - d);
                negativeLines.Add(s.x + s.y+d);

                postiveLines.Add(s.x - s.y - d);
                postiveLines.Add(s.x - s.y + d);

            }
            

            for (int i =0; i<(2*sensors.Count); i++)
            {
                for (int j = i+1; j<2*sensors.Count; j++)
                {
                    int a = postiveLines[i];
                    int b = b = postiveLines[j];

                    if (Math.Abs(a - b) == 2)
                    {
                        if (a < b)
                        {
                            postive = a + 1;
                        }
                        else
                        {
                            postive = b + 1;
                        }
                    }
                     a = negativeLines[i];
                     b  = negativeLines[j];

                    if (Math.Abs(a - b) == 2)
                    {
                        if (a < b)
                        {
                            negative = a + 1;
                        }
                        else
                        {
                            negative = b + 1;
                        }
                    }

                }
            }
            long x = (postive + negative) / 2;
            long y = (negative - postive) / 2;

            long p2Answer = x * 4000000 + y;

            Console.WriteLine(p2Answer);

        }


        static void Main(string[] args)
        {
            part1();
            part2();
            Console.ReadKey();


        }
    }
}
