using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Heap
{
    public class Heap
    {
        public int[] items = new int[10];
        private int size;

        public void Insert(int value)
        {
            if (IsFull ())
                throw new Exception("Heap is full");

            items[size++] = value;

            BubbleUp();

        }

        public int Remove()
        {
            if (IsEmpty())
                throw new Exception("Heap is empty");
            var root = items[0]; 
            items[0] = items[--size];
            BubbleDown();

            return root;
        }

        public int Peek()
        {
            if (IsEmpty())
                throw new Exception("Heap is empty");
            return items[0];
        }

        private void BubbleDown()
        {
            var index = 0;
            while (index <= size && !IsValidParent(index))
            {
                int largerChildIndex = LargerChildIndex(index);

                Swap(index, largerChildIndex);
                index = largerChildIndex;
            }
        }

        private bool HasRightChild(int index)
        {
            return RightChildIndex(index) <= size;
        }
        private bool HasLeftChild(int index)
        {
            return LeftChildIndex(index) <= size;
        }

        private bool IsEmpty()
        {
            return size == 0;
        }

        private int LargerChildIndex(int index)
        {
            if(!HasLeftChild(index))
                return index;
            if(!HasRightChild(index))
                return LeftChildIndex(index);

            return (LeftChild(index) > RightChild(index)) ?
                                LeftChildIndex(index) : RightChildIndex(index);
        }

        private bool IsValidParent(int index)
        {
            if(!HasLeftChild(index))
                return true;

            var isValid = items[index] >= LeftChild(index);

            if (HasRightChild(index))
                isValid &= items[index] >= RightChild(index);

            return isValid;
        }

        private int RightChild(int index)
            => items[RightChildIndex(index)];

        private int LeftChild(int index)
            => items[LeftChildIndex(index)];

        private int LeftChildIndex(int index) => 2 * index + 1;
        private int RightChildIndex(int index) => 2 * index + 2;


        private bool IsFull()
        {
            return size == items.Length;
        }

        private void BubbleUp()
        {
            var index = size - 1;
            while (index > 0 && items[index] > items[Parent(index)])
            {
                Swap(index, Parent(index));
                index = Parent(index);
            }
        }

        private static int Parent(int index) =>
            index = (index - 1) / 2;

        private void Swap(int first, int second)
        {
            var temp = items[first];
            items[first] = items[second];
            items[second] = temp;
        }

    }
}
