namespace Menu
{
    interface IMenuItem
    {
        // title shown in menus
        string Title { get; }

        // What should happen when the item is selected
        void Select();

        // How do you draw this item once it has been selected
        void Draw();
    }
}
