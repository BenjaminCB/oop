namespace Menu
{
    class InfiniteMenu : Menu
    {
        public InfiniteMenu(string title) : base(title){}

        public override void Select()
        {
            Items.Add( new InfiniteMenu(Title + "YOU") );
            Items.Add( new InfiniteMenu(Title + "DONE") );
            Items.Add( new InfiniteMenu(Title + "FUCKED") );
            Items.Add( new InfiniteMenu(Title + "UP") );
            Items.Add( new InfiniteMenu(Title + "!") );
            base.Select();
        }
    }
}
