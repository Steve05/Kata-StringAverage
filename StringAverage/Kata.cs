using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringAverage
{
    [TestClass]
    public class KataTests
    {
        [TestMethod]
        public void AverageString_Empty_Should_Return_NA()
        {
            Assert.AreEqual("n/a", Kata.AverageString(""));
        }

        [TestMethod]
        public void AverageString_Greater_Then_Nine_Should_Return_NA()
        {
            Assert.AreEqual("n/a", Kata.AverageString("nine ten"));
        }

        [TestMethod]
        public void AverageString_Should_Equal()
        {
            Assert.AreEqual("four", Kata.AverageString("zero nine five two"));
            Assert.AreEqual("three", Kata.AverageString("four six two three"));
            Assert.AreEqual("three", Kata.AverageString("one two three four five"));
            Assert.AreEqual("four", Kata.AverageString("five four"));
            Assert.AreEqual("zero", Kata.AverageString("zero zero zero zero zero"));
            Assert.AreEqual("two", Kata.AverageString("one one eight one"));
        }
    }

    public static class Kata
    {
        public static string AverageString(string str)
        {
            if (string.IsNullOrEmpty(str))
                return "n/a";

            Dictionary<string, int> stringNumbersDictionary = new Dictionary<string, int>()
            {
                {"zero", 0}, {"one", 1}, {"two", 2}, {"three", 3}, {"four", 4}, {"five", 5}, {"six", 6}, {"seven", 7}, {"eight", 8}, {"nine", 9}
            };

            var stringNumsArray = str.Split(' ');
            var sum = 0;

            foreach (var stringNum in stringNumsArray)
            {
                if (!stringNumbersDictionary.ContainsKey(stringNum))
                    return "n/a";

                sum += stringNumbersDictionary[stringNum];
            }
            return  stringNumbersDictionary.FirstOrDefault(x => x.Value == sum / stringNumsArray.Length).Key;
        }
    }
}
