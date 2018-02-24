using System;
using System.Collections.Generic;

namespace QuestOTRT
{
    public class Quest : StoryCard
    {
        private int stages;
        public int Stages
        {
            get
            {
                return stages;
            }
        }

      
        public Quest(string name, int stages) : base(name)
        {
            this.stages = stages;
        }

        //Function to handle playing through an actual quest
        /*Input: the array of players joining the quest
         *       the quest they are on
         * 
         * 
         */ 
        public void playQuest(Player[] players, Quest quest)
        {
            

        }

        public bool combat(Foe foe, Player[] players)
        {
            return false;
        }

        //Returns the index of the player that won the test
        //If 4 was returned then something went wrong.
        public int test(Test test, Player[] players)
        {
            return 4;
        }

        public void sponsor(Quest quest, Player p)
        {
            //Number of cards for each stage
            int numStages = quest.Stages;

            //Holds the BP value of the stage and the previous one, used to make sure the next one is always more than the last
            int stageBP = 0;
            int lastStageBP = 0;

            //Booleans used to check conditions of certain cards in play
            bool sponsoring = true;
            bool foePlayed = false;
            bool testPlayed = false;
            bool cardsDone = false;

            //This is only here so the code doesnt give me errors while writing. In reality this will be gotten from a get component from unity.
            AdventureCard card = new Weapon("test", 0, 0); 

            for(int i = 0; i < numStages; i++)
            {
                while (sponsoring)
                {
                    //play a card and get whatever that card is
                    //card = GetComponent();
                    if (card is QuestOTRT.Foe && !foePlayed)
                    {
                        stageBP += card.getBP(new string[] { quest.Name });
                        foePlayed = true;

                        if (stageBP > lastStageBP)
                        {
                            //display some sort of button prompt to ask if theyre done playing cards and get return value set it to cards done
                            if (cardsDone) sponsoring = false;
                        }

                    }

                    if (card is QuestOTRT.Weapon && foePlayed)
                    {
                        stageBP += card.getBP(new string[] { card.Name });

                        if (stageBP > lastStageBP)
                        {
                            //display some sort of button prompt to ask if theyre done playing cards and get return value set it to cards done
                            if (cardsDone) sponsoring = false;
                        }
                    }

                    if (card is QuestOTRT.Test && !testPlayed && !foePlayed)
                    {
                        testPlayed = true;
                        sponsoring = false;
                    }

                }

                lastStageBP = stageBP;
                stageBP = 0;
                foePlayed = false;
                sponsoring = true;

            }

        }

    }

}