using NUnit.Framework;
using SportsBetter.Library;
using System.Collections.Generic;
using System.Diagnostics;

namespace SportsBetter.Tests.ParlayTests
{
    /// <summary>
    /// Documentation available at https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit#prerequisites.
    /// </summary>
    [TestFixture]
    public class ParlayOddsUnitTests
    {
        private Parlaybet _parlay;

        [SetUp]
        public void Setup()
        {
            _parlay = new Parlay();
        }

        [Test]
        public void OddsSize1_Negative150()
        {
            var bet = new Bet
            {
                Odds = -150
            };

            _parlay.AddBet(bet);
            Assert.That(_parlay.Odds, Is.EqualTo(-150));
        }

        [Test]
        public void OddsSize1_Positive150()
        {
            var bet = new Bet
            {
                Odds = 150
            };

            _parlay.AddBet(bet);
            Assert.That(_parlay.Odds, Is.EqualTo(150));
        }

        [Test]
        public void OddsSize2_Positive178()
        {
            var bet1 = new Bet
            {
                Odds = -150
            };

            var bet2 = new Bet
            {
                Odds = -150
            };

            _parlay.AddBet(bet1);
            _parlay.AddBet(bet2);
            Assert.That(_parlay.Odds, Is.EqualTo(178));
        }

        [Test]
        public void OddsSize2_Positive525()
        {
            var bet1 = new Bet
            {
                Odds = 150
            };

            var bet2 = new Bet
            {
                Odds = 150
            };

            _parlay.AddBet(bet1);
            _parlay.AddBet(bet2);
            Assert.That(_parlay.Odds, Is.EqualTo(525));
        }
    }
}