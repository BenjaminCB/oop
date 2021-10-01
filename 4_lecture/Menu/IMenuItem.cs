namespace Menu
{
    interface IMenuItem
    {
        string Title { get; }
        void Select();
        void Draw();
        void MoveUp();
        void MoveDown();
    }
}
