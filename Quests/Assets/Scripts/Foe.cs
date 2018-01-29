using System;

namespace QuestOTRT
{

    public class Foe : AdventureCard
    {
        private int specialBP;
        private string specialQuest;

        //basic contstructor
        public Foe(string name, int bp, int bids, int specialBP, string specialQuest)
            : base(name, bp, bids)
        {
            this.specialBP = specialBP;
            this.specialQuest = specialQuest;
        }

        public override int getBP(string currQuest)
        {
            return (currQuest == this.specialQuest) ? this.specialBP : this.BP;
        }

    }
}