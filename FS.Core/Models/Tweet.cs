using System;
using System.Collections.Generic;
using System.Text;

namespace FS.Core.Models
{
    public class Tweet
    {
        public const string UnknownName = "Unknown";
        public const string UnknownDate = "unknown date";
        public const string UnknownText = "";

        public string Name { get; set; }
        public string Date { get; set; }
        public bool IsRetweet { get; set; }
        public string RetweetName { get; set; }
        public string RetweetDate { get; set; }
        public string Text { get; set; }
    }
}
