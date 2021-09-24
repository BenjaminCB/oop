using System;

namespace GameObject
{
    class Card: GameObject
    {
        public enum CardSuite { spades, hearts, clubs, diamonds };
        public enum CardValue { two = 2, three = 3, four = 4, five = 5
                              , six = 6, seven = 7, eight = 8, nine = 9
                              , ten = 10, jack = 11, queen = 12, king = 13
                              , ace = 14 };

        private CardSuite _Suite;
        private CardValue _Value;

        public Card(CardSuite suite, CardValue value)
        {
            _Suite = suite;
            _Value = value;
        }

        public CardSuite Suite
        {
            get => _Suite;
        }

        public CardValue Value
        {
            get => _Value;
        }

        public override String ToString() => String.Format("Suite:{0}, Value:{1}", _Suite, _Value);

        public override int GameValue
        {
            get => (int) _Value;
        }

        public override GameObjectMedium Medium
        {
            get => GameObjectMedium.Paper;
        }
    }
}
