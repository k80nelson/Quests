using System;

namespace QuestOTRT
{

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

        public override int getBP(Quest currQuest)
        {
            return (currQuest.Name == specialQuest) ? specialBP : bp;
        }

        public override int getBids(Quest currQuest)
        {
            return (currQuest.Name == specialQuest) ? specialBids : bids;
        }
    }
}