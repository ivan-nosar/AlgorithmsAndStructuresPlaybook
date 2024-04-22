using AlgorithmsAndStructuresPlaybook.DataStructures.ArrayList;

namespace AlgorithmsAndStructuresPlaybook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new ArrayList(2);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);

            list.RemoveAtIndex(0); // first index
            list.RemoveAtIndex(2); // middle index
            list.RemoveAtIndex(3); // last index
            list.Add(9);

            list.InsertAtIndex(0, 1); // first index
            list.InsertAtIndex(3, 4); // middle index
            list.InsertAtIndex(5, 6); // last index
            list.InsertAtIndex(6, 7); // last index
            list.InsertAtIndex(7, 8); // last index
            list.ShrinkToFit();

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}
