using KingSortNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KingSortTestsNS
{
    [TestClass]
    public class KingSortTests
    {
        [TestMethod]
        public void Sort_Kings_Names()
        {
            var kings = new string[] { "Louis IX", "Louis VIII" };
            var expected = new string[] { "Louis VIII", "Louis IX" };

            KingSort sortKings = new KingSort(kings);

            var actual = sortKings.getSortedList(kings);

            Assert.AreEqual(expected, actual);
        }
    }
}
