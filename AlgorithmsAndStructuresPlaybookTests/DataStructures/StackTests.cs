using AlgorithmsAndStructuresPlaybook.DataStructures.Stack;

namespace AlgorithmsAndStructuresPlaybook.Tests.DataStructures
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void Constructor_WithoutParams_Success()
        {
            // Act
            var stack = new Stack();

            // Assert
            Assert.AreEqual(0, stack.Count);
            Assert.AreEqual(10, stack.Capacity);
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(5)]
        [DataRow(15)]
        [DataRow(100)]
        public void Constructor_WithCapacityParam_Success(int capacity)
        {
            // Act
            var stack = new Stack(capacity);

            // Assert
            Assert.AreEqual(0, stack.Count);
            Assert.AreEqual(capacity, stack.Capacity);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(-10)]
        public void Constructor_WithNonPositiveCapacityParam_Failure(int capacity)
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Stack(capacity));
        }

        [DataTestMethod]
        [DataRow(1, 1, new int[] { 100 })]
        [DataRow(2, 4, new int[] { 1, 2, 3, 4 })]
        [DataRow(2, 8, new int[] { 5, 6, 7, 8, 9 })]
        [DataRow(10, 10, new int[] { })]
        [DataRow(15, 30, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Push_CheckCapacityExpansion(int initialCapacity, int expectedFinalCapacity, int[] data)
        {
            // Arrange
            var stack = new Stack(initialCapacity);

            // Act
            foreach (var item in data)
            {
                stack.Push(item);
            }

            // Assert
            Assert.AreEqual(stack.Count, data.Length);
            Assert.AreEqual(stack.Capacity, expectedFinalCapacity);
            for (var index = 0; index < data.Length; index++)
            {
                var stackItem = stack.Pop();
                var dataItem = data[data.Length - 1 - index];
                Assert.AreEqual(
                    stackItem,
                    dataItem,
                    $"Values at index {index} doesn't match; Expected: {dataItem}; Actual: {stackItem}"
                );
            }

            Assert.AreEqual(stack.Count, 0);
            Assert.AreEqual(stack.Capacity, expectedFinalCapacity);
        }

        [DataTestMethod]
        [DataRow(new int[0])]
        [DataRow(new int[] { 1, 2, 3 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void Pop_ReturnLatest_FailureOnEmpty(int[] data)
        {
            // Arrange
            var stack = new Stack();

            foreach (var item in data)
            {
                stack.Push(item);
            }

            // Act
            for (var index = 0; index < data.Length; index++)
            {
                var stackItem = stack.Pop();
                var dataItem = data[data.Length - 1 - index];
                Assert.AreEqual(
                    stackItem,
                    dataItem,
                    $"Values at index {index} doesn't match; Expected: {dataItem}; Actual: {stackItem}"
                );
            }

            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() => stack.Pop(), $"Stack is not empty");
        }

        [DataTestMethod]
        [DataRow(new int[0])]
        [DataRow(new int[] { 1, 2, 3 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void Peek_ReturnLatest_FailureOnEmpty(int[] data)
        {
            // Arrange
            var stack = new Stack();

            foreach (var item in data)
            {
                stack.Push(item);
            }

            // Act
            for (var index = 0; index < data.Length; index++)
            {
                var stackPeekedItem = stack.Peek();
                var dataItem = data[data.Length - 1 - index];
                Assert.AreEqual(
                    stackPeekedItem,
                    dataItem,
                    $"Values at index {index} doesn't match; Expected: {dataItem}; Actual: {stackPeekedItem}"
                );

                var stackPoppedItem = stack.Pop();
                Assert.AreEqual(
                    stackPeekedItem,
                    stackPoppedItem,
                    $"Return values of Peek and Pop methods are not matched; Popped: {stackPoppedItem}; Peeked: {stackPeekedItem}"
                );
            }

            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() => stack.Peek(), $"Stack is not empty");
        }

        [TestMethod]
        public void ShrinkToFit_CapacityIsAlwaysPositive()
        {
            // Arrange
            var stack = new Stack();

            // Act
            stack.ShrinkToFit();

            // Assert
            Assert.AreEqual(stack.Count, 0);
            Assert.AreEqual(stack.Capacity, 1);
            Assert.ThrowsException<InvalidOperationException>(() => stack.Peek(), $"Stack is not empty");

            // Act
            stack.Push(1);
            stack.Push(2);

            Assert.AreEqual(stack.Count, 2);
            Assert.AreEqual(stack.Capacity, 2);
            Assert.AreEqual(stack.Pop(), 2);
            Assert.AreEqual(stack.Pop(), 1);
        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 3 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 })]
        public void ShrinkToFit_CapacityReallocated(int[] data)
        {
            // Arrange
            var stack = new Stack();

            foreach (var item in data)
            {
                stack.Push(item);
            }

            // Act
            stack.ShrinkToFit();

            // Assert
            Assert.AreEqual(stack.Count, data.Length);
            Assert.AreEqual(stack.Capacity, data.Length);
            for (var index = 0; index < data.Length; index++)
            {
                var stackItem = stack.Pop();
                var dataItem = data[data.Length - 1 - index];
                Assert.AreEqual(
                    stackItem,
                    dataItem,
                    $"Values at index {index} doesn't match; Expected: {dataItem}; Actual: {stackItem}"
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
            var stack = new Stack();

            foreach (var item in initialData)
            {
                stack.Push(item);
            }

            // Act
            stack.ShrinkToFit();

            // Assert
            Assert.AreEqual(stack.Count, initialData.Length);
            Assert.AreEqual(stack.Capacity, initialData.Length);

            // Act - validate expansion
            foreach (var item in newData)
            {
                stack.Push(item);
            }

            // Assert
            Assert.AreEqual(stack.Count, initialData.Length + newData.Length);
            Assert.AreEqual(stack.Capacity, expectedCapacity);

            for (var index = 0; index < newData.Length; index++)
            {
                var stackItem = stack.Pop();
                var newDataItem = newData[newData.Length - 1 - index];
                Assert.AreEqual(
                    stackItem,
                    newDataItem,
                    $"Values at index {index} doesn't match; Expected: {newDataItem}; Actual: {stackItem}"
                );
            }
            for (var index = 0; index < initialData.Length; index++)
            {
                var stackItem = stack.Pop();
                var initialDataItem = initialData[initialData.Length - 1 - index];
                Assert.AreEqual(
                    stackItem,
                    initialDataItem,
                    $"Values at index {index} doesn't match; Expected: {initialDataItem}; Actual: {stackItem}"
                );
            }
        }
    }
}
