using SportsBetter.Library.Bet;
using System.Collections.Generic;
using System.Diagnostics;

namespace SportsBetter.App
{
    internal class CSVBetParser
    {
        public class TreeNode
        {
            TreeNode Parent { get; set; }
            List<TreeNode> Children { get; set; }
            public TreeNode()
            {
                this.Children = new List<TreeNode>();
            }
        }

        public static List<StraightBet> Parse(string fileName)
        {
            Debug.Assert(string.IsNullOrEmpty(fileName) == false);
            Debug.Assert(fileName.EndsWith(".csv"));

            throw new KeyNotFoundException();
        }
    }
}
