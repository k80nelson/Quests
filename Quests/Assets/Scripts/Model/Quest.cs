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
         *THIS NEEDS A LOT OF WORK 
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
                    for (int j = 0; j < numPlayers; j++) {
                        //Gets the specific stage that is currently being played
                        switch (i)
                        {
                            case 0:
                                //Get component from unity, stage 1 will always be in one specific location on the screen
                                //card = getCOmponent

                                stageAction(players[j], card);
                                break;

                            case 1:
                                //Get component from unity, stage 2 will always be in one specific location on the screen
                                //card = getCOmponent

                                stageAction(players[j], card);
                                break;

                            case 2:
                                //Get component from unity, stage 3 will always be in one specific location on the screen
                                //card = getCOmponent

                                stageAction(players[j], card);
                                break;

                            case 3:
                                //Get component from unity, stage 4 will always be in one specific location on the screen
                                //card = getCOmponent

                                stageAction(players[j], card);
                                break;

                            case 4:
                                //Get component from unity, stage 5 will always be in one specific location on the screen
                                //card = getCOmponent

                                stageAction(players[j], card);
                                break;
                        }
                    }
                }
            }

        }

        //Returns boolean if the player passed or failed the combat
        public bool combat(List<AdventureCard> foe, Player p, int stageBP)
        {
            bool onGoing = true;

            bool amourInPlay;

            bool excaliburInPlay = false;
            bool horseInPlay = false;
            bool lanceInPlay = false;
            bool swordInPlay = false;
            bool axInPlay = false;
            bool daggerInPlay = false;

            bool playCards;

            int playerBP = p.BP;
            int foeBP = 0;

            //Figure out how to tell if they have an amour card in play
            //set the amourInPlay bool to true or false depending on the check

            int numCards = foe.Count;

            for (int i = 0; i < numCards; i++)
            {
                foeBP = foeBP + foe[i].getBP(new string[] { foe[i].Name });
            }

            while (onGoing)
            {
                if (playerBP > stageBP)
                {
                    //display "you've beaten the stage"
                    return true;
                }

                //Ask if they want to play cards, save to play cards

                if (playCards)
                {
                    AdventureCard cardPlayed; // = play a card

                    //have to add a way to change the boolean if they played a weapon they dont have in play yet

                    if (cardPlayed is Foe)
                    {
                        //put the card back in their hand
                        //display prompt to say they cant do that
                        continue;
                    }
                    else if (cardPlayed is Weapon && axInPlay)
                    {
                        //put the card back in their hand
                        //display prompt to say they already have that card in play
                        continue;
                    }
                    else if (cardPlayed is Weapon && daggerInPlay)
                    {
                        //put the card back in their hand
                        //display prompt to say they already have that card in play
                        continue;
                    }
                    else if (cardPlayed is Weapon && swordInPlay)
                    {
                        //put the card back in their hand
                        //display prompt to say they already have that card in play
                        continue;
                    }
                    else if (cardPlayed is Weapon && horseInPlay)
                    {
                        //put the card back in their hand
                        //display prompt to say they already have that card in play
                        continue;
                    }
                    else if (cardPlayed is Weapon && lanceInPlay)
                    {
                        //put the card back in their hand
                        //display prompt to say they already have that card in play
                        continue;
                    }
                    else if (cardPlayed is Weapon && excaliburInPlay)
                    {
                        //put the card back in their hand
                        //display prompt to say they already have that card in play
                        continue;
                    }

                    playerBP += cardPlayed.getBP(new string[] { cardPlayed.Name });
                }
                else break;
            }

            //Display youve failed the stage and have been removed from the quest
            return false;
        }

        public void stageAction(Player p, AdventureCard card)
        {
            if (card is QuestOTRT.Foe)
            {
                //loop through players and call combat function
                //Get the list of cards nexrt to that foe and pass a list
                //Like if there are weapons placed next to the foe, they will be part of the list
            }
            else if (card is QuestOTRT.Test)
            {
                //loop through players and call testRunner function
            }
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