using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TAlex.SEOStats.Alexa;


namespace TAlex.SEOStats.Tests.Alexa
{
    [TestFixture]
    public class AlexaStatsTests
    {
        protected AlexaStats Target;


        [SetUp]
        public virtual void SetUp()
        {
            Target = new AlexaStats();
        }


        #region GetStats

        [Test]
        public void GetStats_Domain_Success()
        {
            //arrange
            const string domain = "http://google.com";

            //action
            var actual = Target.GetStats(domain);

            //assert
            Assert.True(actual.Success);
        }

        [Test]
        public void GetStats_Domain_ReachRankCorrectRange()
        {
            //arrange
            const string domain = "http://google.com";

            //action
            var actual = Target.GetStats(domain);

            //assert
            Assert.True(actual.ReachRank > 0 && actual.ReachRank <= 3);
        }

        [Test]
        public void GetStats_Domain_TrafficRankCorrectRange()
        {
            //arrange
            const string domain = "http://google.com";

            //action
            var actual = Target.GetStats(domain);

            //assert
            Assert.True(actual.TrafficRank > 0 && actual.TrafficRank <= 3);
        }

        #endregion
    }
}
