using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TextSplitWebApp.Models
{
    public class BookContext : DbContext
    {
        public BookContext()  :base("TextSplitSentences")
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Paragraph> Paragraphs { get; set; }
        public DbSet<Sentence> Sentences { get; set; }
    }

}