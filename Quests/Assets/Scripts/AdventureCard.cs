using System;

namespace QuestOTRT
{

    public abstract class AdventureCard : Card
    {
        //basic contstructor
        public AdventureCard(string name, int bp, int bids): base(name)
        {
            this.bp = bp;
            this.bids = bids;
        }

        //set the bp for an adventure card
        public setBP(int bp)
        {
            this.bp = bp;
        }

        //get the bp for an adventure card
        public int getBP()
        {
            return bp;
        }

        //set the bids for an adventure card
        public setBids(int bids)
        {
            this.bids = bids;
        }

        //get the bids for an adventure card
        public int getBids()
        {
            return bids;
        }

    }
}