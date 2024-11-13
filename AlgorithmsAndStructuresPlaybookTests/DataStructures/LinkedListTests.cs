using AlgorithmsAndStructuresPlaybook.DataStructures.LinkedList;

namespace AlgorithmsAndStructuresPlaybook.Tests.DataStructures
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void Constructor_WithoutParams_Success()
        {
            // Act
            var arrayList = new LinkedList();

            // Assert
            Assert.AreEqual(0, arrayList.Count);
        }

        [DataTestMethod]
        [DataRow(new int[0])]
        [DataRow(new int[] { 1, 2, 3 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void AddFirst_Failure(int[] initialData)
        {
            // Arrange
            var linkedList = new LinkedList();
            foreach (var item in initialData)
            {
                var newNode = new LinkedList.Node(item);
                linkedList.AddLast(newNode);
            }

            LinkedList.Node? invalidNode = null;

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => linkedList.AddFirst(invalidNode!));

            var expectedCount = initialData.Length;
            Assert.AreEqual(expectedCount, linkedList.Count);
        }

        [DataTestMethod]
        [DataRow(new int[0], new int[] { -10, -1, 0, 1, 10 })]
        [DataRow(new int[] { 1, 2, 3 }, new int[] { -10, -1, 3, 4, 10 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { -100, -2, -1, 10, 11, 100 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, new int[] { -20, -2, -1, 15, 16, 50 })]
        public void AddFirst_Success(int[] initialData, int[] indicesToAdd)
        {
            // Arrange
            var linkedList = new LinkedList();
            foreach (var item in initialData)
            {
                var newNode = new LinkedList.Node(item);
                linkedList.AddLast(newNode);
            }

            // Act
            foreach (var item in indicesToAdd)
            {
                var newNode = new LinkedList.Node(item);
                linkedList.AddFirst(newNode);
            }

            // Assert
            var currentNode = linkedList.First;

            // Ensure head of list consists of newly inserted items
            for (var i = indicesToAdd.Length - 1; i >= 0; i--)
            {
                Assert.IsNotNull(currentNode);

                var expectedItem = indicesToAdd[i];
                var actulaItem = currentNode.Value;
                Assert.AreEqual(expectedItem, actulaItem);

                currentNode = currentNode.Next;
            }

            // Ensure tail of list contains old items
            foreach (var expectedItem in initialData)
            {
                Assert.IsNotNull(currentNode);

                var actulaItem = currentNode.Value;
                Assert.AreEqual(expectedItem, actulaItem);

                currentNode = currentNode.Next;
            }

            Assert.IsNull(currentNode);

            // Ensure the length of linked list
            var expectedCount = initialData.Length + indicesToAdd.Length;
            Assert.AreEqual(expectedCount, linkedList.Count);
        }

        [DataTestMethod]
        [DataRow(new int[0])]
        [DataRow(new int[] { 1, 2, 3 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void AddLast_Failure(int[] initialData)
        {
            // Arrange
            var linkedList = new LinkedList();
            foreach (var item in initialData)
            {
                var newNode = new LinkedList.Node(item);
                linkedList.AddFirst(newNode);
            }

            LinkedList.Node? invalidNode = null;

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => linkedList.AddLast(invalidNode!));

            var expectedCount = initialData.Length;
            Assert.AreEqual(expectedCount, linkedList.Count);
        }

        [DataTestMethod]
        [DataRow(new int[0], new int[] { -10, -1, 0, 1, 10 })]
        [DataRow(new int[] { 1, 2, 3 }, new int[] { -10, -1, 3, 4, 10 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { -100, -2, -1, 10, 11, 100 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, new int[] { -20, -2, -1, 15, 16, 50 })]
        public void AddLast_Success(int[] initialData, int[] indicesToAdd)
        {
            // Arrange
            var linkedList = new LinkedList();
            foreach (var item in initialData)
            {
                var newNode = new LinkedList.Node(item);
                linkedList.AddFirst(newNode);
            }

            // Act
            foreach (var item in indicesToAdd)
            {
                var newNode = new LinkedList.Node(item);
                linkedList.AddLast(newNode);
            }

            // Assert
            var currentNode = linkedList.First;

            // Ensure head of list consists of old items
            for (var i = initialData.Length - 1; i >= 0; i--)
            {
                Assert.IsNotNull(currentNode);

                var expectedItem = initialData[i];
                var actulaItem = currentNode.Value;
                Assert.AreEqual(expectedItem, actulaItem);

                currentNode = currentNode.Next;
            }

            // Ensure tail of list contains newly inserted items
            foreach (var expectedItem in indicesToAdd)
            {
                Assert.IsNotNull(currentNode);

                var actulaItem = currentNode.Value;
                Assert.AreEqual(expectedItem, actulaItem);

                currentNode = currentNode.Next;
            }

            Assert.IsNull(currentNode);

            // Ensure the length of linked list
            var expectedCount = initialData.Length + indicesToAdd.Length;
            Assert.AreEqual(expectedCount, linkedList.Count);
        }

        [DataTestMethod]
        [DataRow(new int[0])]
        [DataRow(new int[] { 1, 2, 3 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void AddBefore_Failure(int[] initialData)
        {
            // Arrange
            var linkedList = new LinkedList();
            foreach (var item in initialData)
            {
                var newNode = new LinkedList.Node(item);
                linkedList.AddLast(newNode);
            }

            LinkedList.Node? invalidNode = null;
            var listNode =linkedList.First;

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => linkedList.AddBefore(invalidNode!, listNode!));
            Assert.ThrowsException<ArgumentNullException>(() => linkedList.AddBefore(listNode!, invalidNode!));
            Assert.ThrowsException<ArgumentNullException>(() => linkedList.AddBefore(invalidNode!, invalidNode!));

            var expectedCount = initialData.Length;
            Assert.AreEqual(expectedCount, linkedList.Count);
        }

        [DataTestMethod]
        [DataRow(new int[] { 1 })]
        [DataRow(new int[] { 1, 2, 3 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void AddBefore_Success(int[] initialData)
        {
            // Arrange
            var linkedList = new LinkedList();
            foreach (var item in initialData)
            {
                var newNode = new LinkedList.Node(item);
                linkedList.AddLast(newNode);
            }

            var nodeBeforeFirst = new LinkedList.Node(111);
            var nodeBeforeMiddle = new LinkedList.Node(222);
            var nodeBeforeLast = new LinkedList.Node(333);

            var nodeInMiddleIndex = linkedList.Count / 2;
            var nodeInMiddle = linkedList.First;
            while (nodeInMiddleIndex > 0)
            {
                nodeInMiddle = nodeInMiddle!.Next;
                nodeInMiddleIndex--;
            }

            // Act
            linkedList.AddBefore(linkedList.First!, nodeBeforeFirst);
            linkedList.AddBefore(nodeInMiddle!, nodeBeforeMiddle);
            linkedList.AddBefore(linkedList.Last!, nodeBeforeLast);

            // Assert
            var currentNode = linkedList.First;

            var expectedItems = new LinkedList<int>(initialData);
            var expectedItemInMiddleIndex = expectedItems.Count / 2;
            var expectedItemInMiddle = expectedItems.First;
            while (expectedItemInMiddleIndex > 0)
            {
                expectedItemInMiddle = expectedItemInMiddle!.Next;
                expectedItemInMiddleIndex--;
            }
            expectedItems.AddBefore(expectedItems.First!, nodeBeforeFirst.Value);
            expectedItems.AddBefore(expectedItemInMiddle!, nodeBeforeMiddle.Value);
            expectedItems.AddBefore(expectedItems.Last!, nodeBeforeLast.Value);

            // Ensure order and presence of all the items
            foreach (var expectedItem in expectedItems)
            {
                Assert.IsNotNull(currentNode);

                var actulaItem = currentNode.Value;
                Assert.AreEqual(expectedItem, actulaItem);

                currentNode = currentNode.Next;
            }

            Assert.IsNull(currentNode);

            // Ensure the length of linked list
            var expectedCount = expectedItems.Count;
            Assert.AreEqual(expectedCount, linkedList.Count);
        }

        [DataTestMethod]
        [DataRow(new int[0])]
        [DataRow(new int[] { 1, 2, 3 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void AddAfter_Failure(int[] initialData)
        {
            // Arrange
            var linkedList = new LinkedList();
            foreach (var item in initialData)
            {
                var newNode = new LinkedList.Node(item);
                linkedList.AddLast(newNode);
            }

            LinkedList.Node? invalidNode = null;
            var listNode = linkedList.First;

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => linkedList.AddAfter(invalidNode!, listNode!));
            Assert.ThrowsException<ArgumentNullException>(() => linkedList.AddAfter(listNode!, invalidNode!));
            Assert.ThrowsException<ArgumentNullException>(() => linkedList.AddAfter(invalidNode!, invalidNode!));

            var expectedCount = initialData.Length;
            Assert.AreEqual(expectedCount, linkedList.Count);
        }

        [DataTestMethod]
        [DataRow(new int[] { 1 })]
        [DataRow(new int[] { 1, 2, 3 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void AddAfter_Success(int[] initialData)
        {
            // Arrange
            var linkedList = new LinkedList();
            foreach (var item in initialData)
            {
                var newNode = new LinkedList.Node(item);
                linkedList.AddLast(newNode);
            }

            var nodeAfterFirst = new LinkedList.Node(111);
            var nodeAfterMiddle = new LinkedList.Node(222);
            var nodeAfterLast = new LinkedList.Node(333);

            var nodeInMiddleIndex = linkedList.Count / 2;
            var nodeInMiddle = linkedList.First;
            while (nodeInMiddleIndex > 0)
            {
                nodeInMiddle = nodeInMiddle!.Next;
                nodeInMiddleIndex--;
            }

            // Act
            linkedList.AddAfter(linkedList.First!, nodeAfterFirst);
            linkedList.AddAfter(nodeInMiddle!, nodeAfterMiddle);
            linkedList.AddAfter(linkedList.Last!, nodeAfterLast);

            // Assert
            var currentNode = linkedList.First;

            var expectedItems = new LinkedList<int>(initialData);
            var expectedItemInMiddleIndex = expectedItems.Count / 2;
            var expectedItemInMiddle = expectedItems.First;
            while (expectedItemInMiddleIndex > 0)
            {
                expectedItemInMiddle = expectedItemInMiddle!.Next;
                expectedItemInMiddleIndex--;
            }
            expectedItems.AddAfter(expectedItems.First!, nodeAfterFirst.Value);
            expectedItems.AddAfter(expectedItemInMiddle!, nodeAfterMiddle.Value);
            expectedItems.AddAfter(expectedItems.Last!, nodeAfterLast.Value);

            // Ensure order and presence of all the items
            foreach (var expectedItem in expectedItems)
            {
                Assert.IsNotNull(currentNode);

                var actulaItem = currentNode.Value;
                Assert.AreEqual(expectedItem, actulaItem);

                currentNode = currentNode.Next;
            }

            Assert.IsNull(currentNode);

            // Ensure the length of linked list
            var expectedCount = expectedItems.Count;
            Assert.AreEqual(expectedCount, linkedList.Count);
        }

        [DataTestMethod]
        [DataRow(new int[0])]
        [DataRow(new int[] { 1 })]
        [DataRow(new int[] { 1, 2, 3 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void Clear_Success(int[] initialData)
        {
            // Arrange
            var linkedList = new LinkedList();
            var itemsReferences = new List<LinkedList.Node>();
            foreach (var item in initialData)
            {
                var newNode = new LinkedList.Node(item);
                linkedList.AddLast(newNode);
                itemsReferences.Add(newNode);
            }

            // Act
            linkedList.Clear();

            // Assert
            var expectedCount = 0;
            Assert.AreEqual(expectedCount, linkedList.Count);

            Assert.IsNull(linkedList.First);
            Assert.IsNull(linkedList.Last);

            foreach (var item in itemsReferences)
            {
                Assert.IsNull(item.Next);
                Assert.IsNull(item.Previous);
            }
        }

        [DataTestMethod]
        [DataRow(new int[0])]
        [DataRow(new int[] { 1, 2, 3 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void Remove_Failure(int[] initialData)
        {
            // Arrange
            var linkedList = new LinkedList();
            foreach (var item in initialData)
            {
                var newNode = new LinkedList.Node(item);
                linkedList.AddLast(newNode);
            }

            LinkedList.Node? invalidNode = null;

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => linkedList.Remove(invalidNode!));

            var expectedCount = initialData.Length;
            Assert.AreEqual(expectedCount, linkedList.Count);
        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 3 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void Remove_Success(int[] initialData)
        {
            // Arrange
            var linkedList = new LinkedList();
            foreach (var item in initialData)
            {
                var newNode = new LinkedList.Node(item);
                linkedList.AddLast(newNode);
            }

            var nodeInMiddleIndex = linkedList.Count / 2;
            var nodeInMiddle = linkedList.First;
            while (nodeInMiddleIndex > 0)
            {
                nodeInMiddle = nodeInMiddle!.Next;
                nodeInMiddleIndex--;
            }

            // Act
            linkedList.Remove(linkedList.First!);
            linkedList.Remove(nodeInMiddle!);
            linkedList.Remove(linkedList.Last!);

            // Assert
            var currentNode = linkedList.First;

            var expectedItems = new LinkedList<int>(initialData);
            var expectedItemInMiddleIndex = expectedItems.Count / 2;
            var expectedItemInMiddle = expectedItems.First;
            while (expectedItemInMiddleIndex > 0)
            {
                expectedItemInMiddle = expectedItemInMiddle!.Next;
                expectedItemInMiddleIndex--;
            }
            expectedItems.Remove(expectedItems.First!);
            expectedItems.Remove(expectedItemInMiddle!);
            expectedItems.Remove(expectedItems.Last!);

            // Ensure order and presence of all the items
            foreach (var expectedItem in expectedItems)
            {
                Assert.IsNotNull(currentNode);

                var actulaItem = currentNode.Value;
                Assert.AreEqual(expectedItem, actulaItem);

                currentNode = currentNode.Next;
            }

            Assert.IsNull(currentNode);

            // Ensure the length of linked list
            var expectedCount = expectedItems.Count;
            Assert.AreEqual(expectedCount, linkedList.Count);
        }

        [TestMethod]
        public void RemoveFirst_Failure()
        {
            // Arrange
            var linkedList = new LinkedList();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => linkedList.RemoveFirst());

            var expectedCount = 0;
            Assert.AreEqual(expectedCount, linkedList.Count);
            Assert.IsNull(linkedList.First);
            Assert.IsNull(linkedList.Last);
        }

        [DataTestMethod]
        [DataRow(new int[] { 1 })]
        [DataRow(new int[] { 1, 2, 3 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void RemoveFirst_Success(int[] initialData)
        {
            // Arrange
            var linkedList = new LinkedList();
            foreach (var item in initialData)
            {
                var newNode = new LinkedList.Node(item);
                linkedList.AddLast(newNode);
            }

            // Act
            linkedList.RemoveFirst();

            // Assert
            var currentNode = linkedList.First;

            var expectedItems = new LinkedList<int>(initialData);
            
            expectedItems.RemoveFirst();

            // Ensure order and presence of all the items
            foreach (var expectedItem in expectedItems)
            {
                Assert.IsNotNull(currentNode);

                var actulaItem = currentNode.Value;
                Assert.AreEqual(expectedItem, actulaItem);

                currentNode = currentNode.Next;
            }

            Assert.IsNull(currentNode);

            // Ensure the length of linked list
            var expectedCount = expectedItems.Count;
            Assert.AreEqual(expectedCount, linkedList.Count);
        }

        [TestMethod]
        public void RemoveLast_Failure()
        {
            // Arrange
            var linkedList = new LinkedList();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => linkedList.RemoveLast());

            var expectedCount = 0;
            Assert.AreEqual(expectedCount, linkedList.Count);
            Assert.IsNull(linkedList.First);
            Assert.IsNull(linkedList.Last);
        }

        [DataTestMethod]
        [DataRow(new int[] { 1 })]
        [DataRow(new int[] { 1, 2, 3 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void RemoveLast_Success(int[] initialData)
        {
            // Arrange
            var linkedList = new LinkedList();
            foreach (var item in initialData)
            {
                var newNode = new LinkedList.Node(item);
                linkedList.AddLast(newNode);
            }

            // Act
            linkedList.RemoveLast();

            // Assert
            var currentNode = linkedList.First;

            var expectedItems = new LinkedList<int>(initialData);

            expectedItems.RemoveLast();

            // Ensure order and presence of all the items
            foreach (var expectedItem in expectedItems)
            {
                Assert.IsNotNull(currentNode);

                var actulaItem = currentNode.Value;
                Assert.AreEqual(expectedItem, actulaItem);

                currentNode = currentNode.Next;
            }

            Assert.IsNull(currentNode);

            // Ensure the length of linked list
            var expectedCount = expectedItems.Count;
            Assert.AreEqual(expectedCount, linkedList.Count);
        }
    }
}
