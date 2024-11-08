namespace AlgorithmsAndStructuresPlaybook.DataStructures.ArrayList
{
    /// <summary>
    /// ArrayList implements a simple linear ordered collection built on top of the array.
    /// Elements in that collection are stored in a contiguous space in memory.
    /// ArrayList handles automatic extensions of occupied memory space in case
    /// the collection doesn't have enough space (free cells in the array) for a new element
    /// to be added.
    /// </summary>
    public class ArrayList
    {
        const int DEFAULT_CAPACITY = 10;
        const int GROWTH_RATE = 2;

        private int _capacity;
        private int[] Storage { get; set; }

        public int Capacity
        {
            get => _capacity;
            // Protect capacity value from going non-positive
            private set => _capacity = Math.Max(1, value);
        }
        public int Count { get; private set; }

        /// <summary>
        /// Construct a new instance of <c>ArrayList</c>
        /// (with optional <paramref name="capacity"/> value provided)
        /// </summary>
        /// <param name="capacity">
        /// Optional: Indicates the initial amount of memory (in elements)
        /// allocated to the collection. Default value: <see cref="DEFAULT_CAPACITY">
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the <paramref name="capacity"/> is a non-positive number
        /// </exception>
        public ArrayList(int capacity = DEFAULT_CAPACITY)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            Capacity = capacity;
            Storage = new int[Capacity];
            Count = 0;
        }

        /// <value>
        /// Get or set element with an index provided
        /// </value>
        /// <exception cref="IndexOutOfRangeException">
        /// Thrown when the <paramref name="index"/> is a non-positive number or
        /// exceeds the number of values stored in a collection
        /// </exception>
        public int this[int index]
        {
            get
            {
                ValidateIndexInBounds(index);

                return Storage[index];
            }

            set
            {
                ValidateIndexInBounds(index);

                Storage[index] = value;
            }
        }

        /// <summary>
        /// Add a new value to the tail of the list
        /// </summary>
        /// <param name="value">New value to be added</param>
        public void Add(int value)
        {
            if (Count == Capacity)
            {
                ExpandStorage();
            }

            Storage[Count] = value;
            Count++;
        }

        /// <summary>
        /// Remove the existing value from the specified index and compress the values left around the freed cell
        /// </summary>
        /// <param name="index">Index of the element to be removed</param>
        /// <exception cref="IndexOutOfRangeException">
        /// Thrown when the <paramref name="index"/> is a non-positive number or
        /// exceeds the number of values stored in a collection
        /// </exception>
        public void RemoveFromIndex(int index)
        {
            ValidateIndexInBounds(index);

            Count--;

            // Shift the values ​​on the right one position to the left
            for (int i = index; i < Count; i++)
            {
                Storage[i] = Storage[i + 1];
            }

            // Short-handed form of loop above:
            // Array.Copy(Storage, index + 1, Storage, index, Count - index);
        }

        /// <summary>
        /// Insert a new value at the specified index. This action will not override existing items.
        /// Instead, it will move the surrounding elements to free the position for the new item.
        /// <example>For example:
        /// <code>
        /// ArrayList al = new ArrayList();
        /// al.Add(1);
        /// al.Add(3);
        /// al.Add(4);
        /// al.InsertAtIndex(1, 2);
        /// al[1]; // 2
        /// al[2]; // 3
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="index">Index of the element to be added</param>
        /// <param name="value">New value to be added </param>
        /// <exception cref="IndexOutOfRangeException">
        /// Thrown when the <paramref name="index"/> is a non-positive number or
        /// exceeds the number of values stored in a collection
        /// </exception>
        public void InsertAtIndex(int index, int value)
        {
            if (index != Count)
            {
                // Handle edge-case: It is possible to insert in the tail of list if there is no gap
                ValidateIndexInBounds(index);
            }

            if (Count == Capacity)
            {
                ExpandStorage();
            }

            Count++;

            // Shift the values ​​on the right one position to the right to free the position at `index`
            for (int i = Count - 1; i > index; i--)
            {
                Storage[i] = Storage[i - 1];
            }

            // Short-handed form of loop above:
            // Array.Copy(Storage, index, Storage, index + 1, Count - index - 1);

            Storage[index] = value;
        }

        /// <summary>
        /// Reallocate the internal storage to fit the exact size of items stored
        /// in the collection and release the extra memory.
        /// </summary>
        public void ShrinkToFit()
        {
            var oldStorage = Storage;
            Capacity = Count;
            Storage = new int[Capacity];

            for (int i = 0; i < Capacity; i++)
            {
                Storage[i] = oldStorage[i];
            }

            // Short-handed form of loop above:
            // Array.Copy(oldStorage, Storage, Capacity);
        }

        /// <summary>
        /// Validate if the index provided is out of bounds for a particular <c>ArrayList</c> instance
        /// </summary>
        /// <param name="index">The index of item</param>
        /// <exception cref="IndexOutOfRangeException">
        /// Thrown when the <paramref name="index"/> is a non-positive number or
        /// exceeds the number of values stored in a collection
        /// </exception>
        private void ValidateIndexInBounds(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// Reallocate the internal storage to add more capacity for further item additions.
        /// The expansion factor is constant: <see cref="GROWTH_RATE"/>
        /// </summary>
        private void ExpandStorage()
        {
            var oldStorage = Storage;
            Capacity *= GROWTH_RATE;
            Storage = new int[Capacity];

            for (int i = 0; i < oldStorage.Length; i++)
            {
                Storage[i] = oldStorage[i];
            }

            // Short-handed form of loop above:
            // Array.Copy(oldStorage, Storage, oldStorage.Length);
        }
    }
}
