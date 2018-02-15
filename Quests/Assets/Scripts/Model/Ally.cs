using System;
using System.Linq;
using System.Collections.Generic;

namespace QuestOTRT
{
    //basic contstructor
    public class Ally : AdventureCard
    {
        private int specialBP;
        private int specialBids;
        private string specialCard;

        public Ally(string name, int bp, int bids, int specialBP, int specialBids, string specialCard)
            : base(name, bp, bids)
        {
            this.specialBP = specialBP;
            this.specialBids = specialBids;
            this.specialCard = specialCard;
        }

        public override int getBP(string[] currState)
        {
            return (currState.Contains(specialCard)) ? this.specialBP : this.bp;
        }

        public override int getBids(string[] currState)
        {
            return (currState.Contains(specialCard)) ? this.specialBids : this.bids;
        }

    }
}