using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TAlex.SEOStats.Google
{
    public class GoogleResult : BaseResult
    {
        public override string ServiceName
        {
            get { return "Google"; }
        }

        public override IDictionary<string, object> GetStats()
        {
            IDictionary<string, object> stats = new Dictionary<string, object>();
            stats.Add("Page Rank", PageRank);

            return stats;
        }


        public int PageRank { get; set; }
    }
}
