namespace Menu
{
    class CustomMenu : Menu, IMenuItem
    {
        public CustomMenu(string title) : base(title) {}

        public CustomMenu(string title, params IMenuItem[] items)
        : base(title)
        {
            foreach (IMenuItem item in items)
            {
                Items.Add(item);
            }
        }

        public void Add(IMenuItem item) => Items.Add(item);

        public void Add(params IMenuItem[] items)
        {
            foreach (IMenuItem item in items)
            {
                Items.Add(item);
            }
        }
    }
}
