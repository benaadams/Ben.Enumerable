using System;
using System.Collections.Generic;
using Xunit;

namespace Enumerable
{
    public class List
    {
        [Fact]
        public void EnumerationSame()
        {
            // Arrange
            IList<int> iList = new List<int> {1, 2, 3, 4, 5, 6, 7};

            // Act
            EnumerableIList<int> eIList = EnumerableIList.Create(iList);

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
            IList<int> iList = new List<int>();

            // Act
            EnumerableIList<int> eIList = EnumerableIList.Create(iList);

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
            IList<int> iList = new List<int> { 1, 2, 3, 4, 5, 6, 7 };

            // Act
            EnumerableIList<int> eIList = EnumerableIList.Create(iList);
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
