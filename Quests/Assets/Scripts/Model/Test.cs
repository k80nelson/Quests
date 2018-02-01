using System;
using System.Linq;

namespace QuestOTRT
{ 
    public class Test : AdventureCard
    {
        private int specialBids;
        private string specialQuest;

        public Test(string name, int bp, int bids, int specialBids, string specialQuest)
            : base(name, bp, bids)
        {
            this.specialBids = specialBids;
            this.specialQuest = specialQuest;
        }

        public override int getBids(string[] currState)
        {
            return (currState.Contains(this.specialQuest)) ? this.specialBids : this.bids;
        }

    }
}