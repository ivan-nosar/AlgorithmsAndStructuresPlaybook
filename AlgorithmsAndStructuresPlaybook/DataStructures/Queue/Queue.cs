using System;

namespace AlgorithmsAndStructuresPlaybook.DataStructures.Queue
{
    /// <summary>
    /// Queue is an abstract data type that are maintained in a sequence and can be modified by the addition
    /// of entities at one end of the sequence and the removal of entities from the other end of the sequence.
    /// Queue defines two main operations:
    /// * Enqueue, which adds an element to the tail of queue
    /// * Dequeue, which removes the first element from the head of queue
    /// The order in which an element added to or removed from a queue is described as first in, first out,
    /// referred to by the acronym FIFO.
    /// This implementation uses a self-extensible circular buffer to store the elements in contiguous space
    /// in memory (just like <see cref="ArrayList"/>). As soon as the space in the tail of the allocated
    /// buffer runs out, the algorithm tries to find free space at the beginning of the buffer before
    /// the first element in the queue. If even in this case there is not enough space, automatic expansion
    /// is applied.
    /// </summary>
    public class Queue
    {
        const int DEFAULT_CAPACITY = 10;
        const int GROWTH_RATE = 2;

        private int _capacity;
        private int[] Storage { get; set; }
        private int HeadIndex { get; set; }

        public int Capacity
        {
            get => _capacity;
            // Protect capacity value from going non-positive
            private set => _capacity = Math.Max(1, value);
        }

        public int Count { get; private set; }

        /// <summary>
        /// Construct a new instance of <c>Queue</c>
        /// (with optional <paramref name="capacity"/> value provided)
        /// </summary>
        /// <param name="capacity">
        /// Optional: Indicates the initial amount of memory (in elements)
        /// allocated to the collection. Default value: <see cref="DEFAULT_CAPACITY">
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the <paramref name="capacity"/> is a non-positive number
        /// </exception>
        public Queue(int capacity = DEFAULT_CAPACITY)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            Capacity = capacity;
            Storage = new int[Capacity];
            HeadIndex = 0;
            Count = 0;
        }

        /// <summary>
        /// Add a new value to the end of the queue
        /// </summary>
        /// <param name="value">New value to be added</param>
        public void Enqueue(int value)
        {
            if (Count == Capacity)
            {
                ExpandStorage();
            }

            var index = GetStorageIndexByPositionInQueue(Count, Capacity);
            Storage[index] = value;
            Count++;
        }

        /// <summary>
        /// Remove the value from the beginning of the queue and return it
        /// </summary>
        /// <returns>The value removed from the beginning of the queue</returns>
        public int Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            int elementIndex = HeadIndex;

            HeadIndex++;
            Count--;

            // If queue is empty or head is out of storage bounds - we must reset head index
            if (Count == 0 || HeadIndex >= Capacity)
            {
                HeadIndex = 0;
            }

            return Storage[elementIndex];
        }

        /// <summary>
        /// Return the value from the beginning of the queue without removing it
        /// </summary>
        /// <returns>The value removed from the beginning of the queue</returns>
        public int Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return Storage[HeadIndex];
        }

        /// <summary>
        /// Reallocate the internal storage to fit the exact size of items stored
        /// in the collection and release the extra memory.
        /// </summary>
        public void ShrinkToFit()
        {
            var oldCapacity = Capacity;
            var oldStorage = Storage;
            Capacity = Count;
            Storage = new int[Capacity];

            for (int i = 0; i < Count; i++)
            {
                var oldIndex = GetStorageIndexByPositionInQueue(i, oldCapacity);
                Storage[i] = oldStorage[oldIndex];
            }

            // Short-handed form of loop above:
            //var elementsAfterHeadCount = Count - HeadIndex;
            //Array.Copy(oldStorage, HeadIndex, Storage, 0, elementsAfterHeadCount);
            //Array.Copy(oldStorage, 0, Storage, elementsAfterHeadCount, Count - elementsAfterHeadCount);

            HeadIndex = 0;
        }

        /// <summary>
        /// Reallocate the internal storage to add more capacity for further item additions.
        /// The expansion factor is constant: <see cref="GROWTH_RATE"/>
        /// </summary>

        private void ExpandStorage()
        {
            var oldCapacity = Capacity;
            var oldStorage = Storage;
            Capacity *= GROWTH_RATE;
            Storage = new int[Capacity];

            for (int i = 0; i < Count; i++)
            {
                var oldIndex = GetStorageIndexByPositionInQueue(i, oldCapacity);
                Storage[i] = oldStorage[oldIndex];
            }

            // Short-handed form of loop above:
            //var elementsAfterHeadCount = Count - HeadIndex;
            //Array.Copy(oldStorage, HeadIndex, Storage, 0, elementsAfterHeadCount);
            //Array.Copy(oldStorage, 0, Storage, elementsAfterHeadCount, Count - elementsAfterHeadCount);

            HeadIndex = 0;
        }

        /// <summary>
        /// Return the physical index of queue item in internal storage with respect
        /// to the current head index and storage capacity
        /// </summary>
        /// <param name="positionInQueue">Position of the item in the queue. Acceptable values are [0..Count)</param>
        /// <param name="capacity">Current value of storage capacity</param>
        /// <returns></returns>
        private int GetStorageIndexByPositionInQueue(int positionInQueue, int capacity)
        {
            var indexCandidate = HeadIndex + positionInQueue;
            return indexCandidate >= capacity ? indexCandidate - capacity : indexCandidate;
        }
    }
}
