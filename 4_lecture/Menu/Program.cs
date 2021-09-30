using System.IO;
using System;

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

            InfiniteMenu infinite = new InfiniteMenu("INFINITE");
            menu.Add(infinite);

            DirectoryItem fsm = new DirectoryItem( new DirectoryInfo("/home/bcb/") );
            menu.Add(fsm);

            RSSMenu rss = new RSSMenu(new Uri("https://news.ycombinator.com/rss"));
            menu.Add(rss);

            RSSMenu rss2 = new RSSMenu(new Uri("http://blog.dota2.com/feed"));
            menu.Add(rss2);

            RSSMenu rss3 = new RSSMenu(new Uri("http://www.dr.dk/Nyheder/Service/rss.htm"));
            menu.Add(rss3);

            menu.Start();
        }
    }
}
