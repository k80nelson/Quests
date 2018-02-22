using System;
using System.Collections;
using System.Collections.Generic;

namespace QuestOTRT
{
    public class Tournament : StoryCard
    {
        private int shields;
        private List<AdventureCard> hand;
        private List<AdventureCard> cardDrawn;
        private bool inProgress = true;
        private int bpChange;

        //Variables used to check who is currently winning tournement, array will hold the index of the winning player
        private int currentBP = 0;
        private int highestBP = 0;
        

        public int numPlayers;
        


        public int Shields
        {
            get
            {
                return shields;
            }
        }

        public Tournament(string name, int shields)
            : base(name)
        {
            this.shields = shields;
        }


        //Game logic for tournements
        /*
         * 
         * input: array of players (only players joining the tournement will be passed, this will be deternimed in game)
         *              array needs to be in this order: 
         *                      1st person to say they joined: 0
         *                      next: 1
         *                      etc.
         *        int bonus, the number of shieds that are offered as a bonus
         * 
         * returns: nothing
         *  
         */
        public void playTournement(Player[] players, int bonus, DeckController AD_Deck)
        {
            //resets the variables used to check winner
            currentBP = 0;
            highestBP = 0;

            //Gets the number of players involved in the tournement
            numPlayers = players.Length;

            ArrayList winner = new ArrayList();

            //If only one person enters they win 1 shield + bonus
            if (numPlayers == 1)
            {
                players[0].addShields(numPlayers + bonus);
                return;
            }

            //Loop through each player for them to draw a card.
            //each player entering draws one adventure card
            for (int i = 0; i< numPlayers; i++)
            {
                hand = players[i].getCards();
                cardDrawn = AD_Deck.DrawAdventureCards(1); //Need to talk to Katie, how does this work
                players[i].addCard(cardDrawn[0]);
            }

            while (inProgress)
            {
                //players decide what cards they want to play from their hand (if they want to play any cards)
                //All cards are shown at the same time

                //Adjust BP for each player
                for(int i = 0; i < numPlayers; i++)
                {
                    //bpChange = bp of cards played by player[i] + players[i].BP;
                    //players[i].setBP(bpChange);

                    //First person automatically is set to the winner
                    if (i == 0)
                    {
                        currentBP = players[i].BP;
                        highestBP = players[i].BP;
                        winner.Add(i);
                    }

                    //Compares other players to the current winner
                    else
                    {
                        currentBP = players[i].BP;

                        //if current player is greater clear the winners list and make them the current winner
                        if (currentBP > highestBP)
                        {
                            highestBP = currentBP;
                            winner.Clear();
                            winner.Add(i);
                        }

                        //if its a tie, add that player to the winners list
                        else if (currentBP == highestBP)
                        {
                            winner.Add(i);
                        }

                        //player is less than current winner, so continue.
                        else
                        {
                            continue;
                        }
                    }
                }

                
                //If there is no tie
                if(winner.Count == 1)
                {
                    //discard all weapons and amour cards played
                    int index = (int)winner[0];
                    players[index].addShields(numPlayers + bonus);
                    return;
                }

                //numPlayers = winner.Count; need to make another variable for this, changing num players isnt good 
                //discard all weapons and amour cards played


            }




            //Default in case something went wrong
            return;
        }
    }
}

/* Timeline of a Tournement
 * 
 * //happens outside of tournement class
 * tournement card is drawn
 * starting with person drawing card, then following turn order
 *
 * 
 *      If there is a tie:
 *         Weapons are discarded
 *         Repeat tournement play with those who tied, play more cards and reveal
 *         if theres another tie they both win
 *         
 * winner recieves:
 *      the number of shields equal to the number of players in the tournement
 *      the number of bonus shields on the card listed as bonus 
 */
