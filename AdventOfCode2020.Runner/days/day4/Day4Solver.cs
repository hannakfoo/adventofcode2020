using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using adventofcode2020.contracts;
using McMaster.Extensions.CommandLineUtils;

namespace AdventOfCode2020.Runner.days.day4
{
    public class Day5Solver : ISolver
    {
        private List<string> fields = new List<string>
        {
            "byr",
            "iyr",
            "eyr",
            "hgt",
            "hcl",
            "ecl",
            "pid",
            "cid"
        };

        public void ExecutePart1()
        {
            var validPassports = File
                .ReadAllText(Directory.GetCurrentDirectory() + @"\days\day4\input.txt")
                .Replace("\r\n\r\n", "<-->")
                .Split("<-->", StringSplitOptions.RemoveEmptyEntries)
                .Where(psp => IsValid(psp))
                .Count();

            Console.WriteLine($"Aantal paspoorten: {validPassports}");
            Console.WriteLine("Solved part 1 of day 4");
            Console.Read();
        }

        private bool IsValid(string psp)
        {
            psp = psp.Replace("\r\n", " ");
            var fields = psp.Split(' ');
            if (fields.Length == 8)
            {
                return true;
            }

            if (fields.Length == 7)
            {

                var fieldss = fields.SelectMany(f => f.Split(":")).ToList();
                return !fieldss.Contains("cid");
            }

            if (fields.Length < 7)
            {
                return false;
            }

            return false;
        }



        public void ExecutePart2()
        {
            var passports = File
                .ReadAllText(Directory.GetCurrentDirectory() + @"\days\day4\input.txt")
                .Replace("\r\n\r\n", "<-->")
                .Split("<-->", StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Replace("\r\n", " "))
                /*.Count()*/;

            Console.WriteLine(passports);

            foreach (var passport in passports)
            {

                if (IsCompletePassport(passport))
                {
                    var passportFields = passport.Split(' ');
                    
                    foreach (var passportField in passportFields)
                    {
                        Console.WriteLine(passportField);
                        var result = ValidateField(passportField);
                    }
                }
            }

            Console.WriteLine("Solved part 2 of day 4");
            Console.Read();
        }

        private bool IsCompletePassport(string passport)
        {
            var fields = passport.Split(' ');
            if (fields.Length == 8)
            {
                return true;
            }

            if (fields.Length == 7)
            {

                var fieldss = fields.SelectMany(f => f.Split(":")).ToList();
                return !fieldss.Contains("cid");
            }

            if (fields.Length < 7)
            {
                return false;
            }

            return false;
        }

        private bool ValidateField(string passportField)
        {
            var key = passportField.Split(':')[0];
            Regex regex = null;
            switch (key)
            {
                case "byr":
                    //1920 - 2002
                    regex = new Regex("^[1|2][9|0][234567890][012]$");
                    return regex.Match(passportField.Split(':')[1]).Success;
                case "iyr":
                    //2010 - 2020
                    regex = new Regex("^[2][0][1|2][0]$");
                    return regex.Match(passportField.Split(':')[1]).Success;
                case "eyr":
                    //2020 -2030
                    regex = new Regex("^[2][0][2|3][0]$");
                    return regex.Match(passportField.Split(':')[1]).Success;
                case "hgt":
                    //Height) -a number followed by either cm or in:
                    //If cm, the number must be at least 150 and at most 193.
                    //If in, the number must be at least 59 and at most 76.
                    return true;
                case "hcl":
                    //a # followed by exactly six characters 0-9 or a-f.
                    return true;
                case "ecl":
                    //exactly one of: amb blu brn gry grn hzl oth.
                    return true;
                case "pid":
                    //a nine-digit number, including leading zeroes.
                    return true;
                default:
                    return false;
            }

        }
    }
}
