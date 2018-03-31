using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAlex.SEOStats.Alexa
{
    public class AlexaResult : BaseResult
    {
        public override string ServiceName
        {
            get { return "Alexa"; }
        }

        public override IDictionary<string, object> GetStats()
        {
            IDictionary<string, object> stats = new Dictionary<string, object>();
            stats.Add("Traffic Rank", TrafficRank.HasValue ? TrafficRank.Value.ToString("N0") : null);
            stats.Add("Reach Rank", ReachRank.HasValue ? ReachRank.Value.ToString("N0") : null);
            stats.Add("Rank Delta", RankDelta.HasValue ? RankDelta.Value.ToString("N0") : null);
            stats.Add("Links In", LinksIn);

            return stats;
        }


        public DateTime? ClaimedDate { get; set; }

        public int? TrafficRank { get; set; }

        public int? ReachRank { get; set; }

        public int? RankDelta { get; set; }

        public int? LinksIn { get; set; }


        public AlexaResult()
        {
        }
    }
}
