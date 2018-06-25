using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogModels
{
    [Serializable()]
    public class Article
    {
        private int id;
        private User author;
        private string title = String.Empty;
        private string contents = String.Empty;
        private DateTime pubDate;
        private int clicks;

        public Article() { }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public User Author
        {
            get { return this.author; }
            set { this.author = value; }
        }

        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }

        public string Contents
        {
            get { return this.contents; }
            set { this.contents = value; }
        }

        public DateTime PubDate
        {
            get { return this.pubDate; }
            set { this.pubDate = value; }
        }

        public int Clicks
        {
            get { return this.clicks; }
            set { this.clicks = value; }
        }

    }
}
