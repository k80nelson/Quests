using System;

namespace QuestOTRT
{

    public class Foe : AdventureCard
    {
        private int specialBP;
        private string[] specialCards;

        //basic contstructor
        public Foe(string name, int bp, int bids, int specialBP, string[] specialCards)
            : base(name, bp, bids)
        {
            this.specialBP = specialBP;
            this.specialCards[0] = "Defend the Queens Honor";
            foreach (string special in specialCards)
            {
                // add to specialCards[]
            }
            
        }

        public override int getBP(string[] currState)
        {
            // return (this.specialCard in currState) ? this.specialBP : this.bp;
        }

    }
}