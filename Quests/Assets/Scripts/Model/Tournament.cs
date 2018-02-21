using System;
using System.Collections.Generic;

namespace QuestOTRT
{
    public class Tournament : StoryCard
    {
        private int shields;
        private List<AdventureCard> hand;
        private List<AdventureCard> cardDrawn;
        private bool inProgress = true;


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
           
            //Gets the number of players involved in the tournement
            numPlayers = players.Length;

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
 * players decide what cards they want to play from their hand (if they want to play any cards)
 * 
 * All cards are shown at the same time
 * 
 * Person with hiest BP wins
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
