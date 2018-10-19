using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FanSite.Models
{
    public class LinkRepository
    {
        private static List<Link> links = new List<Link>();

        public static List<Link> Links { get { return links; } }

        static LinkRepository()
        {
            addTestData();
        }

        public static void AddLink(Link link)
        {
            links.Add(link);
        }

        static void addTestData()
        {
            Link link1;
            Link link2;
            Link link3;

            link1 = new Link()
            {
                Title = "Indian Independence",
                URL = "https://www.culturalindia.net/indian-history/modern-history/indian-independence.html",
                Description = "Collection of numerous first hand accounts of Ghandi and the Indian Independence Movement"
            };

            link2 = new Link()
            {
                Title = "Wikipedia",
                URL = "https://en.wikipedia.org/wiki/Mahatma_Gandhi",
                Description = "Community authors contribute to overall biographic information"
            };

            link3 = new Link()
            {
                Title= "History Channel",
                URL = "https://www.history.com/topics/india/mahatma-gandhi",
                Description= "The history channel is a long standing verified source of countless historical figures and events"
            };

            links.Add(link1);
            links.Add(link2);
            links.Add(link3);
        }
        


    }
}
