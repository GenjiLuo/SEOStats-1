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
    public class AlexaResultTests
    {
        protected AlexaResult Target;


        [SetUp]
        public virtual void SetUp()
        {
            Target = new AlexaResult();
        }


        #region GetStats

        [Test]
        public void GetStats_EmptyStatus_Dictionary()
        {
            //action
            var actual = Target.GetStats();

            //assert
            Assert.NotNull(actual);
        }

        [Test]
        public void GetStats_FilledStatus_Dictionary()
        {
            //arrange
            Target = new AlexaResult { ClaimedDate = DateTime.Now, TrafficRank = 1, LinksIn = 500, RankDelta = 0, ReachRank = 1, Success = true };

            //action
            var actual = Target.GetStats();

            //assert
            Assert.NotNull(actual);
        }

        #endregion
    }
}
