using System;

namespace QuestOTRT
{
    //basic contstructor
    public class Ally : AdventureCard
    {
        private int specialBP;
        private int specialBids;
        private string specialCards;

        public Ally(string name, int bp, int bids, int specialBP, int specialBids, string specialCard)
            : base(name, bp, bids)
        {
            this.specialBP = specialBP;
            this.specialBids = specialBids;
        }

        public override int getBP(string[] currState)
        {
            //return (this.specialCard in currState) ? this.specialBP : this.bp;
        }

        public override int getBids(string[] currState)
        {
            //return (currQuest == this.specialQuest) ? this.specialBids : this.bids;
        }

    }
}