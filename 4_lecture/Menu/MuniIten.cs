

namespace Menu
{
    class MenuItem : IMenuItem
    {
        public string Title { get; }

        public MenuItem(string title)
        {
            Title = title;
        }

        public void Select()
        {

        }
    }
}
