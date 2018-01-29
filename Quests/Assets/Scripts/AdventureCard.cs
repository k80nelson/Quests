using System;

namespace QuestOTRT
{

    public abstract class AdventureCard : Card
    {
        protected int bp;
        protected int bids;

        //basic contstructor
        public AdventureCard(string name, int bp, int bids): base(name)
        {
            this.bp = bp;
            this.bids = bids;
        }
        
        public virtual int getBP(string currQuest)
        {
            return this.bp;
        }

        public virtual int getBids(string currQuest)
        {
            return this.bids;
        }

    }
}