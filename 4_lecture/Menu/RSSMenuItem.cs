using System;
using System.ServiceModel.Syndication;

namespace Menu
{
    class RSSMenuItem : IMenuItem
    {
        public string Title { get => _Item.Title.Text; }
        private SyndicationItem _Item;

        public RSSMenuItem(SyndicationItem item)
        {
            _Item = item;
        }

        public void Select()
        {
            Console.Clear();
            Console.WriteLine(_Item.Summary.Text);
        }
    }
}
