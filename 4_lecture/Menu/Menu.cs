using System;
using System.Collections.Generic;

namespace Menu
{
    class Menu : IMenuItem
    {
        public string Title { get; }
        protected List<IMenuItem> Items = new List<IMenuItem>();
        private bool _Running;
        private int _SelectedItem;

        public Menu(string title)
        {
            Title = title;
            _Running = false;
            _SelectedItem = 0;
        }

        public Menu(string title, params IMenuItem[] items)
        : this(title)
        {
            foreach (IMenuItem item in items)
            {
                Items.Add(item);
            }
        }

        public virtual void Select()
        {
            Console.Clear();
            Start();
        }

        public void Add(IMenuItem item) => Items.Add(item);

        public void Add(params IMenuItem[] items)
        {
            foreach (IMenuItem item in items)
            {
                Items.Add(item);
            }
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
                if (i == _SelectedItem)
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

        // input is with vim keybinds
        // TODO: get it like ranger
        // to that menus will have to stay running unless the selected item is not another menu
        private void HandleInput()
        {
            ConsoleKeyInfo CKI = Console.ReadKey();
            switch (CKI.Key)
            {
                case ConsoleKey.H:
                    _Running = false;
                    break;
                case ConsoleKey.J:
                    MoveDown();
                    break;
                case ConsoleKey.K:
                    MoveUp();
                    break;
                case ConsoleKey.L:
                    _Running = false;
                    Items[_SelectedItem].Select();
                    break;
                default:
                    break;
            }
        }

        private void MoveUp()
        {
            if (_SelectedItem == 0) return;
            else _SelectedItem--;
        }

        private void MoveDown()
        {
            if (_SelectedItem + 1 == Items.Count) return;
            else _SelectedItem++;
        }
    }
}
