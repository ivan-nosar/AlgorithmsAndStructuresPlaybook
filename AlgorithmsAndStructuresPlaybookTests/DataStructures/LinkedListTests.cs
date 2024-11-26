using AlgorithmsAndStructuresPlaybook.DataStructures.LinkedList;
using System.Collections.Generic;

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

        [TestMethod]
        public void AddFirst_NodeBelongsToList_Failure()
        {
            // Arrange
            var linkedList = new LinkedList();
            var node = new LinkedList.Node(100);
            linkedList.AddFirst(node);

            var otherLinkedList = new LinkedList();
            var otherNode = new LinkedList.Node(200);
            otherLinkedList.AddFirst(otherNode);

            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() => linkedList.AddFirst(node));
            Assert.ThrowsException<InvalidOperationException>(() => linkedList.AddFirst(otherNode));

            var expectedCount = 1;
            Assert.AreEqual(expectedCount, linkedList.Count);
            Assert.AreEqual(expectedCount, otherLinkedList.Count);
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

                Assert.AreEqual(linkedList, currentNode.List);

                currentNode = currentNode.Next;
            }

            // Ensure tail of list contains old items
            foreach (var expectedItem in initialData)
            {
                Assert.IsNotNull(currentNode);

                var actulaItem = currentNode.Value;
                Assert.AreEqual(expectedItem, actulaItem);

                Assert.AreEqual(linkedList, currentNode.List);

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

        [TestMethod]
        public void AddLast_NodeBelongsToList_Failure()
        {
            // Arrange
            var linkedList = new LinkedList();
            var node = new LinkedList.Node(100);
            linkedList.AddFirst(node);

            var otherLinkedList = new LinkedList();
            var otherNode = new LinkedList.Node(200);
            otherLinkedList.AddFirst(otherNode);

            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() => linkedList.AddLast(node));
            Assert.ThrowsException<InvalidOperationException>(() => linkedList.AddLast(otherNode));

            var expectedCount = 1;
            Assert.AreEqual(expectedCount, linkedList.Count);
            Assert.AreEqual(expectedCount, otherLinkedList.Count);
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

                Assert.AreEqual(linkedList, currentNode.List);

                currentNode = currentNode.Next;
            }

            // Ensure tail of list contains newly inserted items
            foreach (var expectedItem in indicesToAdd)
            {
                Assert.IsNotNull(currentNode);

                var actulaItem = currentNode.Value;
                Assert.AreEqual(expectedItem, actulaItem);

                Assert.AreEqual(linkedList, currentNode.List);

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
            var listNode = linkedList.First;

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => linkedList.AddBefore(invalidNode!, listNode!));
            Assert.ThrowsException<ArgumentNullException>(() => linkedList.AddBefore(listNode!, invalidNode!));
            Assert.ThrowsException<ArgumentNullException>(() => linkedList.AddBefore(invalidNode!, invalidNode!));

            var expectedCount = initialData.Length;
            Assert.AreEqual(expectedCount, linkedList.Count);
        }

        [TestMethod]
        public void AddBefore_NodeBelongsToList_Failure()
        {
            // Arrange
            var linkedList = new LinkedList();
            var node1 = new LinkedList.Node(100);
            var node2 = new LinkedList.Node(150);
            linkedList.AddFirst(node1);
            linkedList.AddFirst(node2);

            var otherLinkedList = new LinkedList();
            var otherNode1 = new LinkedList.Node(200);
            var otherNode2 = new LinkedList.Node(250);
            otherLinkedList.AddFirst(otherNode1);
            otherLinkedList.AddFirst(otherNode2);

            var newNode1 = new LinkedList.Node(300);
            var newNode2 = new LinkedList.Node(350);

            // Act & Assert
            // Ensure validation of pivot node: it should belong to the list
            Assert.ThrowsException<InvalidOperationException>(() => linkedList.AddBefore(otherNode1, node1));
            Assert.ThrowsException<InvalidOperationException>(() => linkedList.AddBefore(otherNode1, otherNode2));
            Assert.ThrowsException<InvalidOperationException>(() => linkedList.AddBefore(otherNode1, newNode1));

            Assert.ThrowsException<InvalidOperationException>(() => linkedList.AddBefore(newNode1, node1));
            Assert.ThrowsException<InvalidOperationException>(() => linkedList.AddBefore(newNode1, otherNode1));
            Assert.ThrowsException<InvalidOperationException>(() => linkedList.AddBefore(newNode1, newNode2));

            // Ensure validation of new node: it shouldn't belong to any list
            Assert.ThrowsException<InvalidOperationException>(() => linkedList.AddBefore(node1, node2));
            Assert.ThrowsException<InvalidOperationException>(() => linkedList.AddBefore(node1, otherNode1));

            // Ensure nodes are not referring the same object
            Assert.ThrowsException<InvalidOperationException>(() => linkedList.AddBefore(node1, node1));

            var expectedCount = 2;
            Assert.AreEqual(expectedCount, linkedList.Count);
            Assert.AreEqual(expectedCount, otherLinkedList.Count);
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

                Assert.AreEqual(linkedList, currentNode.List);

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

        [TestMethod]
        public void AddAfter_NodeBelongsToList_Failure()
        {
            // Arrange
            var linkedList = new LinkedList();
            var node1 = new LinkedList.Node(100);
            var node2 = new LinkedList.Node(150);
            linkedList.AddFirst(node1);
            linkedList.AddFirst(node2);

            var otherLinkedList = new LinkedList();
            var otherNode1 = new LinkedList.Node(200);
            var otherNode2 = new LinkedList.Node(250);
            otherLinkedList.AddFirst(otherNode1);
            otherLinkedList.AddFirst(otherNode2);

            var newNode1 = new LinkedList.Node(300);
            var newNode2 = new LinkedList.Node(350);

            // Act & Assert
            // Ensure validation of pivot node: it should belong to the list
            Assert.ThrowsException<InvalidOperationException>(() => linkedList.AddAfter(otherNode1, node1));
            Assert.ThrowsException<InvalidOperationException>(() => linkedList.AddAfter(otherNode1, otherNode2));
            Assert.ThrowsException<InvalidOperationException>(() => linkedList.AddAfter(otherNode1, newNode1));

            Assert.ThrowsException<InvalidOperationException>(() => linkedList.AddAfter(newNode1, node1));
            Assert.ThrowsException<InvalidOperationException>(() => linkedList.AddAfter(newNode1, otherNode1));
            Assert.ThrowsException<InvalidOperationException>(() => linkedList.AddAfter(newNode1, newNode2));

            // Ensure validation of new node: it shouldn't belong to any list
            Assert.ThrowsException<InvalidOperationException>(() => linkedList.AddAfter(node1, node2));
            Assert.ThrowsException<InvalidOperationException>(() => linkedList.AddAfter(node1, otherNode1));

            // Ensure nodes are not referring the same object
            Assert.ThrowsException<InvalidOperationException>(() => linkedList.AddAfter(node1, node1));

            var expectedCount = 2;
            Assert.AreEqual(expectedCount, linkedList.Count);
            Assert.AreEqual(expectedCount, otherLinkedList.Count);
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

                Assert.AreEqual(linkedList, currentNode.List);

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
                Assert.IsNull(item.List);
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

        [TestMethod]
        public void Remove_NodeDoesntBelongToList_Failure()
        {
            // Arrange
            var linkedList = new LinkedList();
            var node1 = new LinkedList.Node(100);
            var node2 = new LinkedList.Node(150);
            linkedList.AddFirst(node1);
            linkedList.AddFirst(node2);

            var otherLinkedList = new LinkedList();
            var otherNode = new LinkedList.Node(200);
            otherLinkedList.AddFirst(otherNode);

            var newNode = new LinkedList.Node(300);

            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() => linkedList.Remove(newNode));
            Assert.ThrowsException<InvalidOperationException>(() => linkedList.Remove(otherNode));

            var expectedCount = 2;
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
            var firstDeletedNode = linkedList.First!;
            linkedList.Remove(firstDeletedNode);
            linkedList.Remove(nodeInMiddle!);
            var lastDeletedNode = linkedList.Last!;
            linkedList.Remove(lastDeletedNode);

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

            // Ensure references in nodes were removed
            Assert.IsNull(firstDeletedNode.Previous);
            Assert.IsNull(firstDeletedNode.Next);
            Assert.IsNull(firstDeletedNode.List);

            Assert.IsNull(nodeInMiddle!.Previous);
            Assert.IsNull(nodeInMiddle!.Next);
            Assert.IsNull(nodeInMiddle!.List);

            Assert.IsNull(lastDeletedNode.Previous);
            Assert.IsNull(lastDeletedNode.Next);
            Assert.IsNull(lastDeletedNode.List);

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
            var firstDeletedNode = linkedList.First!;
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

            // Ensure references in nodes were removed
            Assert.IsNull(firstDeletedNode.Previous);
            Assert.IsNull(firstDeletedNode.Next);
            Assert.IsNull(firstDeletedNode.List);

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
            var lastDeletedNode = linkedList.Last!;
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

            // Ensure references in nodes were removed
            Assert.IsNull(lastDeletedNode.Previous);
            Assert.IsNull(lastDeletedNode.Next);
            Assert.IsNull(lastDeletedNode.List);

            // Ensure the length of linked list
            var expectedCount = expectedItems.Count;
            Assert.AreEqual(expectedCount, linkedList.Count);
        }
    }
}
