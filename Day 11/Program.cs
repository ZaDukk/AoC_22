using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Concurrent;

namespace Day_11
{
    internal class Program
    {
         static monkey[] monkeys = new monkey[4];

        static void Main(string[] args)
        {
            Console.WriteLine("starting");
            for (int i =0; i<4; i++)
            {
                monkeys[i] = new monkey();
            }
            //passing the input
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                int currentMonkey = -1;
                while (!sr.EndOfStream)
                {


                    var line = sr.ReadLine().Trim();

                    if (line == null || line =="")
                    {
                        continue; 
                    }
                    if (line[0] == 'M')
                    {
                        currentMonkey++;
                    }
                    else if (line[0] == 'S')
                    {
                       
                        var items = line.Split(' ').ToList();
                        items.RemoveAt(0);
                        items.RemoveAt(0);
                        var NewItems = items.Select(x => long.Parse(x)).ToList();
                        foreach (var item in NewItems)
                        {
                            monkeys[currentMonkey].items.Enqueue(item);
                        }
                    }
                    else if (line[0] == 'O')
                    {
                        var words = line.Split(' ').ToList();
                        words.RemoveAt(0); words.RemoveAt(0); words.RemoveAt(0);
                        int i = 0;
                        foreach (string word in words)
                        {
                            monkeys[currentMonkey].operation[i] = word;
                            i++;
                        }
                    }
                    else if (line[0] == 'T')
                    {
                        var words = line.Split(' ').ToList();
                        monkeys[currentMonkey].divisor = int.Parse(words[words.Count() - 1]);
                    }
                    else if (line[0] == 'I')
                    {
                        var words = line.Split(' ').ToList();
                        if (words[1] == "true:")
                        {
                            monkeys[currentMonkey].TruePass = int.Parse(words[words.Count() - 1]);
                        }
                        else
                        {
                            monkeys[currentMonkey].FalsePass = int.Parse(words[words.Count() - 1]);
                        }

                    }
                }
                sr.Close();
            }
            long nextMonkey = 0;
            int round = 0;
            List<int> monkeysInspected = new List<int>() {0,0,0,0};

            foreach (monkey monkey in monkeys)
            {
                Console.WriteLine(monkey.FalsePass);
            }

            while (round <=20)
            {
                var monkeyItem = monkeys[nextMonkey].throwItem();
                //Console.WriteLine(nextMonkey);
                monkeysInspected[(int)nextMonkey]=1 ;
                monkeys[monkeyItem[0]].items.Enqueue(monkeyItem[1]);
                nextMonkey = monkeyItem[0];

                if (monkeysInspected.Where(x => x>0).ToList().Count() == 4)
                {
                    round++;
                    monkeysInspected = new List<int>() { 0, 0, 0, 0};
                    Console.WriteLine(round);
                }
                //Console.WriteLine(String.Join(" ", monkeysInspected.Select(x => x)));
            }

            List<long> inspectValues = new List<long>();
            foreach (monkey monkey in monkeys)
            {
                inspectValues.Add(monkey.inspected);
            }
            inspectValues = inspectValues.OrderByDescending(x => x).ToList();

            Console.WriteLine(inspectValues[0] * inspectValues[1]);

            Console.ReadKey();


        }
    }
}
