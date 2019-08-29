using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JaggedArraySortRefactoring.Tests
{
    [TestClass]
    public class JaggedArraySortRefactoringTests
    {
        [DataTestMethod]
        [DynamicData(nameof(GetData_For_SortByRowElementsSumTests), DynamicDataSourceType.Method)]
        public void SortByRowElementsSumTests_FirstWay(int[][] jaggedArray, int[][] expected)
        {
            // Arrange
            // Act
            JaggedArraySortFirstWay.SortByRowElementsSum(jaggedArray);

            // Assert
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], jaggedArray[i]);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData_For_SortByRowElementsSumTests), DynamicDataSourceType.Method)]
        public void SortByRowElementsSumTests_SecondWay(int[][] jaggedArray, int[][] expected)
        {
            // Arrange
            // Act
            JaggedArraySortSecondWay.SortByRowElementsSum(jaggedArray);

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
        public void SortByRowElementsSumReverseTests_FirstWay(int[][] jaggedArray, int[][] expected)
        {
            // Arrange
            // Act
            JaggedArraySortFirstWay.SortByRowElementsSumReverse(jaggedArray);

            // Assert
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], jaggedArray[i]);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData_For_SortByRowElementsSumReverseTests), DynamicDataSourceType.Method)]
        public void SortByRowElementsSumReverseTests_SecondWay(int[][] jaggedArray, int[][] expected)
        {
            // Arrange
            // Act
            JaggedArraySortSecondWay.SortByRowElementsSumReverse(jaggedArray);

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
        public void SortByRowMaximumElementTests_FirstWay(int[][] jaggedArray, int[][] expected)
        {
            // Arrange
            // Act
            JaggedArraySortFirstWay.SortByRowMaximumElement(jaggedArray);

            // Assert
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], jaggedArray[i]);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData_For_SortByRowMaximumElementTests), DynamicDataSourceType.Method)]
        public void SortByRowMaximumElementTests_SecondWay(int[][] jaggedArray, int[][] expected)
        {
            // Arrange
            // Act
            JaggedArraySortSecondWay.SortByRowMaximumElement(jaggedArray);

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
        public void SortByRowMaximumElementReverseTests_FirstWay(int[][] jaggedArray, int[][] expected)
        {
            // Arrange
            // Act
            JaggedArraySortFirstWay.SortByRowMaximumElementReverse(jaggedArray);

            // Assert
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], jaggedArray[i]);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData_For_SortByRowMaximumElementReverseTests), DynamicDataSourceType.Method)]
        public void SortByRowMaximumElementReverseTests_SecondWay(int[][] jaggedArray, int[][] expected)
        {
            // Arrange
            // Act
            JaggedArraySortSecondWay.SortByRowMaximumElementReverse(jaggedArray);

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
        public void SortByRowMinimumElementTests_FirstWay(int[][] jaggedArray, int[][] expected)
        {
            // Arrange
            // Act
            JaggedArraySortFirstWay.SortByRowMinimumElement(jaggedArray);

            // Assert
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], jaggedArray[i]);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData_For_SortByRowMinimumElementTests), DynamicDataSourceType.Method)]
        public void SortByRowMinimumElementTests_SecondWay(int[][] jaggedArray, int[][] expected)
        {
            // Arrange
            // Act
            JaggedArraySortSecondWay.SortByRowMinimumElement(jaggedArray);

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
        public void SortByRowMinimumElementReverseTests_FirstWay(int[][] jaggedArray, int[][] expected)
        {
            // Arrange
            // Act
            JaggedArraySortFirstWay.SortByRowMinimumElementReverse(jaggedArray);

            // Assert
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], jaggedArray[i]);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData_For_SortByRowMinimumElementReverseTests), DynamicDataSourceType.Method)]
        public void SortByRowMinimumElementReverseTests_SecondWay(int[][] jaggedArray, int[][] expected)
        {
            // Arrange
            // Act
            JaggedArraySortSecondWay.SortByRowMinimumElementReverse(jaggedArray);

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
