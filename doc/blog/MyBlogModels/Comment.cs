using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogModels
{
    [Serializable()]
    public class Comment
    {
        private int id;
        private Article article;
        private string authorName = String.Empty;
        private string contents = String.Empty;
        private DateTime pubDate;

        public Comment() { }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public Article Article
        {
            get { return this.article; }
            set { this.article = value; }
        }

        public string AuthorName
        {
            get { return this.authorName; }
            set { this.authorName = value; }
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

    }
}
