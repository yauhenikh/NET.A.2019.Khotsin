using Day6.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Day6.Tests
{
    [TestClass]
    public class JaggedArraySortTests
    {
        [DataTestMethod]
        [DynamicData(nameof(GetData_For_SortByRowElementsSumTests), DynamicDataSourceType.Method)]
        public void SortByRowElementsSumTests(int[][] jaggedArray, int[][] expected)
        {
            // Arrange
            // Act
            JaggedArraySort.SortByRowElementsSum(jaggedArray);

            // Assert
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], jaggedArray[i]);
            }
        }

        public static IEnumerable<object[]> GetData_For_SortByRowElementsSumTests()
        {
            int[][] jaggedArray1 =
            {
                new int[] { 1, 2, 3, 4 },
                new int[] { 11, 34, 67 },
                new int[] { 89, 23},
                new int[] { 0, 45, 78, 53, 99 }
            };

            int[][] jaggedArray1sorted =
            {
                new int[] { 1, 2, 3, 4 },
                new int[] { 11, 34, 67 },
                new int[] { 89, 23},
                new int[] { 0, 45, 78, 53, 99 }
            };

            int[][] jaggedArray2 =
            {
                new int[] { },
                new int[] { 23, 10 },
                new int[] { },
                new int[] { 1, 3, 5, 11, 7, 9 },
                new int[] { 2, 4, 6 },
                new int[] { 11, 22 }
            };

            int[][] jaggedArray2sorted =
            {
                new int[] { },
                new int[] { },
                new int[] { 2, 4, 6 },
                new int[] { 23, 10 },
                new int[] { 11, 22 },
                new int[] { 1, 3, 5, 11, 7, 9 }
            };

            yield return new object[] { jaggedArray1, jaggedArray1sorted };
            yield return new object[] { jaggedArray2, jaggedArray2sorted };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData_For_SortByRowElementsSumReverseTests), DynamicDataSourceType.Method)]
        public void SortByRowElementsSumReverseTests(int[][] jaggedArray, int[][] expected)
        {
            // Arrange
            // Act
            JaggedArraySort.SortByRowElementsSumReverse(jaggedArray);

            // Assert
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], jaggedArray[i]);
            }
        }

        public static IEnumerable<object[]> GetData_For_SortByRowElementsSumReverseTests()
        {
            int[][] jaggedArray1 =
            {
                new int[] { 1, 2, 3, 4 },
                new int[] { 11, 34, 67 },
                new int[] { 89, 23},
                new int[] { 0, 45, 78, 53, 99 }
            };

            int[][] jaggedArray1sorted =
            { 
                new int[] { 0, 45, 78, 53, 99 },
                new int[] { 11, 34, 67 },
                new int[] { 89, 23},
                new int[] { 1, 2, 3, 4 }
            };

            int[][] jaggedArray2 =
            {
                new int[] { },
                new int[] { 23, 10 },
                new int[] { },
                new int[] { 1, 3, 5, 11, 7, 9 },
                new int[] { 2, 4, 6 },
                new int[] { 11, 22 }
            };

            int[][] jaggedArray2sorted =
            {
                new int[] { 1, 3, 5, 11, 7, 9 },
                new int[] { 23, 10 },
                new int[] { 11, 22 },
                new int[] { 2, 4, 6 },
                new int[] { },
                new int[] { }
            };

            yield return new object[] { jaggedArray1, jaggedArray1sorted };
            yield return new object[] { jaggedArray2, jaggedArray2sorted };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData_For_SortByRowMaximumElementTests), DynamicDataSourceType.Method)]
        public void SortByRowMaximumElementTests(int[][] jaggedArray, int[][] expected)
        {
            // Arrange
            // Act
            JaggedArraySort.SortByRowMaximumElement(jaggedArray);

            // Assert
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], jaggedArray[i]);
            }
        }

        public static IEnumerable<object[]> GetData_For_SortByRowMaximumElementTests()
        {
            int[][] jaggedArray1 =
            {
                new int[] { 1, 2, 3, 4 },
                new int[] { 11, 34, 67 },
                new int[] { 89, 23},
                new int[] { 0, 45, 78, 53, 99 }
            };

            int[][] jaggedArray1sorted = 
            {
                new int[] { 1, 2, 3, 4 },
                new int[] { 11, 34, 67 },
                new int[] { 89, 23},
                new int[] { 0, 45, 78, 53, 99 }
            };

            int[][] jaggedArray2 =
            {
                new int[] { },
                new int[] { 23, 10 },
                new int[] { },
                new int[] { 1, 3, 5, 11, 7, 9 },
                new int[] { 2, 4, 6 },
                new int[] { 11, 22 }
            };

            int[][] jaggedArray2sorted =
            {
                new int[] { },
                new int[] { },
                new int[] { 2, 4, 6 },
                new int[] { 1, 3, 5, 11, 7, 9 },
                new int[] { 11, 22 },
                new int[] { 23, 10 }
            };

            yield return new object[] { jaggedArray1, jaggedArray1sorted };
            yield return new object[] { jaggedArray2, jaggedArray2sorted };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData_For_SortByRowMaximumElementReverseTests), DynamicDataSourceType.Method)]
        public void SortByRowMaximumElementReverseTests(int[][] jaggedArray, int[][] expected)
        {
            // Arrange
            // Act
            JaggedArraySort.SortByRowMaximumElementReverse(jaggedArray);

            // Assert
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], jaggedArray[i]);
            }
        }

        public static IEnumerable<object[]> GetData_For_SortByRowMaximumElementReverseTests()
        {
            int[][] jaggedArray1 =
            {
                new int[] { 1, 2, 3, 4 },
                new int[] { 11, 34, 67 },
                new int[] { 89, 23},
                new int[] { 0, 45, 78, 53, 99 }
            };

            int[][] jaggedArray1sorted =
            {
                new int[] { 0, 45, 78, 53, 99 },
                new int[] { 89, 23},
                new int[] { 11, 34, 67 },
                new int[] { 1, 2, 3, 4 }
            };

            int[][] jaggedArray2 =
            {
                new int[] { },
                new int[] { 23, 10 },
                new int[] { },
                new int[] { 1, 3, 5, 11, 7, 9 },
                new int[] { 2, 4, 6 },
                new int[] { 11, 22 }
            };

            int[][] jaggedArray2sorted =
            {
                new int[] { 23, 10 },
                new int[] { 11, 22 },
                new int[] { 1, 3, 5, 11, 7, 9 },
                new int[] { 2, 4, 6 },
                new int[] { },
                new int[] { }
            };

            yield return new object[] { jaggedArray1, jaggedArray1sorted };
            yield return new object[] { jaggedArray2, jaggedArray2sorted };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData_For_SortByRowMinimumElementTests), DynamicDataSourceType.Method)]
        public void SortByRowMinimumElementTests(int[][] jaggedArray, int[][] expected)
        {
            // Arrange
            // Act
            JaggedArraySort.SortByRowMinimumElement(jaggedArray);

            // Assert
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], jaggedArray[i]);
            }
        }

        public static IEnumerable<object[]> GetData_For_SortByRowMinimumElementTests()
        {
            int[][] jaggedArray1 =
            {
                new int[] { 1, 2, 3, 4 },
                new int[] { 11, 34, 67 },
                new int[] { 89, 23},
                new int[] { 0, 45, 78, 53, 99 }
            };

            int[][] jaggedArray1sorted =
            {
                new int[] { 0, 45, 78, 53, 99 },
                new int[] { 1, 2, 3, 4 },
                new int[] { 11, 34, 67 },
                new int[] { 89, 23}
            };

            int[][] jaggedArray2 =
            {
                new int[] { },
                new int[] { 23, 10 },
                new int[] { },
                new int[] { 1, 3, 5, 11, 7, 9 },
                new int[] { 2, 4, 6 },
                new int[] { 11, 22 }
            };

            int[][] jaggedArray2sorted =
            {
                new int[] { },
                new int[] { },
                new int[] { 1, 3, 5, 11, 7, 9 },
                new int[] { 2, 4, 6 },
                new int[] { 23, 10 },
                new int[] { 11, 22 }
            };

            yield return new object[] { jaggedArray1, jaggedArray1sorted };
            yield return new object[] { jaggedArray2, jaggedArray2sorted };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData_For_SortByRowMinimumElementReverseTests), DynamicDataSourceType.Method)]
        public void SortByRowMinimumElementReverseTests(int[][] jaggedArray, int[][] expected)
        {
            // Arrange
            // Act
            JaggedArraySort.SortByRowMinimumElementReverse(jaggedArray);

            // Assert
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], jaggedArray[i]);
            }
        }

        public static IEnumerable<object[]> GetData_For_SortByRowMinimumElementReverseTests()
        {
            int[][] jaggedArray1 =
            {
                new int[] { 1, 2, 3, 4 },
                new int[] { 11, 34, 67 },
                new int[] { 89, 23},
                new int[] { 0, 45, 78, 53, 99 }
            };

            int[][] jaggedArray1sorted =
            {
                new int[] { 89, 23},
                new int[] { 11, 34, 67 },
                new int[] { 1, 2, 3, 4 },
                new int[] { 0, 45, 78, 53, 99 }
            };

            int[][] jaggedArray2 =
            {
                new int[] { },
                new int[] { 23, 10 },
                new int[] { },
                new int[] { 1, 3, 5, 11, 7, 9 },
                new int[] { 2, 4, 6 },
                new int[] { 11, 22 }
            };

            int[][] jaggedArray2sorted =
            {
                new int[] { 11, 22 },
                new int[] { 23, 10 },
                new int[] { 2, 4, 6 },
                new int[] { 1, 3, 5, 11, 7, 9 },
                new int[] { },
                new int[] { }
            };

            yield return new object[] { jaggedArray1, jaggedArray1sorted };
            yield return new object[] { jaggedArray2, jaggedArray2sorted };
        }
    }
}
