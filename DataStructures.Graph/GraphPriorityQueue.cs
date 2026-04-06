namespace DataStructures.Graph
{
    public class GraphPriorityQueue // MINHEAP
    {
        private (int Vetex, int Distance)[] _items = new (int, int)[15];
        public int Size { get; private set; } = 0;

        public void Insert(int vertex, int distance)
        {
            if (Size == _items.Length)
                Array.Resize(ref _items, _items.Length * 2);
            _items[Size++] = (vertex, distance);
            BubbleUp();
        }

        public (int Vertex, int Distance) Remove()
        {
            var removed = _items[0];
            _items[0] = _items[--Size];
            _items[Size] = (0, 0);
            if(Size > 0)
                BubbleDown();

            return removed;
        }

        private void BubbleDown()
        {
            int index = 0;

            while (index < _items.Length && _items[index].Distance > _items[LeftChildIndex(index)].Distance && _items[index].Distance > _items[RightChildIndex(index)].Distance)
            {
                int smallestNodeIndex = _items[LeftChildIndex(index)].Distance < _items[RightChildIndex(index)].Distance
                    ? LeftChildIndex(index)
                    : RightChildIndex(index);
                Swap(index, smallestNodeIndex);
                index = smallestNodeIndex;
            }
        }

        

        private void BubbleUp()
        {
            int index = Size - 1;
            while (index > 0 && _items[index].Distance < _items[ParentIndex(index)].Distance)
            {
                int parentIndex = ParentIndex(index);
                Swap(index, parentIndex);
                index = parentIndex;
            }
        }

        private void Swap(int index, int parentIndex)
        {
            var temp = _items[index];
            _items[index] = _items[parentIndex];
            _items[parentIndex] = temp;
        }
        private int LeftChildIndex(int index)
            => (index * 2) + 1;
        private int RightChildIndex(int index)
            => (index * 2) + 2;
        private int ParentIndex(int index)
            => (index - 1) / 2;
    }
}
