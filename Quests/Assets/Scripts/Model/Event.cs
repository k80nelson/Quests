 using System;
using System.Collections.Generic;

namespace QuestOTRT
{
    public class Event : StoryCard
    {      

        //Constructor
        public Event(string name) : base(name){}


        public void plague(Player p)
        {
        }

            
        public void pox(Player p, Player[] players)
        {
           

        }

        //All players can immediately draw 2 Adventure Cards
        public void prosperityTtR(Player[] players, DeckController d)
        {
            //Loop through all players to add cards to their hands
           for(int i = 0; i<players.Length; i++)
            {
                //add a card and add 1 to the amount of players who have drawn 2 cards
                players[i].addCards(d.DrawAdventureCards(2));
            }
        }

        public void queensFavor(Player[] players, DeckController d)
        {
            //Lowest ranked player(s) immediately recieve 2 Adventure Cards
            int curLowestRank = (int)Rank.Squire; //keeps track of curent lowest rank
            int size = 0; //this is used to determine who is the lowest rank

            //loop through the passed in Player[] players
            int i = 0;
            while(i<players.Length){ 

                //checks if the current players rank is <= to current lowest rank being checked
                if ((int)players[i].getRank() <= curLowestRank){
                    //add a card and add 1 to the amount of players who have drawn 2 cards
                    players[i].addCards(d.DrawAdventureCards(2));
                    size++;
                }

                //if no players have this current lowest rank, and no players have been given cards, try next highest rank
                if (i == 3 && size == 0){
                    curLowestRank++;
                    i = 0;
                }
                i++;
            }
            
        }
    }
}

