using System;
using System.Collections.Generic;

namespace Menu
{
    class Menu : IMenuItem
    {
        public string Title { get; }
        private List<IMenuItem> Items = new List<IMenuItem>();
        private bool _Running;
        private int _Pos;

        public Menu(string title)
        {
            Title = title;
            _Running = false;
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

        public void Select()
        {
            Console.Clear();
            Start();
        }

        public void Start()
        {
            _Running = true;
            while (_Running)
            {
                DrawMenu();
                HandleInput();
            }
        }

        private void DrawMenu()
        {
            Console.Clear();
            for (int i = 0; i < Items.Count; i++)
            {
                if (i == _Pos)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(Items[i]);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.WriteLine(Items[i]);
                }
            }
        }

        private void HandleInput()
        {

        }
    }
}
