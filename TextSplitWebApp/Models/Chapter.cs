using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextSplitWebApp.Models
{
    public class Chapter
    {
        public int ID { get; set; }
        public int LanguageID { get; set; }
        public int ChapterNumber { get; set; }
        public string ChapterName { get; set; }
    }
}