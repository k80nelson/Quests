using System;

namespace QuestOTRT
{
    //basic contstructor
    public class Ally : AdventureCard
    {
        private int specialBP;
        private int specialBids;
        private string specialQuest;

        public Ally(string name, int bp, int bids, int specialBP, int specialBids, string specialQuest)
            : base(name, bp, bids)
        {
            this.specialBP = specialBP;
            this.specialBids = specialBids;
            this.specialQuest = specialQuest;
        }

        public override int getBP(string currQuest)
        {
            return (currQuest == this.specialQuest) ? this.specialBP : this.bp;
        }

        public override int getBids(string currQuest)
        {
            return (currQuest == this.specialQuest) ? this.specialBids : this.bids;
        }

    }
}