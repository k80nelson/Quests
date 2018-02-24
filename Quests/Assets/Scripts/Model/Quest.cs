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
            bool onGoing = true;

            //Number of cards for each stage
            int numStages = quest.Stages;
            int numPlayers = players.Length;

            //This is just here to prevent an error further down, similar to sponsor
            AdventureCard card = new Test("test", 0, 0, 0, "test");


            while (onGoing)
            {
                for(int i = 0; i < numStages; i++)
                {

                    //Gets the specific stage that is currently being played
                    switch (i)
                    {
                        case 0:
                            //Get component from unity, stage 1 will always be in one specific location on the screen
                            //card = getCOmponent

                            //THink about making a helper function for this part since it is repeated code throughout
                            if (card is QuestOTRT.Foe)
                            {
                                //loop through players and call combat function
                            }
                            else if (card is QuestOTRT.Test)
                            {
                                //loop through players and call testRunner function
                            }
                            break;

                        case 1:
                            //Get component from unity, stage 2 will always be in one specific location on the screen
                            //card = getCOmponent
                            if (card is QuestOTRT.Foe)
                            {
                                //loop through players and call combat function
                            }
                            else if (card is QuestOTRT.Test)
                            {
                                //loop through players and call testRunner function
                            }
                            break;

                        case 2:
                            //Get component from unity, stage 3 will always be in one specific location on the screen
                            //card = getCOmponent
                            if (card is QuestOTRT.Foe)
                            {
                                //loop through players and call combat function
                            }
                            else if (card is QuestOTRT.Test)
                            {
                                //loop through players and call testRunner function
                            }
                            break;

                        case 3:
                            //Get component from unity, stage 4 will always be in one specific location on the screen
                            //card = getCOmponent
                            if (card is QuestOTRT.Foe)
                            {
                                //loop through players and call combat function
                            }
                            else if (card is QuestOTRT.Test)
                            {
                                //loop through players and call testRunner function
                            }
                            break;

                        case 4:
                            //Get component from unity, stage 5 will always be in one specific location on the screen
                            //card = getCOmponent
                            if (card is QuestOTRT.Foe)
                            {
                                //loop through players and call combat function
                            }
                            else if (card is QuestOTRT.Test)
                            {
                                //loop through players and call testRunner function
                            }
                            break;
                    }
                }
            }

        }

        //Returns boolean if the player passed or failed the combat
        public bool combat(Foe foe, Player[] players, int stageBP)
        {
            return false;
        }

        //Returns the index of the player that won the test, players are ordered in the order that their turns should be
        //If 4 was returned then something went wrong.
        public int testRunner(Test test, Player[] players)
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

            //Loop through the number of stages to play cards for each stage
            for(int i = 0; i < numStages; i++)
            {
                //Will continue to loop, letting the player play as many cards as they want
                while (sponsoring)
                {
                    //play a card and get whatever that card is, display it to the screen in a specific location that can be accessed later using getComponent
                    //card = GetComponent();

                    //This long if statement Checks the type of card played
                    if (card is QuestOTRT.Foe && !foePlayed)
                    {

                        //Increment the bp of the stage and change a boolean
                        stageBP += card.getBP(new string[] { quest.Name });
                        foePlayed = true;

                        //Checker to prompt if they want to play more cards
                        if (stageBP > lastStageBP)
                        {
                            //display some sort of button prompt to ask if theyre done playing cards and get return value set it to cards done
                            if (cardsDone) sponsoring = false;
                        }

                    }

                    else if (card is QuestOTRT.Weapon && foePlayed)
                    {
                        stageBP += card.getBP(new string[] { card.Name });

                        if (stageBP > lastStageBP)
                        {
                            //display some sort of button prompt to ask if theyre done playing cards and get return value set it to cards done
                            if (cardsDone) sponsoring = false;
                        }
                    }

                    else if (card is QuestOTRT.Test && !testPlayed && !foePlayed)
                    {
                        testPlayed = true;
                        sponsoring = false;
                    }

                    else
                    {
                        //Display to the screen, that card is not a valid option to sponsor a quest
                        //Remove the card and put it back in the players hand
                    }

                }

                //Reset variables to allow for the next iteration of the loop to work
                lastStageBP = stageBP;
                stageBP = 0;
                foePlayed = false;
                sponsoring = true;

            }

        }

    }

}