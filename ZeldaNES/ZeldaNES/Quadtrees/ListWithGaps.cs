using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaNES.Quadtrees
{
    public class ListWithGaps<T>
        where T : class
    {
        private List<T> list;
        private Queue<int> freeSlots;
        public T this[int i]
        {
            get { return list[i]; }
            set { list[i] = value; }
        }
        public int Count
        {
            get { return list.Count; }
        }

        public ListWithGaps()
        {
            list = new List<T>();
            freeSlots = new Queue<int>();
        }
        public ListWithGaps(int capacity)
        {
            list = new List<T>(capacity);
            freeSlots = new Queue<int>();
        }

        public int Add(T item)
        {
            if (freeSlots.Count != 0)
            {
                int index = freeSlots.Dequeue();
                list[index] = item;
                return index;
            }

            list.Add(item);
            return list.Count - 1;
        }
        public int Remove(T item)
        {
            int index = list.IndexOf(item);
            list[index] = null;
            freeSlots.Enqueue(index);
            return index;
        }
        public void Remove(int index)
        {
            list[index] = null;
            freeSlots.Enqueue(index);
        }
        public T ValueAt(int index)
        {
            return list[index];
        }
    }
}
