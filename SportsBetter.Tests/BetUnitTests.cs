using NUnit.Framework;
using SportsBetter.Library;


namespace SportsBetter.Tests
{
    /// <summary>
    /// Documentation available at https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit#prerequisites.
    /// </summary>
    [TestFixture]
    public class BetUnitTests
    {
        private StraightBet _bet;

        [SetUp]
        public void SetUp()
        {
            _bet = new Bet
            {
                Wager = 1.00,
                Odds = 100
            };
        }

        [Test]
        public void BetUnitTest1()
        {
            Assert.Pass();
        }
    }
}
