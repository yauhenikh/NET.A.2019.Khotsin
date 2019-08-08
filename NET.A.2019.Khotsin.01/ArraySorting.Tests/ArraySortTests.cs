using Xunit;

namespace ArraySorting.Tests
{
    public class ArraySortTests
    {
        [Theory]
        [InlineData(new int[] { -1000, int.MinValue, int.MaxValue }, new int[] { int.MinValue, -1000, int.MaxValue })]
        [InlineData(new int[] { 1, 3, -222, 43, 546547, 23, -55 }, new int[] { -222, -55, 1, 3, 23, 43, 546547 })]
        [InlineData(new int[] { 999999, 10, 100, 10000 }, new int[] { 10, 100, 10000, 999999 })]
        public void SortIntegerArrayUsingQuicksort(int[] values, int[] expected)
        {
            // Arrange
            // Act
            values.QuickSort();

            // Assert
            Assert.Equal(expected, values);
        }

        [Theory]
        [InlineData(new int[] { 1000000, 20, -100, 11 }, new int[] { -100, 11, 20, 1000000 })]
        [InlineData(new int[] { 1, 2, 3, 4, 10, 9, 8, 8, 8 }, new int[] { 1, 2, 3, 4, 8, 8, 8, 9, 10 })]
        [InlineData(new int[] { -1000, int.MinValue, int.MaxValue, int.MinValue }, new int[] { int.MinValue, int.MinValue, -1000, int.MaxValue })]   
        public void SortIntegerArrayUsingMergeSort(int[] values, int[] expected)
        {
            // Arrange
            // Act
            values.MergeSort();

            // Assert
            Assert.Equal(expected, values);
        }
    }
}
