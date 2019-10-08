using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomizerFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomizerFunctions.Tests
{
    [TestClass()]
    public class RandomizerTests
    {
        [TestMethod()]
        public void RandomDateTest()
        {
            var randomDate = RandomizerFunctions.Randomizer.RandomDate();
            var startDate = new DateTime(1900, 1, 1);
            var valid = true;
            for (var i = 0; i < 100000; i++)
            {
                randomDate = RandomizerFunctions.Randomizer.RandomDate();
                if (randomDate < startDate || randomDate >= DateTime.Now) valid = false;
            }
            Assert.IsTrue(valid);
        }

        [TestMethod()]
        public void RandomDateTest1()
        {
            var startDate = new DateTime(1958, 1, 10);
            var randomDate = RandomizerFunctions.Randomizer.RandomDate(startDate);

            var valid = true;
            for (var i = 0; i < 100000; i++)
            {
                randomDate = RandomizerFunctions.Randomizer.RandomDate(startDate);
                if (randomDate < startDate || randomDate >= DateTime.Now) valid = false;
            }
            Assert.IsTrue(valid);
        }

        [TestMethod()]
        public void RandomDateTest2()
        {
            var startDate = new DateTime(1958, 1, 10);
            var endDate = new DateTime(1972, 12, 31);
            var randomDate = RandomizerFunctions.Randomizer.RandomDate(startDate, endDate);

            var valid = true;
            for (var i = 0; i < 100000; i++)
            {
                randomDate = RandomizerFunctions.Randomizer.RandomDate(startDate, endDate);
                if (randomDate < startDate || randomDate >= DateTime.Now) valid = false;
            }
            Assert.IsTrue(valid);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void EndBeforeStartTest()
        {
            var endDate = new DateTime(1958, 1, 10);
            var startDate = new DateTime(1972, 12, 31);
            var randomDate = RandomizerFunctions.Randomizer.RandomDate(startDate, endDate);

        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void EndBeforeStartTest2()
        {
            var startDate = DateTime.Now.AddDays(1);
            var randomDate = RandomizerFunctions.Randomizer.RandomDate(startDate);

        }

        [TestMethod()]
        public void RandomIntegerTest()
        {
            var valid = true;
            int randomInteger;
            for (var i = 0; i < 100000; i++)
            {
                randomInteger = Randomizer.RandomInteger(true);
                if (randomInteger <= int.MinValue ||
                    randomInteger >= int.MaxValue)
                {
                    valid = false;
                }
            }
            Assert.IsTrue(valid);
        }

        [TestMethod()]
        public void RandomPositiveIntegerTest()
        {
            var valid = true;
            int randomInteger;
            for (var i = 0; i < 100000; i++)
            {
                randomInteger = Randomizer.RandomInteger(false);
                if (randomInteger <= 0 ||
                    randomInteger >= int.MaxValue)
                {
                    valid = false;
                }
            }
            Assert.IsTrue(valid);
        }
    }
}