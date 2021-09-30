namespace Menu
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu("fancymenu");

            menu.Add( new MenuItem("Punkt1") );
            menu.Add( new MenuItem("Punkt2") );
            menu.Add( new MenuItem("Punkt3") );

            Menu underMenu = new Menu( "undermenu"
                                     , new MenuItem("testpunkt")
                                     , new MenuItem("testpunkt2") );

            menu.Add(underMenu);

            menu.Start();
        }
    }
}
