namespace Exercises
{
    class Tuple<A, B>
    {
        public A Fst { get; }
        public B Snd { get; }

        public Tuple(A fst, B snd)
        {
            Fst = fst;
            Snd = snd;
        }

        public Tuple<B, A> Swap() => new Tuple<B, A>(Snd, Fst);

        public Tuple<C, B> SetFst<C>(C c) => new Tuple<C, B>(c, Snd);
        public Tuple<A, C> SetSnd<C>(C c) => new Tuple<A, C>(Fst, c);

        public override string ToString() => $"({Fst},{Snd})";
    }
}
