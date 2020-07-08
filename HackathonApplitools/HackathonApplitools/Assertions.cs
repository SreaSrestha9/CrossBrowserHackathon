using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace HackathonApplitools
{
    public static class Assertions
    {
        public static void ShouldBeEqual(this object actual, object expected, string message, bool takeScreenshot = false)
        {
            Console.WriteLine("{0}: Expected <{1}> , Actual <{2}>", message, expected, actual);
            Assert.AreEqual(expected, actual);
            
        }

        public static void ShouldCollectionBeEqual(this IList<string> actualList, IList<string> expectedList, string message, bool takeScreenshot = false, params object[] args)
        {
            for (var i = 0; i < expectedList.Count; i++)
                Console.Out.WriteLine("{0}{1} : Expected<{2}>, Actual<{3}> ", message, i + 1, expectedList[i], actualList[i]);

            CollectionAssert.AreEqual(expectedList, actualList.ToList(), message, args);


        }

        public static void ShouldCollectionBeEquivalent(this IEnumerable actualList, IEnumerable expectedList, string message, bool takeScreenshot = false, params object[] args)
        {
            foreach (var actualValue in actualList)
                {
                    Console.Out.WriteLine("{0} : Expected<{1}> ", message, actualValue);
                }
                CollectionAssert.AreEquivalent(expectedList, actualList, message, args);
            
        }

        public static bool IsInAscendingOrder<T>(this List<T> values)
        {
            for (int i = 0; i < values.Count - 1; i++)
            {
                if (Comparer<T>.Default.Compare(values[i], values[i + 1]) > 0)
                    return false;
            }
            return true;
        }
        public static void ShouldBeTrue(this bool condition, string message, bool takeScreenshot = false)
        {
           
                Console.WriteLine("{0} - Is True ? {1}", message, condition);
                Assert.IsTrue(condition);
            
        }

        public static void ShouldBeFalse(this bool condition, string message, bool takeScreenshot = false)
        {
               Console.WriteLine("{0} - Is False ? {1}", message, condition);
                Assert.IsFalse(condition);
            
        }
    }
}
