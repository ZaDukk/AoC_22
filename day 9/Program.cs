using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.CodeDom;

namespace day_9
{
    internal class Program
    {

        struct coord
        {
            public int x, y;
        }
        static void part1()
        {
            HashSet<(int,int)>  seen = new HashSet<(int,int)> ();
            
            Dictionary<string, int> xChanges = new Dictionary<string, int>()
            { 
                {"R", 1 }, {"L",-1}
            };
            Dictionary<string, int> YChanges = new Dictionary<string, int>()
            {
                { "U", 1 }, {"D",-1}
            };

            coord head = new coord();
            coord tail = new coord();
            head.x = 0; head.y = 0; tail.x = 0; tail.y = 0;


            using (StreamReader sr = new StreamReader("test.txt"))
            {
                while (!sr.EndOfStream)
                {
                    int dx, dy;
                    var line = sr.ReadLine().Split(' ');

                    if (line[0] =="R" || (line[0] == "L"))
                    {
                         //Console.WriteLine(line[0]);
                         dx = xChanges[line[0]];
                         dy = 0;
                    }
                    else
                    {
                         dx = 0;
                         dy = YChanges[line[0]];
                    }


                    for (int i = 0; i < int.Parse(line[1]); i++)
                    {
                        head.x += dx;
                        head.y += dy;

                        var xChangeThisRound = head.x - tail.x;
                        var yChangeThisRound = head.y - tail.y;

                        

                        if (Math.Abs(xChangeThisRound)>1 || Math.Abs(xChangeThisRound) > 1)
                        {
                            if (xChangeThisRound == 0)
                            {
                                tail.y += yChangeThisRound / 2; 
                            }
                            else if (yChangeThisRound == 0)
                            {
                                tail.x += xChangeThisRound / 2;
                            }
                        }
                        else
                        {
                            if (xChangeThisRound > 0)
                            {
                                tail.x++;
                            }
                            else if (xChangeThisRound < 0)
                            {
                                tail.x --;
                            }
                            if (yChangeThisRound > 0)
                            {
                                tail.y++;
                            }
                            else if (xChangeThisRound < 0)
                            {
                                tail.y--;
                            }
                        }

                        seen.Add((tail.x, tail.y));
                        Console.WriteLine((tail.x, tail.y));
                    }

                }
            }
            //Console.WriteLine(String.Join("", seen.Select(x => x)));
        }


        static void Main(string[] args)
        {
            part1();



            //wait before closing
            Console.ReadKey();
        }
    }
}
