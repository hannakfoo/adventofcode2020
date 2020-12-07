using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using adventofcode2020.contracts;

namespace AdventOfCode2020.Runner.days.day4
{
    public class Day4Solver : ISolver
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

            var finalResult = new List<bool>();
            
            foreach (var passport in passports)
            {
                int validTotal = 0;

                if (IsCompletePassport(passport))
                {
                    var passportFields = passport.Split(' ');

                    List<bool> validationPassport = new List<bool>();

                    foreach (var passportField in passportFields)
                    {

                        validationPassport.Add(ValidateField(passportField));

                        if (!ValidateField(passportField))
                        {
                            Console.WriteLine($"Validatie van {passportField}:{ValidateField(passportField)}");
                        }
                    }
                    if (!validationPassport.Contains(false))
                    {
                        finalResult.Add(true);
                    }
                }
            }
            Console.WriteLine($"{finalResult.Count()}");
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
                    regex = new Regex(@"19[2-9]\d|200[0-2]");
                    return regex.Match(passportField.Split(':')[1]).Success;
                case "iyr":
                    regex = new Regex(@"201\d|2020");
                    return regex.Match(passportField.Split(':')[1]).Success;
                case "eyr":
                    regex = new Regex(@"202\d|2030");
                    return regex.Match(passportField.Split(':')[1]).Success;
                case "hgt":
                    regex = new Regex(@"1[5-8]\dcm|19[0-3]cm|59in|6\din|7[0-6]in");
                    return regex.Match(passportField.Split(':')[1]).Success;
                case "hcl":
                    regex = new Regex(@"#[a-f0-9]{6,}");
                    return regex.Match(passportField.Split(':')[1]).Success;
                    return true;
                case "ecl":
                    regex = new Regex(@"amb|blu|brn|gry|grn|hzl|oth");
                    return regex.Match(passportField.Split(':')[1]).Success;
                case "pid":
                    regex = new Regex(@"\d{9}");
                    return regex.Match(passportField.Split(':')[1]).Success;
                case "cid":
                    return true;
                default:
                    return false;
            }
        }
    }
}
