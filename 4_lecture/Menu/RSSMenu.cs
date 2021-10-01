using System;
using System.ServiceModel.Syndication;
using System.Xml;

namespace Menu
{
    class RSSMenu : Menu
    {
        private Uri _Uri;

        public RSSMenu(Uri uri) : base(uri.AbsolutePath)
        {
            _Uri = uri;
        }

        public override void Select()
        {
            XmlReader Reader = XmlReader.Create(_Uri.AbsoluteUri);
            SyndicationFeed Feed = SyndicationFeed.Load(Reader);
            Reader.Close();
            foreach (SyndicationItem item in Feed.Items)
            {
                Items.Add(new RSSMenuItem(item));
            }

            base.Select();
        }

    }
}
