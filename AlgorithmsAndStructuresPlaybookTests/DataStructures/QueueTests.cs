using AlgorithmsAndStructuresPlaybook.DataStructures.Queue;

namespace AlgorithmsAndStructuresPlaybook.Tests.DataStructures
{
    [TestClass]
    public class QueueTests
    {
        [TestMethod]
        public void Constructor_WithoutParams_Success()
        {
            // Act
            var queue = new Queue();

            // Assert
            Assert.AreEqual(0, queue.Count);
            Assert.AreEqual(10, queue.Capacity);
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(5)]
        [DataRow(15)]
        [DataRow(100)]
        public void Constructor_WithCapacityParam_Success(int capacity)
        {
            // Act
            var queue = new Queue(capacity);

            // Assert
            Assert.AreEqual(0, queue.Count);
            Assert.AreEqual(capacity, queue.Capacity);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(-10)]
        public void Constructor_WithNonPositiveCapacityParam_Failure(int capacity)
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Queue(capacity));
        }

        [DataTestMethod]
        [DataRow(1, 1, new int[] { 100 })]
        [DataRow(2, 4, new int[] { 1, 2, 3, 4 })]
        [DataRow(2, 8, new int[] { 5, 6, 7, 8, 9 })]
        [DataRow(10, 10, new int[] { })]
        [DataRow(15, 30, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Enqueue_CheckCapacityExpansion(int initialCapacity, int expectedFinalCapacity, int[] data)
        {
            // Arrange
            var queue = new Queue(initialCapacity);

            // Act
            foreach (var item in data)
            {
                queue.Enqueue(item);
            }

            // Assert
            Assert.AreEqual(queue.Count, data.Length);
            Assert.AreEqual(queue.Capacity, expectedFinalCapacity);
            for (var index = 0; index < data.Length; index++)
            {
                var queueItem = queue.Dequeue();
                var dataItem = data[index];
                Assert.AreEqual(
                    queueItem,
                    dataItem,
                    $"Values at index {index} doesn't match; Expected: {dataItem}; Actual: {queueItem}"
                );
            }

            Assert.AreEqual(queue.Count, 0);
            Assert.AreEqual(queue.Capacity, expectedFinalCapacity);
        }

        [DataTestMethod]
        [DataRow(1, 2, new int[] { 100 })]
        [DataRow(1, 16, new int[] { 100, 200, 300, 400, 500, 600, 700, 800 })]
        [DataRow(2, 8, new int[] { 1, 2, 3, 4 })]
        [DataRow(2, 8, new int[] { 5, 6, 7, 8, 9 })]
        [DataRow(10, 10, new int[] { })]
        [DataRow(15, 30, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        [DataRow(30, 30, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Enqueue_CheckCapacityExpansionAfterDequeue(int initialCapacity, int expectedFinalCapacity, int[] data)
        {
            // Arrange
            var queue = new Queue(initialCapacity);

            var predefinedItem1 = -10;
            var predefinedItem2 = -5;
            queue.Enqueue(predefinedItem1);
            queue.Enqueue(predefinedItem2);

            var expectedFirstItem = predefinedItem1;
            var firstQueueItem = queue.Dequeue();
            Assert.AreEqual(firstQueueItem, expectedFirstItem);

            // Act
            foreach (var item in data)
            {
                queue.Enqueue(item);
            }

            // Assert
            var expectedSecondItem = predefinedItem2;
            var secondQueueItem = queue.Dequeue();
            Assert.AreEqual(secondQueueItem, expectedSecondItem);

            Assert.AreEqual(queue.Count, data.Length);
            Assert.AreEqual(queue.Capacity, expectedFinalCapacity);
            for (var index = 0; index < data.Length; index++)
            {
                var queueItem = queue.Dequeue();
                var dataItem = data[index];
                Assert.AreEqual(
                    queueItem,
                    dataItem,
                    $"Values at index {index} doesn't match; Expected: {dataItem}; Actual: {queueItem}"
                );
            }

            Assert.AreEqual(queue.Count, 0);
            Assert.AreEqual(queue.Capacity, expectedFinalCapacity);
        }

        [DataTestMethod]
        [DataRow(2, new int[] { 100 })]
        [DataRow(10, new int[] { 100, 200, 300, 400, 500, 600, 700, 800 })]
        [DataRow(6, new int[] { 1, 2, 3, 4 })]
        [DataRow(5, new int[] { 1, 2, 3, 4 })]
        [DataRow(6, new int[] { 5, 6, 7, 8, 9 })]
        [DataRow(10, new int[] { })]
        [DataRow(30, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Enqueue_NoCapacityExpansionAfterDequeue(int expectedCapacity, int[] data)
        {
            // Arrange
            var queue = new Queue(expectedCapacity);

            var predefinedItem1 = -10;
            var predefinedItem2 = -5;
            queue.Enqueue(predefinedItem1);
            queue.Enqueue(predefinedItem2);

            var expectedFirstItem = predefinedItem1;
            var firstQueueItem = queue.Dequeue();
            Assert.AreEqual(firstQueueItem, expectedFirstItem);

            // Act
            foreach (var item in data)
            {
                queue.Enqueue(item);
            }

            // Assert
            var expectedSecondItem = predefinedItem2;
            var secondQueueItem = queue.Dequeue();
            Assert.AreEqual(secondQueueItem, expectedSecondItem);

            Assert.AreEqual(queue.Count, data.Length);
            Assert.AreEqual(queue.Capacity, expectedCapacity);
            for (var index = 0; index < data.Length; index++)
            {
                var queueItem = queue.Dequeue();
                var dataItem = data[index];
                Assert.AreEqual(
                    queueItem,
                    dataItem,
                    $"Values at index {index} doesn't match; Expected: {dataItem}; Actual: {queueItem}"
                );
            }

            Assert.AreEqual(queue.Count, 0);
            Assert.AreEqual(queue.Capacity, expectedCapacity);
        }

        [DataTestMethod]
        [DataRow(new int[0])]
        [DataRow(new int[] { 1, 2, 3 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void Dequeue_ReturnFirst_FailureOnEmpty(int[] data)
        {
            // Arrange
            var queue = new Queue();

            foreach (var item in data)
            {
                queue.Enqueue(item);
            }

            // Act
            for (var index = 0; index < data.Length; index++)
            {
                var queueItem = queue.Dequeue();
                var dataItem = data[index];
                Assert.AreEqual(
                    queueItem,
                    dataItem,
                    $"Values at index {index} doesn't match; Expected: {dataItem}; Actual: {queueItem}"
                );
            }

            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() => queue.Dequeue(), $"Queue is not empty");
        }

        [DataTestMethod]
        [DataRow(new int[0])]
        [DataRow(new int[] { 1, 2, 3 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void Peek_ReturnFirst_FailureOnEmpty(int[] data)
        {
            // Arrange
            var queue = new Queue();

            foreach (var item in data)
            {
                queue.Enqueue(item);
            }

            // Act
            for (var index = 0; index < data.Length; index++)
            {
                var queuePeekedItem = queue.Peek();
                var dataItem = data[index];
                Assert.AreEqual(
                    queuePeekedItem,
                    dataItem,
                    $"Values at index {index} doesn't match; Expected: {dataItem}; Actual: {queuePeekedItem}"
                );

                var queuePoppedItem = queue.Dequeue();
                Assert.AreEqual(
                    queuePeekedItem,
                    queuePoppedItem,
                    $"Return values of Peek and Dequeue methods are not matched; Dequeued: {queuePoppedItem}; Peeked: {queuePeekedItem}"
                );
            }

            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() => queue.Peek(), $"Queue is not empty");
        }

        [TestMethod]
        public void ShrinkToFit_CapacityIsAlwaysPositive()
        {
            // Arrange
            var queue = new Queue();

            // Act
            queue.ShrinkToFit();

            // Assert
            Assert.AreEqual(queue.Count, 0);
            Assert.AreEqual(queue.Capacity, 1);
            Assert.ThrowsException<InvalidOperationException>(() => queue.Peek(), $"Queue is not empty");

            // Act
            queue.Enqueue(10);
            queue.Enqueue(20);

            Assert.AreEqual(queue.Count, 2);
            Assert.AreEqual(queue.Capacity, 2);
            Assert.AreEqual(queue.Dequeue(), 10);
            Assert.AreEqual(queue.Dequeue(), 20);
        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 3 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 })]
        public void ShrinkToFit_CapacityReallocated(int[] data)
        {
            // Arrange
            var queue = new Queue();

            foreach (var item in data)
            {
                queue.Enqueue(item);
            }

            // Act
            queue.ShrinkToFit();

            // Assert
            Assert.AreEqual(queue.Count, data.Length);
            Assert.AreEqual(queue.Capacity, data.Length);
            for (var index = 0; index < data.Length; index++)
            {
                var queueItem = queue.Dequeue();
                var dataItem = data[index];
                Assert.AreEqual(
                    queueItem,
                    dataItem,
                    $"Values at index {index} doesn't match; Expected: {dataItem}; Actual: {queueItem}"
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
            var queue = new Queue();

            foreach (var item in initialData)
            {
                queue.Enqueue(item);
            }

            // Act
            queue.ShrinkToFit();

            // Assert
            Assert.AreEqual(queue.Count, initialData.Length);
            Assert.AreEqual(queue.Capacity, initialData.Length);

            // Act - validate expansion
            foreach (var item in newData)
            {
                queue.Enqueue(item);
            }

            // Assert
            Assert.AreEqual(queue.Count, initialData.Length + newData.Length);
            Assert.AreEqual(queue.Capacity, expectedCapacity);

            for (var index = 0; index < initialData.Length; index++)
            {
                var queueItem = queue.Dequeue();
                var initialDataItem = initialData[index];
                Assert.AreEqual(
                    queueItem,
                    initialDataItem,
                    $"Values at index {index} doesn't match; Expected: {initialDataItem}; Actual: {queueItem}"
                );
            }
            for (var index = 0; index < newData.Length; index++)
            {
                var queueItem = queue.Dequeue();
                var newDataItem = newData[index];
                Assert.AreEqual(
                    queueItem,
                    newDataItem,
                    $"Values at index {index} doesn't match; Expected: {newDataItem}; Actual: {queueItem}"
                );
            }
        }
    }
}
