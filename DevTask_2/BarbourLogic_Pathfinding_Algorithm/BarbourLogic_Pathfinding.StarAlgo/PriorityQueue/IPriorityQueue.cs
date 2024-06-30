using System;

namespace BarbourLogic_Pathfinding.StarAlgo.PriorityQueue
{
    public interface IPriorityQueue<T>
    {
        void Enqueue(T item);
        T Dequeue();
        int Count { get; }
    }
}
