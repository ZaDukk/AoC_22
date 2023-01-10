using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Concurrent;

namespace day_8
{
    internal class Program
    {

        static void displayList(List<int> list)
        {
            Console.WriteLine(String.Join(" ", list.Select(x => x).ToList()));
        }

        static string FILENAME = "input.txt";

        static void part1()
        {
            var grid = new List<List<int>>();
            var p1Answer = 0;

            using (StreamReader sr = new StreamReader(FILENAME))
            {
                while (!sr.EndOfStream)
                { 
                    var line = sr.ReadLine().ToCharArray();
                    var lineInInts = line.Select(x => int.Parse(x.ToString())).ToList();
                    grid.Add(lineInInts);
                }
            }
            for (int row =0; row < grid.Count; row++)
            {
                for (int col = 0; col < grid[0].Count(); col++)
                {
                    var currentPoint = grid[row][col];

                    var rowLeft = new List<int>();
                    var rowRight = new List<int>();

                    var colDown = new List<int>();
                    var colUp = new List<int>();

                    

                    for (int rl = 0; rl < col; rl++)
                    {
                        rowLeft.Add(grid[row][rl]);
                    }

                    for (int rr = col+1; rr < grid[0].Count(); rr++)
                    {
                        rowRight.Add(grid[row][rr]);
                    }

                    for (int cu = 0; cu<row; cu++)
                    {
                        colUp.Add(grid[cu][col]);
                    }
                    for (int cd = row+1; cd < grid.Count(); cd++)
                    {
                        colDown.Add(grid[cd][col]);
                    }

                    //Console.WriteLine(currentPoint);
                    //displayList(rowLeft);
                    //displayList(rowRight);
                    //displayList(colUp);
                    //displayList(colDown);
                    

                    if (rowLeft.Where(x => x>=currentPoint).ToList().Count()==0 || rowRight.Where(x => x>=currentPoint).ToList().Count()==0 ||colDown.Where(x => x>=currentPoint).ToList().Count() == 0 || colUp.Where(x => x >= currentPoint).ToList().Count()==0)
                    {
                        p1Answer++;
                        //Console.WriteLine("found a nice tree");
                    }
                    //Console.WriteLine("NEW POINT");

                }
            }
            Console.WriteLine(p1Answer);


        }

        static void part2()
        {
            var grid = new List<List<int>>();
            var p2Answers = new List<int>();

            using (StreamReader sr = new StreamReader(FILENAME))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().ToCharArray();
                    var lineInInts = line.Select(x => int.Parse(x.ToString())).ToList();
                    grid.Add(lineInInts);
                }
            }
            for (int row = 0; row < grid.Count; row++)
            {
                for (int col = 0; col < grid[0].Count(); col++)
                {
                    var currentPoint = grid[row][col];

                    var rowLeft = new List<int>();
                    var rowRight = new List<int>();

                    var colDown = new List<int>();
                    var colUp = new List<int>();



                    for (int rl = 0; rl < col; rl++)
                    {
                        rowLeft.Add(grid[row][rl]);
                    }
                    rowLeft.Reverse();
                    for (int rr = col + 1; rr < grid[0].Count(); rr++)
                    {
                        rowRight.Add(grid[row][rr]);
                    }
                    rowRight.Reverse();
                    for (int cu = 0; cu < row; cu++)
                    {
                        colUp.Add(grid[cu][col]);
                    }
                    colUp.Reverse();
                    for (int cd = row + 1; cd < grid.Count(); cd++)
                    {
                        colDown.Add(grid[cd][col]);
                    }
                    colDown.Reverse();

                    int leftScore = 0, rightScore = 0, upScore = 0, downScore = 0;

                    foreach(int i in rowLeft)
                    {
                        if (i <= currentPoint)
                        {
                            leftScore++;
                            
                        }
                        else
                        {
                            break;
                        }
                    }
                    foreach (int i in rowRight)
                    {
                        if (i <= currentPoint)
                        {
                            rightScore++;
                            
                        }
                        else
                        {
                            break;
                        }
                    }
                    foreach (int i in colUp)
                    {
                        if (i <= currentPoint)
                        {
                            upScore++;
                            
                        }
                        else
                        {
                            break;
                        }
                    }
                    foreach (int i in colDown)
                    {
                        if (i <= currentPoint)
                        {
                            downScore++;
                            
                        }
                        else
                        {
                            break;
                        }
                    }

                    p2Answers.Add(upScore * downScore * leftScore * rightScore);

                } 
            }
            displayList(p2Answers);
            Console.WriteLine(p2Answers.Max());
            
        }

        static void Main(string[] args)
        {
            part1();
            part2();


            Console.ReadKey();

        }
    }
}
