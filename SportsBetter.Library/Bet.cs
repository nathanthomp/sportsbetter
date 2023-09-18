using System;

namespace SportsBetter.Library
{
    public class Bet
    {
        /// <summary>
        /// Calculates the bet's reward. This is calculated by
        /// </summary>
        /// <param name="odds">The bet's odds.</param>
        /// <param name="wager">The wager amount.</param>
        /// <returns>Reward of this bet.</returns>
        /// <exception cref="NotImplementedException"></exception>
        private static double CaculateReward(int odds, double wager)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The dollar amount wager.
        /// </summary>
        public double Wager { get; set; }

        /// <summary>
        /// The american odds.
        /// </summary>
        public int Odds { get; set; }

        /// <summary>
        /// The dollar amount reward.
        /// </summary>
        //public double Reward { get { return CaculateReward(this.Odds, this.Wager); } }

        public Bet()
        {
            // Ensure that odds does not equal 0
        }

        //
        // TODO
        //
        //public override bool Equals(object obj)
        //{
        //    return base.Equals(obj);
        //}
    }
}
