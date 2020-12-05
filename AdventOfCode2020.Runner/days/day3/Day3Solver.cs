using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using adventofcode2020.contracts;

namespace AdventOfCode2020.Runner.days.day3
{
    public class Day3Solver : ISolver
    {
        public void ExecutePart1()
        {
            var inputLines = File.ReadLines(Directory.GetCurrentDirectory() + @"\days\day3\input2.txt");
            int rowCount = inputLines.Count();
            Dictionary<int, char[]> matrix = new Dictionary<int, char[]>();
            int i = 0;

            var finalMatrix = new List<string>();

            foreach (var inputLine in inputLines)
            {
                var sb = new StringBuilder(inputLine);
                for (int j = 0; j < rowCount - 1; j++)
                {
                    sb.Append(inputLine);
                }

                finalMatrix.Add(sb.ToString());
            }

            foreach (var inputLine in finalMatrix)
            {

                var charactersline = inputLine.ToCharArray();
                //Console.WriteLine($"RowCount => {rowCount} and arraylength:{charactersline.Length}");

                var finalCharacterArray = new char[rowCount * charactersline.Length];

                // read map to coordinates 
                matrix.Add(i, charactersline);
                i++;
            }

            var slops = new[]
            {
                //new {x = 1, y = 1},
                //new {x = 1, y = 3},
                //new {x = 1, y = 5},
                //new {x = 1, y = 7},
                new {x = 2, y = 1}
            };

            var treeCountSlop = new List<int>();

            foreach (var slop in slops)
            {
                int treeCount = 0;
                //Console.WriteLine($"Slop:x:{slop.x}|y:{slop.y}");
                for (int x = slop.x; x < matrix.Keys.Count; x += slop.x)
                {
                    int j = x * slop.y;
                    var result = GetValueFromMatrix(matrix, j, x);
                    //Console.WriteLine($"{x}|{j}");

                    if (result == "#")
                    {
                        //Console.WriteLine("found a tree!");
                        treeCount += 1;
                    }
                    
                }
                Console.WriteLine($"Slop:x:{slop.x}|y:{slop.y}|found{treeCount.ToString()}");
                treeCountSlop.Add(treeCount);
            }

            Int64 s = 1;
            for (int j = 0; j < treeCountSlop.Count; j++)
            {
                s = s * treeCountSlop[j];
            }

            Console.WriteLine($"Result: {s}");
            //Console.WriteLine($"Slop:" + treeCount.ToString());
            // count the number of trees
            Console.WriteLine("Solved part 1 of day 3");
            Console.Read();
        }

        private string GetValueFromMatrix(Dictionary<int, char[]> matrix, int x, int y)
        {
            var row = matrix.GetValueOrDefault(y) as char[];
            return row[x].ToString();
        }

        public void ExecutePart2()
        {
            Console.WriteLine("Solved part 2 of day 3");
            Console.Read();
        }
    }
}
