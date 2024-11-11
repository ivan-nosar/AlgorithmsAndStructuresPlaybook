namespace AlgorithmsAndStructuresPlaybook.DataStructures.LinkedList
{
    /// <summary>
    /// LinkedList implements a linear ordered collection of items.
    /// Elements in that collection are distributed across different segments of physical memory.
    /// Each item holds the references (pointers) on two neighborhood items - previous and next -
    /// for this reason it can also be referred as double-linked list.
    /// Each item is represented by <see cref = "LinkedList.Node" /> object that contains direct data.
    /// The program must first allocate memory for an item before adding it to the collection.
    /// </summary>
    public class LinkedList
    {
        public int Count { get; private set; }
        public Node? First { get; private set; }
        public Node? Last { get; private set; }

        public LinkedList()
        {
            First = null;
            Last = null;
        }

        public void AddFirst(Node newNode)
        {
            if (newNode == null)
            {
                throw new ArgumentNullException("New node is null");
            }

            var second = First;

            First = newNode;
            First.Previous = null;
            First.Next = second;

            if (second != null)
            {
                second.Previous = First;
            }
            if (Last == null)
            {
                Last = First;
            }

            Count++;
        }

        public void AddLast(Node newNode)
        {
            if (newNode == null)
            {
                throw new ArgumentNullException("New node is null");
            }

            var penultimate = Last;

            Last = newNode;
            Last.Previous = penultimate;
            Last.Next = null;

            if (penultimate != null)
            {
                penultimate.Next = Last;
            }
            if (First == null)
            {
                First = Last;
            }

            Count++;
        }

        public void AddBefore(Node node, Node newNode)
        {
            if (node == null)
            {
                throw new ArgumentNullException("Node is null");
            }
            if (newNode == null)
            {
                throw new ArgumentNullException("New node is null");
            }

            var previous = node.Previous;

            if (previous != null)
            {
                previous.Next = newNode;
                newNode.Previous = previous;
            }

            newNode.Next = node;
            node.Previous = newNode;

            Count++;
        }

        public void AddAfter(Node node, Node newNode)
        {
            if (node == null)
            {
                throw new ArgumentNullException("Node is null");
            }
            if (newNode == null)
            {
                throw new ArgumentNullException("New node is null");
            }

            var next = node.Next;

            node.Next = newNode;
            newNode.Previous = node;

            if (next != null)
            {
                next.Previous = newNode;
                newNode.Next = next;
            }

            Count++;
        }

        public void Clear()
        {
            var current = First;
            while (current != null)
            {
                var next = current.Next;

                current.Next = null;
                current.Previous = null;

                current = next;
            }

            Count = 0;
            First = null;
            Last = null;
        }

        public void Remove(Node node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("Node is null");
            }

            var next = node.Next;
            var previous = node.Previous;

            if (next != null)
            {
                next.Previous = previous;
            }

            if (previous != null)
            {
                previous.Next = next;
            }

            if (node == First)
            {
                First = next;
            }

            if (node == Last)
            {
                Last = previous;
            }

            node.Next = null;
            node.Previous = null;

            Count--;
        }

        public void RemoveFirst()
        {
            if (First == null)
            {
                throw new ArgumentNullException("First node is null");
            }

            Remove(First);
        }

        public void RemoveLast()
        {
            if (Last == null)
            {
                throw new ArgumentNullException("Last node is null");
            }

            Remove(Last);
        }

        public class Node
        {
            public int Value { get; private set; }
            public Node? Previous { get; internal set; }
            public Node? Next { get; internal set; }

            public Node(int value, Node? previous = null, Node? next = null)
            {
                Value = value;
                Previous = previous;
                Next = next;
            }
        }
    }
}
