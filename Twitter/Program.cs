using System;
using System.Collections.Generic;
using Olapic.Lib;

namespace Harness
{
    class Program
    {
        static void Main(string[] args)
        {
            var twitter = new Twitter
            {
                OAuthConsumerKey = "XdLDQzuQzEDfPtQQqHrgqc5HU",
                OAuthConsumerSecret = "HZ6Z7U9oZnluluj5bytf8LTfEgyVZXAN6MCV8ZbHoYwktQFyqa"
            };

            var olapic = new OlapicMgr
            {
                ApiKey = "8eb975f77afdb5309af98507ce52477d137d1445bf1de2d0039deba508b12c51",
                MediaEndpoint = "https://photorankapi-a.akamaihd.net/customers/217064/media/photorank",
                StreamEndpoint = "https://photorankapi-a.akamaihd.net/streams/"
            };
            var list = olapic.GetRecentPhotos();
            IEnumerable<string> twitts = twitter.GetTwitts("ramnkl16", 10).Result;

            foreach (var t in twitts)
            {
                Console.WriteLine(t+"\n");
            }
            Console.ReadKey();
        }
    }
}
