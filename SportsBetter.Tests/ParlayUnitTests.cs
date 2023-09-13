using NUnit.Framework;
using SportsBetter.Library;
using System.Collections.Generic;
using System.Diagnostics;

namespace SportsBetter.Tests
{
    /// <summary>
    /// Documentation available at https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit#prerequisites.
    /// </summary>
    [TestFixture]
    public class ParlayUnitTests
    {
        private Parlay _parlay;

        [SetUp]
        public void Setup()
        {
            this._parlay = new Parlay();
        }

        // There are too many members being tested in this test case

        [Test]
        public void CalculateOddsTest1()
        {
            // Debug.Assert(this._parlay) => make sure that there are no bets in this parlay

            // AddBet needs to be tested seperately
            this._parlay.AddBet(new Bet { Odds = -110 });
            this._parlay.AddBet(new Bet { Odds = -110 });
            this._parlay.AddBet(new Bet { Odds = -110 });

            Assert.That(this._parlay.Odds, Is.EqualTo(597));
        }
    }
}