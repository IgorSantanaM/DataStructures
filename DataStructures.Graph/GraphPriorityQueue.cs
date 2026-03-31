namespace DataStructures.Graph
{
    public class GraphPriorityQueue // MINHEAP
    {
        private int[] _items = new int[15];
        public int[] Items => _items;
        public int Size { get; private set; } = 0;

        public void Insert(int value)
        {
            if (Size == _items.Length)
                Array.Resize(ref _items, _items.Length * 2);
            _items[Size++] = value;
            BubbleUp();
        }

        public int Remove()
        {
            int removed = _items[0];
            _items[0] = _items[--Size];

            BubbleDown();

            return removed;
        }

        private void BubbleDown()
        {
            int index = 0;

            while (index < _items.Length && _items[index] > _items[LeftChildIndex(index)] && _items[index] > _items[RightChildIndex(index)])
            {
                int smallestNodeIndex = _items[LeftChildIndex(index)] < _items[RightChildIndex(index)]
                    ? LeftChildIndex(index)
                    : RightChildIndex(index);
                Swap(index, smallestNodeIndex);
                index = smallestNodeIndex;
            }
        }

        private int LeftChildIndex(int index)
            => (index * 2) + 1;

        private int RightChildIndex(int index)
            => (index * 2) + 2;

        private void BubbleUp()
        {
            int index = Size - 1;
            while (index > 0 && _items[index] < _items[ParentIndex(index)])
            {
                int parentIndex = ParentIndex(index);
                Swap(index, parentIndex);
                index = parentIndex;
            }
        }

        private void Swap(int index, int parentIndex)
        {
            int temp = _items[index];
            _items[index] = _items[parentIndex];
            _items[parentIndex] = temp;
        }

        private int ParentIndex(int index)
            => (index - 1) / 2;
    }
}
