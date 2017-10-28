using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Xunit;

namespace Enumerable
{
    public class ImmutableArray
    {
        [Fact]
        public void EnumerationSame()
        {
            // Arrange
            IList<int> iList = new[] { 1, 2, 3, 4, 5, 6, 7 }.ToImmutableArray();

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
            IList<int> iList = System.Array.Empty<int>().ToImmutableArray();

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
            IList<int> iList = new[] { 1, 2, 3, 4, 5, 6, 7 }.ToImmutableArray();

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
