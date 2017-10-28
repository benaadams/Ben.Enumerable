using System.Collections.Generic;
using Xunit;

namespace Enumerable
{
    public class Default
    {
        [Fact]
        public void CanEnumerateDefault()
        {
            // Arrange
            EnumerableIList<int> eIList = default(EnumerableIList<int>);

            // Act
            var i = 0;
            foreach (var item in eIList)
            {
                i++;
            }

            // Assert
            Assert.Equal(0, i);
        }

        [Fact]
        public void CanEnumerateEmpty()
        {
            // Arrange
            EnumerableIList<int> eIList = EnumerableIList<int>.Empty;

            // Act
            var i = 0;
            foreach (var item in eIList)
            {
                i++;
            }

            // Assert
            Assert.Equal(0, i);
        }
    }
}
