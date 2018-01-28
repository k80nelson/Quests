using System;

namespace QuestOTRT
{
    //basic contstructor
    public class Ally : AdventureCard
    {
        private int specialBP;
        private int specialBids;

        public Ally(string name, int bp, int bids, int specialBP, int specialBids)
            : base(name, bp, bids)
        {
            this.specialBP = specialBP;
            this.specialBids = specialBids;
        }

    }
}