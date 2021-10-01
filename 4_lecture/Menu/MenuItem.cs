using System;

namespace Menu
{
    class MenuItem : IMenuItem
    {
        public string Title { get; }
        private string _Content;

        public MenuItem(string title)
        {
            Title = title;
            _Content = title;
        }

        public MenuItem(string title, string content)
        {
            Title = title;
            _Content = content;
        }

        public void Select() {}

        public void Draw()
        {
            Console.Clear();
            Console.WriteLine(_Content);
        }
    }
}
