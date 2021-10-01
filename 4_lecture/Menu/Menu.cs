using System;
using System.Collections.Generic;

namespace Menu
{
    class Menu : IMenuItem
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

        public Menu(string title, params IMenuItem[] items)
        : this(title)
        {
            foreach (IMenuItem item in items)
            {
                Items.Add(item);
            }
        }

        public virtual void Select() {}

        public void Add(IMenuItem item) => Items.Add(item);

        public void Add(params IMenuItem[] items)
        {
            foreach (IMenuItem item in items)
            {
                Items.Add(item);
            }
        }

        public void Draw()
        {
            Console.Clear();
            for (int i = 0; i < Items.Count; i++)
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
            else _Pos--;
        }

        public void MoveDown()
        {
            if (_Pos + 1 == Items.Count) return;
            else _Pos++;
        }
    }
}
