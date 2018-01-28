using System;

namespace QuestOTRT
{

    public abstract class AdventureCard : Card
    {
        protected int bp;
        protected int bids;
        public int BP
        {
            get
            {
                return bp;
            }
        }
        public int Bids
        {
            get
            {
                return bids;
            }
        }

        protected AdventureCard(string name, int bp, int bids)
            : base(name)
        {
            this.bp = bp;
            this.bids = bids;
        }

        virtual public int getBP(Quest currQuest)
        {
            return bp;
        }

        virtual public int getBids(Quest currQuest)
        {
            return bids;
        }

    }
}