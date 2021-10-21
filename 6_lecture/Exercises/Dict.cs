using System;
using System.Collections.Generic;

namespace Exercises
{
    class Dict<TKey, TValue>
    {
        private List<Tuple<TKey,TValue>> Pairs = new List<Tuple<TKey,TValue>>();

        // this could probably be done more efficiently
        public TValue Search(TKey key)
        {
            if (!Pairs.Exists(tup => tup.Fst.Equals(key)))
                throw new ArgumentException("Key not found");

            return Pairs.Find(tup => tup.Fst.Equals(key)).Snd;
        }

        // this could probably be done more efficiently
        public void Put(TKey key, TValue val)
        {
            if (Pairs.Exists(tup => tup.Fst.Equals(key)))
            {
                int i = Pairs.FindIndex(tup => tup.Fst.Equals(key));
                Pairs[i] = Pairs[i].SetSnd<TValue>(val);
            }
            else
            {
                Pairs.Add(new Tuple<TKey,TValue>(key, val));
            }
        }
    }
}
