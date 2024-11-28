namespace AlgorithmsAndStructuresPlaybook.DataStructures.Stack
{
    /// <summary>
    /// Stack is an abstract data type that serves as a collection of elements with two main operations:
    /// * Push, which adds an element to the collection, and
    /// * Pop, which removes the most recently added element.
    /// The order in which an element added to or removed from a stack is described as last in, first out,
    /// referred to by the acronym LIFO.
    /// This implementation uses a self-extensible array to store the elements in contiguous space in memory
    /// (just like <see cref="ArrayList"/>)
    /// </summary>
    public class Stack
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
        /// Construct a new instance of <c>Stack</c>
        /// (with optional <paramref name="capacity"/> value provided)
        /// </summary>
        /// <param name="capacity">
        /// Optional: Indicates the initial amount of memory (in elements)
        /// allocated to the collection. Default value: <see cref="DEFAULT_CAPACITY">
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the <paramref name="capacity"/> is a non-positive number
        /// </exception>
        public Stack(int capacity = DEFAULT_CAPACITY)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            Capacity = capacity;
            Storage = new int[Capacity];
            Count = 0;
        }

        /// <summary>
        /// Add a new value to the top of the stack
        /// </summary>
        /// <param name="value">New value to be added</param>
        public void Push(int value)
        {
            if (Count == Capacity)
            {
                ExpandStorage();
            }

            Storage[Count] = value;
            Count++;
        }

        /// <summary>
        /// Pop the value from the top of stack and return it
        /// </summary>
        /// <returns>The value removed from the top of stack</returns>
        public int Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            Count--;

            return Storage[Count];
        }

        /// <summary>
        /// Return the value from the top of the stack without removing it
        /// </summary>
        /// <returns>The value from the top of stack</returns>
        public int Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            return Storage[Count - 1];
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
