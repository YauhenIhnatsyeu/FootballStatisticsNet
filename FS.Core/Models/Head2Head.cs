using System;
using System.Collections.Generic;
using System.Text;

namespace FS.Core.Models
{
    public class Head2Head
    {
        public Fixture Fixture { get; set; }
        public ICollection<Fixture> Fixtures { get; set; }
        public Head2HeadInfo Info { get; set; }

        public class Head2HeadInfo
        {
            public int HomeTeamWins { get; set; }
            public int AwayTeamWins { get; set; }
            public int Draws { get; set; }
        }
    }
}
