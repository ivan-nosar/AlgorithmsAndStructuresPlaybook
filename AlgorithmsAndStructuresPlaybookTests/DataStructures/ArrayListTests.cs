using AlgorithmsAndStructuresPlaybook.DataStructures.ArrayList;

namespace AlgorithmsAndStructuresPlaybookTests.DataStructures
{
    [TestClass]
    public class ArrayListTests
    {
        [TestMethod]
        public void Constructor_WithoutParams_Success()
        {
            // Act
            var arrayList = new ArrayList();

            // Assert
            Assert.AreEqual(0, arrayList.Count);
            Assert.AreEqual(10, arrayList.Capacity);
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(5)]
        [DataRow(15)]
        [DataRow(100)]
        public void Constructor_WithCapacityParam_Success(int capacity)
        {
            // Act
            var arrayList = new ArrayList(capacity);

            // Assert
            Assert.AreEqual(0, arrayList.Count);
            Assert.AreEqual(capacity, arrayList.Capacity);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(-10)]
        public void Constructor_WithNonPositiveCapacityParam_Failure(int capacity)
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new ArrayList(capacity));
        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 3 })]
        [DataRow(new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 })]
        [DataRow(new int[] { -63, 57, 13, 48, 89, -99, 64, -32, 57, 11, 79, -35, 26, 64 })]
        public void Indexer_GetAndSet_Success(int[] data)
        {
            // Arrange
            var arrayList = new ArrayList();

            var firstIndex = 0;
            var middleIndex = data.Length / 2;
            var lastIndex = data.Length - 1;

            var firstUniqueValue = 999;
            var middleUniqueValue = 888;
            var lastUniqueValue = 777;

            // Act
            foreach (var item in data)
            {
                arrayList.Add(item);
            }

            // Assert
            Assert.AreEqual(arrayList.Count, data.Length);
            Assert.AreEqual(arrayList[firstIndex], data[firstIndex]);
            Assert.AreEqual(arrayList[middleIndex], data[middleIndex]);
            Assert.AreEqual(arrayList[lastIndex], data[lastIndex]);

            // Act
            arrayList[firstIndex] = firstUniqueValue;
            arrayList[middleIndex] = middleUniqueValue;
            arrayList[lastIndex] = lastUniqueValue;

            // Assert
            Assert.AreEqual(arrayList.Count, data.Length);
            Assert.AreEqual(arrayList[firstIndex], firstUniqueValue);
            Assert.AreEqual(arrayList[middleIndex], middleUniqueValue);
            Assert.AreEqual(arrayList[lastIndex], lastUniqueValue);
        }

        [DataTestMethod]
        [DataRow(new int[0], new int[] { -1, 0, 1 })]
        [DataRow(new int[] { 10, 20, 30 }, new int[] { -10, -1, 3, 10 })]
        [DataRow(new int[] { -63, 57, 13, 48, 89, -99, 64, -32 }, new int[] { -20, -1, 8, 9 })]
        public void Indexer_GetAndSet_Failure(int[] data, int[] indices)
        {
            // Arrange
            var arrayList = new ArrayList();
            var uniqueValue = 999;

            foreach (var item in data)
            {
                arrayList.Add(item);
            }

            var finalCapacity = arrayList.Capacity;

            // Act & Assert
            foreach (var index in indices)
            {
                Assert.ThrowsException<IndexOutOfRangeException>(() => arrayList[index], $"Index {index} is present in collection");
                Assert.ThrowsException<IndexOutOfRangeException>(() => arrayList[index] = uniqueValue, $"Index {index} is overridable in collection");

                Assert.AreEqual(arrayList.Count, data.Length);
                Assert.AreEqual(arrayList.Capacity, finalCapacity);
            }
        }

        [DataTestMethod]
        [DataRow(1, 1, new int[] { 100 })]
        [DataRow(2, 4, new int[] { 1, 2, 3, 4 })]
        [DataRow(2, 8, new int[] { 5, 6, 7, 8, 9 })]
        [DataRow(10, 10, new int[] { })]
        [DataRow(15, 30, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Add_CheckCapacityExpansion(int initialCapacity, int expectedFinalCapacity, int[] data)
        {
            // Arrange
            var arrayList = new ArrayList(initialCapacity);

            // Act
            foreach (var item in data)
            {
                arrayList.Add(item);
            }

            // Assert
            Assert.AreEqual(arrayList.Count, data.Length);
            Assert.AreEqual(arrayList.Capacity, expectedFinalCapacity);
            for (var index = 0; index < arrayList.Count; index++)
            {
                Assert.AreEqual(
                    arrayList[index],
                    data[index],
                    $"Values at index {index} doesn't match; Expected: {data[index]}; Actual: {arrayList[index]}"
                );
            }
        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 3 }, new int[] { 0, 0, 0 }, new int[0])]
        [DataRow(new int[] { 4, 5, 6 }, new int[] { 2, 1, 0 }, new int[0])]
        [DataRow(new int[] { 7, 8, 9 }, new int[] { 2, 0, 0 }, new int[0])]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 0, 1, 2, 3 }, new int[] { 2, 4, 6, 8, 9, 10 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 9, 5, 7, 5 }, new int[] { 1, 2, 3, 4, 5, 8 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }, new int[] { 9, 5, 10, 1, 8 }, new int[] { 1, 3, 4, 5, 7, 8, 9, 11 })]
        public void RemoveFromIndex_Success(int[] data, int[] indicesToRemove, int[] expectedData)
        {
            // Arrange
            var arrayList = new ArrayList();

            foreach (var item in data)
            {
                arrayList.Add(item);
            }

            var finalCapacity = arrayList.Capacity;

            // Act
            foreach (var index in indicesToRemove)
            {
                arrayList.RemoveFromIndex(index);
            }

            // Assert
            Assert.AreEqual(arrayList.Count, expectedData.Length);
            Assert.AreEqual(arrayList.Capacity, finalCapacity);

            for (var index = 0; index < expectedData.Length; index++)
            {
                Assert.AreEqual(
                    arrayList[index],
                    expectedData[index],
                    $"Values at indexes {index} doesn't match; " +
                        $"Expected: {expectedData[index]}; Actual: {arrayList[index]}"
                );
            }
        }

        [DataTestMethod]
        [DataRow(new int[0], new int[] { -10, -1, 0, 1, 10 })]
        [DataRow(new int[] { 1, 2, 3 }, new int[] { -10, -1, 3, 4, 10 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { -100, -2, -1, 10, 11, 100 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, new int[] { -20, -2, -1, 15, 16, 50 })]
        public void RemoveFromIndex_Failure(int[] data, int[] indicesToRemove)
        {
            // Arrange
            var arrayList = new ArrayList();

            foreach (var item in data)
            {
                arrayList.Add(item);
            }

            var finalCapacity = arrayList.Capacity;

            // Act & Assert
            foreach (var index in indicesToRemove)
            {
                Assert.ThrowsException<IndexOutOfRangeException>(
                    () => arrayList.RemoveFromIndex(index),
                    $"Index {index} is present in collection"
                );
                Assert.AreEqual(arrayList.Count, data.Length);
                Assert.AreEqual(arrayList.Capacity, finalCapacity);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData_InsertAtIndex_Success), DynamicDataSourceType.Method)]
        public void InsertAtIndex_Success(int[] data, (int, int)[] pairsToInsert, int expectedFinalCapacity, int[] expectedData)
        {
            // Arrange
            var arrayList = new ArrayList();

            foreach (var item in data)
            {
                arrayList.Add(item);
            }

            // Act
            foreach (var pair in pairsToInsert)
            {
                var (index, value) = pair;
                arrayList.InsertAtIndex(index, value);
            }

            // Assert
            Assert.AreEqual(arrayList.Count, expectedData.Length);
            Assert.AreEqual(arrayList.Capacity, expectedFinalCapacity);

            for (var index = 0; index < expectedData.Length; index++)
            {
                Assert.AreEqual(
                    arrayList[index],
                    expectedData[index],
                    $"Values at indexes {index} doesn't match; " +
                        $"Expected: {expectedData[index]}; Actual: {arrayList[index]}"
                );
            }
        }

        private static IEnumerable<object[]> GetData_InsertAtIndex_Success()
        {
            yield return new object[] { new int[0], new (int, int)[] { (0, 3), (0, 2), (0, 1) }, 10, new int[] { 1, 2, 3 } };
            yield return new object[] { new int[0], new (int, int)[] { (0, 1), (1, 2), (2, 3) }, 10, new int[] { 1, 2, 3 } };
            yield return new object[] { new int[0], new (int, int)[] { (0, 3), (0, 1), (1, 2) }, 10, new int[] { 1, 2, 3 } };
            yield return new object[]
            {
                new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
                new (int, int)[] { (10, 11), (11, 12), (0, 0) },
                20,
                new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }
            };
            yield return new object[]
            {
                new int[] { 10, 20, 30, 40, 50, 60, 70 },
                new (int, int)[] { (3, 35), (5, 45), (5, 42) },
                10,
                new int[] { 10, 20, 30, 35, 40, 42, 45, 50, 60, 70 }
            };
        }

        [DataTestMethod]
        [DataRow(new int[0], new int[] { -10, -1, 1, 2, 10 })]
        [DataRow(new int[] { 1, 2, 3 }, new int[] { -10, -1, 4, 5, 10 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { -100, -2, -1, 11, 12, 100 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, new int[] { -20, -2, -1, 16, 17, 50 })]
        public void InsertAtIndex_Failure(int[] data, int[] indicesToInsert)
        {
            // Arrange
            var arrayList = new ArrayList();

            foreach (var item in data)
            {
                arrayList.Add(item);
            }

            var uniqueValue = 999;

            var finalCapacity = arrayList.Capacity;

            // Act & Assert
            foreach (var index in indicesToInsert)
            {
                Assert.ThrowsException<IndexOutOfRangeException>(
                    () => arrayList.InsertAtIndex(index, uniqueValue),
                    $"Index {index} is present in collection"
                );
                Assert.AreEqual(arrayList.Count, data.Length);
                Assert.AreEqual(arrayList.Capacity, finalCapacity);
            }
        }

        [TestMethod]
        public void ShrinkToFit_CapacityIsAlwaysPositive()
        {
            // Arrange
            var arrayList = new ArrayList();

            // Act
            arrayList.ShrinkToFit();

            // Assert
            Assert.AreEqual(arrayList.Count, 0);
            Assert.AreEqual(arrayList.Capacity, 1);
            Assert.ThrowsException<IndexOutOfRangeException>(() => arrayList[0], $"Index {0} is present in collection");

            // Act
            arrayList.Add(1);
            arrayList.Add(2);

            Assert.AreEqual(arrayList.Count, 2);
            Assert.AreEqual(arrayList.Capacity, 2);
            Assert.AreEqual(arrayList[0], 1);
            Assert.AreEqual(arrayList[1], 2);
        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 3 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 })]
        public void ShrinkToFit_CapacityReallocated(int[] data)
        {
            // Arrange
            var arrayList = new ArrayList();

            foreach (var item in data)
            {
                arrayList.Add(item);
            }

            // Act
            arrayList.ShrinkToFit();

            // Assert
            Assert.AreEqual(arrayList.Count, data.Length);
            Assert.AreEqual(arrayList.Capacity, data.Length);
            Assert.ThrowsException<IndexOutOfRangeException>(() => arrayList[arrayList.Count], $"Index {arrayList.Count} is present in collection");
            for (var index = 0; index < arrayList.Count; index++)
            {
                Assert.AreEqual(
                    arrayList[index],
                    data[index],
                    $"Values at index {index} doesn't match; Expected: {data[index]}; Actual: {arrayList[index]}"
                );
            }
        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 3 }, new int[0], 3)]
        [DataRow(new int[] { 1, 2, 3 }, new int[] { 4 }, 6)]
        [DataRow(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, 6)]
        [DataRow(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6, 7 }, 12)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[0], 10)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 11, 12, 13, 14, 15, 16 }, 20)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }, new int[0], 13)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }, new int[] { 14 }, 26)]
        public void ShrinkToFit_CheckCapacityExpansion(int[] initialData, int[] newData, int expectedCapacity)
        {
            // Arrange
            var arrayList = new ArrayList();

            foreach (var item in initialData)
            {
                arrayList.Add(item);
            }

            // Act
            arrayList.ShrinkToFit();

            // Assert
            Assert.AreEqual(arrayList.Count, initialData.Length);
            Assert.AreEqual(arrayList.Capacity, initialData.Length);

            // Act - validate expansion
            foreach (var item in newData)
            {
                arrayList.Add(item);
            }

            // Assert
            Assert.AreEqual(arrayList.Count, initialData.Length + newData.Length);
            Assert.AreEqual(arrayList.Capacity, expectedCapacity);
            for (var index = 0; index < initialData.Length; index++)
            {
                Assert.AreEqual(
                    arrayList[index],
                    initialData[index],
                    $"Values at index {index} doesn't match;" +
                        $"Expected: {initialData[index]}; Actual: {arrayList[index]}"
                );
            }
            for (var index = initialData.Length; index < arrayList.Count; index++)
            {
                Assert.AreEqual(
                    arrayList[index],
                    newData[index - initialData.Length],
                    $"Values at index {index} doesn't match;" +
                        $"Expected: {newData[index - initialData.Length]}; Actual: {arrayList[index]}"
                );
            }
        }
    }
}
