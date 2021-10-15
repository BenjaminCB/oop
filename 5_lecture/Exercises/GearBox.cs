using System;

namespace Exercises
{
    public class GearBox
    {
        public int[] Gears { get; } = { -1, 1, 2, 3, 4, 5 };
        private int _CurrentGear;
        public int CurrentGear
        {
            get => _CurrentGear;
            set
            {
                if (!Array.Exists(Gears, gear => gear == value))
                    throw new ArgumentException("GearBox does not gear " + value);
                _CurrentGear = value;
            }
        }
    }

    public class IllegalGearChangeException : Exception
    {
        public IllegalGearChangeException()
            : base("You cannot skip a gear when switching") {}
    }
}
