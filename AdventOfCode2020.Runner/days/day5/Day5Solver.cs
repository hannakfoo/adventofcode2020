using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using adventofcode2020.contracts;

namespace AdventOfCode2020.Runner.days.day5
{
    public class Day5Solver : ISolver
    {
        private int[] seats = new int[128];
         
    public void ExecutePart1()
        { 
            for (int i = 0; i < 128; i++)
            {
                seats[i] = i;
            }
            var boardingPasses = File
                .ReadAllText(Directory.GetCurrentDirectory() + @"\days\day5\testinput.txt")
                .Replace("\r\n", "$$")
                .Split("$$")
                .ToList();

            // meaning of instructions:
            // F: Front 0 -127
            // B: Back
            // L: Left 8 columns
            // R: Right 8 columns

            // 8 columns

            boardingPasses.ForEach(boardingPass =>
            {
                var rowInstruction = boardingPass.Substring(0,7);
                Console.WriteLine($"rowinstruction:{rowInstruction}");
                var row = CalculateRowIndex(rowInstruction);
                var seatInstruction = boardingPass.Substring(7);
                Console.WriteLine($"seatInstruction:{seatInstruction}");
            });

            Console.WriteLine(boardingPasses);

            Console.WriteLine("Solved part 1 of day 5");
            Console.Read();
        }

        private int CalculateRowIndex(string rowInstruction)
        {
            var instructions = rowInstruction.ToList();
            var index = 127;
            var range= new Range(0,127);
            var seat = new Seat();
            var currenRow = new CurrentRow();
            currenRow.Start = 0;
            currenRow.End = 127;
            seat.RowRange = currenRow;

            instructions.ForEach(instr =>
            {
               Console.WriteLine(instr);
               seat.RowRange = GetRowRange(instr, seat.RowRange);

            });


            // If F  => 0 - 63
            // If B  => 63 - 127

            //for (int i = 0; i < instructions.Length; i++)
            //{

            //}

            return 0;
        }



        private CurrentRow GetRowRange(char instr, CurrentRow currentRow)
        {
          

            var result = seats.Length;

            var offset = result / 2;

            switch (instr)
            {
                case 'F':
                    currentRow.Start = currentRow.End / 2;
                    return currentRow;
                case 'B':
                    currentRow.End = currentRow.End / 2;
                    return currentRow;

                default:
                    return null;
            }
        }

        public void ExecutePart2()
        {
            Console.WriteLine("Solved part 2 of day 5");
            Console.Read();
        }
    }

    public class Seat
    {
        public CurrentRow RowRange { get; set; }

        public Seat()
        {
            
        }
        public Seat(int row, int column)
        {
            Row = row;
            Column = column;
        }
        public int Row { get; set; }

        public int Column { get; set; }
    }

    public class CurrentRow
    {
        public int Start { get; set; }

        public int End { get; set; }
    }
}
