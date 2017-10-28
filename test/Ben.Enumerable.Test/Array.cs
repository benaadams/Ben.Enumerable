using System;
using System.Collections.Generic;
using Xunit;

namespace Enumerable
{
    public class Array
    {
        [Fact]
        public void EnumerationSame()
        {
            // Arrange
            int[] array = new[] { 1, 2, 3, 4, 5, 6, 7 };

            IList<int> iList = array;
            EnumerableIList<int> eIList = array;

            // Assert
            var i = 0;
            foreach (var item in eIList)
            {
                Assert.Equal(iList[i], item);

                i++;
            }

            Assert.Equal(iList.Count, i);
        }

        [Fact]
        public void Empty()
        {
            // Arrange
            int[] array = System.Array.Empty<int>();
            IList<int> iList = array;
            EnumerableIList<int> eIList = array;

            // Assert
            var i = 0;
            foreach (var item in eIList)
            {
                Assert.Equal(iList[i], item);

                i++;
            }

            Assert.Equal(iList.Count, i);
        }

        [Fact]
        public void NoAllocations()
        {
            // Arrange
            int[] array = new[] { 1, 2, 3, 4, 5, 6, 7 };

            IList<int> iList = array;
            EnumerableIList<int> eIList = array;

            // Act
            var startAllocs = GC.GetAllocatedBytesForCurrentThread();

            // Assert
            var i = 0;
            foreach (var item in eIList)
            {
                i++;
            }

            var endAllocs = GC.GetAllocatedBytesForCurrentThread();

            Assert.Equal(startAllocs, endAllocs);
            Assert.Equal(iList.Count, i);
        }
    }
}
