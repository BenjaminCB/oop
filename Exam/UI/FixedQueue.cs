using System;
using System.Collections.Generic;
using System.Collections;

// should probably be in a more fitting namespace
namespace Exam.UI
{
    // Only implementing what is needed for my current purposes
    public class FixedQueue<T> : IEnumerable<T>
    {
        public int MaxSize { get; }
        private Queue<T> _Queue;

        // takes the parameter maxSize which will the maximum amount of elements in the queue
        public FixedQueue(int maxSize)
        {
            if (maxSize < 0) throw new ArgumentException("maxSize cannot be negative");
            MaxSize = maxSize;
            _Queue = new Queue<T>();
        }

        public void Enqueue(T t)
        {
            _Queue.Enqueue(t);

            // if there are too many elements in the queue simply dequeue the last one
            if (_Queue.Count > MaxSize) _Queue.Dequeue();
        }

        public IEnumerator<T> GetEnumerator() => _Queue.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
