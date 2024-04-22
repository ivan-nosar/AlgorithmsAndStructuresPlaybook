namespace AlgorithmsAndStructuresPlaybook.DataStructures.ArrayList
{
    public class ArrayList
    {
        const int DEFAULT_CAPACITY = 10;
        const int GROWTH_RATE = 2;

        private int[] Storage { get; set; }
        private int Capacity { get; set; }
        public int Count { get; private set; }

        public ArrayList(int capacity = DEFAULT_CAPACITY)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            Capacity = capacity;
            Storage = new int[Capacity];
            Count = 0;
        }

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

        public void Add(int value)
        {
            if (Count == Capacity)
            {
                GrowStorage();
            }

            Storage[Count] = value;
            Count++;
        }

        public void RemoveAtIndex(int index)
        {
            ValidateIndexInBounds(index);

            Count--;
            for (int i = index; i < Count; i++)
            {
                Storage[i] = Storage[i + 1];
            }

            // Short-handed form of loop above:
            // Array.Copy(Storage, index + 1, Storage, index, Count - index);
        }

        public void InsertAtIndex(int index, int value)
        {
            ValidateIndexInBounds(index);

            if (Count == Capacity)
            {
                GrowStorage();
            }

            Count++;
            for (int i = Count - 1; i > index; i--)
            {
                Storage[i] = Storage[i - 1];
            }

            Storage[index] = value;
        }

        public void ShrinkToFit()
        {
            var oldStorage = Storage;
            Capacity = Count;
            Storage = new int[Capacity];

            Array.Copy(oldStorage, Storage, Capacity);
        }

        private void ValidateIndexInBounds(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void GrowStorage()
        {
            var oldStorage = Storage;
            Capacity *= GROWTH_RATE;
            Storage = new int[Capacity];

            Array.Copy(oldStorage, Storage, oldStorage.Length);
        }
    }
}
