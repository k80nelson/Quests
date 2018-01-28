using System;

namespace QuestOTRT
{

    public abstract class AdventureCard : Card
    {
        private int bp;
        private int bids;

        //basic contstructor
        public AdventureCard(string name, int bp, int bids): base(name)
        {
            this.bp = bp;
            this.bids = bids;
        }
        
        public int BP
        {
            // Adventure card BP getters and setters using C# Properties
            get
            {
                return this.bp;
            }
            set
            {
                this.bp = value;
            }
        }

        public int Bids
        {
            // Adventure card Bids getters and setters using C# Properties
            get 
            {
                return this.bids;
            }
            set
            {
                this.bids = value;
            }
        }
    }
}