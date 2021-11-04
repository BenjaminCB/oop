using System.Collections.Generic;
using System.Collections;

namespace Exercises
{
    public class Sequence : IEnumerable<int>
    {
        public int Start { get; private set; }
        public int End { get; private set; }
        public int Skip { get; private set; }
        private List<int> sequence = new List<int>();

        public Sequence(int start, int end, int skip)
        {
            Start = start;
            End = end;
            Skip = skip;

            for (int i = start; i <= end; i+= skip)
            {
                sequence.Add(i);
            }
        }

        public Sequence(int start, int count) : this(start, count, 1) {}
        public Sequence(int count) : this(0, count, 1) {}


        public IEnumerator<int> GetEnumerator() => sequence.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    /* public class SequenceEnumerator : IEnumerator<int> */
    /* { */
    /*     private int _Start { get; set; } */
    /*     private int _Count { get; set; } */
    /*     private int _Skip { get; set; } */
    /*     private int _Current { get; set; } */

    /*     public SequenceEnumerator(int start, int count, int skip) */
    /*     { */
    /*         _Start = start; */
    /*         _Count = count; */
    /*         _Skip = skip; */
    /*         _Current = start; */
    /*     } */

    /*     public bool MoveNext() */
    /*     { */
    /*         if (_Count == 0) return false; */

    /*         _Count--; */
    /*         _Current += _Skip; */

    /*         return true; */
    /*     } */

    /*     public int Current => _Current; */

    /*     void IDisposable.Dispose() {} */
    /*     public void Reset() { _Current = _Start; } */
    /* } */
}
