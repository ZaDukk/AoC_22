using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.CodeDom;
using System.Net;

namespace day_7
{
    internal class Program
    {



        static void part1()
        {
            Stack<folder> stack = new Stack<folder>();

            folder rootFolder = new folder();
            folder currentFolder = rootFolder;


            using (StreamReader sr = new StreamReader("test.txt"))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(' ');

                    if (line[0] == "$")
                    {
                        if (line[1] == "cd")
                        {
                            if (line[2] == "/")
                            {
                                currentFolder = rootFolder;
                                stack.Clear();
                            }
                            else if (line[2] == "..")
                            {
                                currentFolder = stack.Pop();

                            }
                            else
                            {
                                if (!currentFolder.contains(line[2])) // need to be added to folder functionality 
                                {
                                    
                                    currentFolder.containedFolders.Add(line[2]); // needs to add the name and the value and stuff
                                   

                                }
                                stack.Push(currentFolder);
                                currentFolder = lastAddedFolder//wait for class to be made 
                            }

                        }
                    }
                    else
                    {
                        string x = line[0];
                        string y = line[1];

                        if (line[0] == "dir")
                        {
                            if (!currentFolder.contains(line[1]))// need to be added to folder functionality 
                            { 
                            
                                currentFolder.containedFolders.Add(line[1]); // needs to add the name and the value and stuff
                            }
                        }
                        else
                        {
                            //add int.Parse(line[0]) to folder with name line[2]
                        }
                    }
                    

                }
            }
            folder dir = rootFolder;

             void solvePart1()
            {
                
            }


        }


        static void Main(string[] args)
        {


        }
    }
}
