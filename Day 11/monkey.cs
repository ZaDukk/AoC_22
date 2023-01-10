using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_11
{
    internal class monkey
    {
        public long TruePass;
        public long FalsePass;

        public Queue<long> items = new Queue<long>();

        public int divisor;

        public string[] operation = new string[3];

        public int inspected = 0;
        


        public long[] throwItem()
        {
            long old = items.Dequeue();
            long newItem;
            long[] MonkeyItem = new long[2];

            if (operation[1] == "+")
            {
                old += long.Parse(operation[2]);
            }
            else // multiplication 
            {
                if (operation[2]!= "old")
                {
                    old *= long.Parse(operation[2]);
                }
                else
                {
                    old *= old;
                }
            }

            newItem = old;
            newItem /= 3; 
            MonkeyItem[1] = newItem;

            if (newItem % divisor == 0)
            {
                
                MonkeyItem[0] = TruePass;
            }
            else
            {
                MonkeyItem[0] = FalsePass;
            }
            inspected++;
            return MonkeyItem;
            
        }
}


    }

