using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TAlex.SEOStats.Google;


namespace TAlex.SEOStats.Tests.Google
{
    [TestFixture]
    public class GoogleStatsTests
    {
        protected GoogleStats Target;


        [SetUp]
        public virtual void SetUp()
        {
            Target = new GoogleStats();
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
        public void GetStats_Domain_PageRankCorrectRange()
        {
            //arrange
            const string domain = "http://google.com";

            //action
            var actual = Target.GetStats(domain);

            //assert
            Assert.True(actual.PageRank >= 0 && actual.PageRank <= 10);
        }

        #endregion
    }
}
