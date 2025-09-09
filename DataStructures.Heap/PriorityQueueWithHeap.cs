using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Heap
{
    public class PriorityQueueWithHeap
    {
        private Heap heap = new Heap();
        public void Add(int item)
        {
            heap.Insert(item);
        }
        public int Remove()
        {
            return heap.Remove();
        }
    }
}
