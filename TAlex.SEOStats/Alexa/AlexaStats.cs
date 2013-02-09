using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TAlex.SEOStats.Alexa
{
    public class AlexaStats : IBaseStats<AlexaResult>
    {
        private const string StatsRequstPattern = "http://data.alexa.com/data?cli=10&dat=snbamz&url={0}";

        #region IBaseStats<AlexaResult> Members

        public AlexaResult GetStats(string domain)
        {
            AlexaResult result = new AlexaResult();

            try
            {
                string url = String.Format(StatsRequstPattern, domain);
                var doc = XDocument.Load(url);

                result.ClaimedDate = DateTime.Parse(doc.Descendants("CLAIMED").Select(node => node.Attribute("DATE").Value).FirstOrDefault());
                result.TrafficRank = int.Parse(doc.Descendants("POPULARITY").Select(node => node.Attribute("TEXT").Value).FirstOrDefault());
                result.ReachRank = int.Parse(doc.Descendants("REACH").Select(node => node.Attribute("RANK").Value).FirstOrDefault());
                result.RankDelta = int.Parse(doc.Descendants("RANK").Select(node => node.Attribute("DELTA").Value).FirstOrDefault());
                result.LinksIn = int.Parse(doc.Descendants("LINKSIN").Select(node => node.Attribute("NUM").Value).FirstOrDefault());

                result.Success = true;
            }
            catch (Exception)
            {
                result.Success = false;
            }

            return result;
        }

        #endregion
    }
}
