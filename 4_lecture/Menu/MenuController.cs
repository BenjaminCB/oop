using System.Collections.Generic;
using System;

namespace Menu
{
    class MenuController
    {
        private bool _Running;
        private Stack<IMenuItem> _Menus;
        private IMenuItem _Current { get => _Menus.Peek(); }

        public MenuController(IMenuItem menu)
        {
            _Menus.Push(menu);
        }

        public void Start()
        {
            _Running = true;
            while (_Running)
            {
                _Current.Draw();
                HandleInput();
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
                case ConsoleKey.Q:
                    _Running = false;
                    break;
                case ConsoleKey.H:
                    _GoBack();
                    break;
                case ConsoleKey.L:
                    _GoForward();
                    break;
                case ConsoleKey.J:
                    _Current.MoveDown();
                    break;
                case ConsoleKey.K:
                    _Current.MoveUp();
                    break;
                default:
                    break;
            }
        }

        private void _GoBack() => _Menus.Pop();

        private void _GoForward()
        {
            _Menus.Push(_Current.selectedItem);
            _Current.Select();
        }
    }
}
