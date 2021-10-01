using System;
using System.Collections.Generic;

namespace Menu
{
    abstract class Menu : IMenuItem, IScrollable
    {
        public string Title { get; }
        protected List<IMenuItem> Items = new List<IMenuItem>();
        public IMenuItem SelectedItem { get => Items[_Pos]; }
        private int _Pos;

        public Menu(string title)
        {
            Title = title;
            _Pos = 0;
        }

        public virtual void Select() {}

        public void Draw()
        {
            int Start,
                End;

            // find the viewing indencies
            if (Items.Count <= 10)
            {
                Start = 0;
                End = Items.Count;
            }
            else if (_Pos < 10)
            {
                Start = 0;
                End = 10;
            }
            else
            {
                Start = _Pos - 9;
                End = _Pos + 1;
            }

            Console.Clear();
            for (int i = Start; i < End; i++)
            {
                if (i == _Pos)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(Items[i].Title);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.WriteLine(Items[i].Title);
                }
            }
        }

        public void MoveUp()
        {
            if (_Pos == 0) return;
            _Pos--;
        }

        public void MoveDown()
        {
            if (_Pos + 1 == Items.Count) return;
            else _Pos++;
        }
    }
}
