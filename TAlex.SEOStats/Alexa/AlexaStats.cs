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

                var claimedDate = GetValue(doc, "CLAIMED", "DATE");
                result.ClaimedDate = claimedDate != null ? DateTime.Parse(claimedDate) : (DateTime?)null;

                result.TrafficRank = GetIntValue(doc, "POPULARITY", "TEXT");
                result.ReachRank = GetIntValue(doc, "REACH", "RANK");
                result.RankDelta = GetIntValue(doc, "RANK", "DELTA");
                result.LinksIn = GetIntValue(doc, "LINKSIN", "NUM");

                result.Success = true;
            }
            catch (Exception)
            {
                result.Success = false;
            }

            return result;
        }

        private string GetValue(XDocument document, string nodeName, string attributeName)
        {
            var node = document.Descendants(nodeName).FirstOrDefault();
            return node != null ? node.Attribute(attributeName).Value : null;
        }

        private int? GetIntValue(XDocument document, string nodeName, string attributeName)
        {
            var value = GetValue(document, nodeName, attributeName);
            return (value != null) ? int.Parse(value) : (int?)null;
        }

        #endregion
    }
}
