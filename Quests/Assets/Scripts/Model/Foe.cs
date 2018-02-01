using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestOTRT
{

    public class Foe : AdventureCard
    {
        private int specialBP;
        private List<string> specialCards;

        //basic contstructor
        public Foe(string name, int bp, int bids, int specialBP, string[] specialCards)
            : base(name, bp, bids)
        {
            this.specialBP = specialBP;
            this.specialCards = new List<string>();
            this.specialCards.Add("Defend the Queen's Honor");
            foreach (string special in specialCards)
            {
                this.specialCards.Add(special);
            }
            
        }

        public override int getBP(string[] currState)
        {
            foreach (string card in this.specialCards)
            {
                if (currState.Contains(card)) return this.specialBP;
            }
            return this.bp;
        }

    }
}