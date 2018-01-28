using System;

namespace QuestOTRT
{

    public class Foe : AdventureCard
    {

        //basic contstructor
        public Foe(string name, int bp): base(name, bp, bids=0)
        {
           
        }

        public void questCheck()
        {
            //check to see what quest is currently playing
            //if the proper quest is playing for this foe then change bp
        }
    }
}