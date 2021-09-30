using System.ServiceModel.Syndication;
using System.Xml;
using System;

namespace RSS
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://www.dr.dk/nyheder/service/feeds/allenyheder";
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();
            foreach (SyndicationItem item in feed.Items)
            {
                Console.WriteLine(item.Title.Text);
                // Something is wrong with drs Summary.Text i think
                /* Console.WriteLine(item.Summary.Text); */
            }
        }
    }
}
