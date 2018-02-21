using System;

namespace QuestOTRT
{
    public class Tournament : StoryCard
    {
        private int shields;
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
         * input: reference to the players joining the tourney
         * returns: nothing
         *  
         */
        public void playTournement(Player[] players)
        {
           
            //Gets the number of players involved in the tournement
            numPlayers = players.Length;

            return;
        }
    }
}

/* Timeline of a Tournement
 * 
 * card is drawn
 * 
 * players decide who wants to be part of the tournement
 *      starting with person drawing card, then following turn order
 *   
 *   If only one person enters they win 1 shield + bonus
 *   
 * each player entering draws one adventure card
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
