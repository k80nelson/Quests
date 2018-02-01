using System;

namespace QuestOTRT
{

    public abstract class AdventureCard : Card
    {
        protected int bp;
        protected int bids;
        
        public AdventureCard(string name, int bp, int bids): base(name)
        {
            this.bp = bp;
            this.bids = bids;
        }
        
        public virtual int getBP(string[] currState)
        {
            /* This function is meant to be overridden in Foe, Test, and Ally classes */
            return this.bp;
        }

        public virtual int getBids(string[] currState)
        {
            /* This function is meant to be overridden in Foe, Test, and Ally classes */
            return this.bids;
        }

    }
}