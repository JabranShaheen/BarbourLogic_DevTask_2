using BarbourLogic_Pathfinding.StarAlgo.PriorityQueue;
using System;
using System.Collections.Generic;

namespace BarbourLogic_Pathfinding_Algorithm.Utilities
{
    public class PriorityQueue<T> : IPriorityQueue<T>
    {
        private List<T> data;
        private readonly Comparison<T> compare;

        public PriorityQueue(Comparison<T> compare)
        {
            this.data = new List<T>();
            this.compare = compare;
        }

        public void Enqueue(T item)
        {
            data.Add(item);
            int ci = data.Count - 1; // child index; start at end
            while (ci > 0)
            {
                int pi = (ci - 1) / 2; // parent index
                if (compare(data[ci], data[pi]) >= 0) break; // child item is larger than (or equal to) parent so we're done
                T tmp = data[ci]; data[ci] = data[pi]; data[pi] = tmp;
                ci = pi;
            }
        }

        public T Dequeue()
        {
            if (data.Count == 0) throw new InvalidOperationException("Priority queue is empty.");

            int li = data.Count - 1; // last index (before removal)
            T frontItem = data[0];   // fetch the front
            data[0] = data[li];
            data.RemoveAt(li);

            --li; // last index (after removal)
            int pi = 0; // parent index. start at front of pq
            while (true)
            {
                int ci = pi * 2 + 1; // left child index of parent
                if (ci > li) break;  // no children so done
                int rc = ci + 1;     // right child
                if (rc <= li && compare(data[rc], data[ci]) < 0) // if there is a right child (rc <= li) and it is smaller
                    ci = rc; // use the right child instead
                if (compare(data[pi], data[ci]) <= 0) break; // parent is smaller than (or equal to) smallest child so done
                T tmp = data[pi]; data[pi] = data[ci]; data[ci] = tmp; // swap parent and child
                pi = ci;
            }
            return frontItem;
        }

        public int Count
        {
            get { return data.Count; }
        }
    }
}
