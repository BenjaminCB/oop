using System;

namespace GameObject
{
    class Die: GameObject
    {
        private int numberOfEyes;
        private Random randomNumberSupplier;
        private readonly int maxNumberOfEyes;

        public Die (): this(6){}

        public Die (int maxNumberOfEyes)
        {
            randomNumberSupplier = new Random(unchecked((int)DateTime.Now.Ticks));
            this.maxNumberOfEyes = maxNumberOfEyes;
            numberOfEyes = NewTossHowManyEyes();
        }

        public void Toss ()
        {
            numberOfEyes = NewTossHowManyEyes();
        }

        private int NewTossHowManyEyes() => randomNumberSupplier.Next(1,maxNumberOfEyes + 1);

        public int NumberOfEyes() => numberOfEyes;

        public override String ToString() => String.Format("Die[{0}]: {1}", maxNumberOfEyes, numberOfEyes);

        public override int GameValue
        {
            get => numberOfEyes;
        }

        public override GameObjectMedium Medium
        {
            get => GameObjectMedium.Plastic;
        }

    }
}
