using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using AdventOfCode2020.Runner.days.day1;

namespace AdventOfCode2020.Tests
{
    public class Day1Test
    {
        [Test]
        public void Test1()
        {
            var solver = new Day1Solver();

            var result = solver.CalculateFuel(1969);
            Assert.AreEqual(result, 654);
        }

        [Test]
        public void Test2()
        {
            var solver = new Day1Solver();

            var result = solver.CalculateFuel(100756);
            Assert.AreEqual(result, 33583);
        }
    }
}