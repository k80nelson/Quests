 using System;

namespace QuestOTRT
{
    public class Event : StoryCard
    {      

        //Constructor
        public Event(string name) : base(name){}

        /* Need to rework this--breaks both polymorphism and MVC design patterns 
        //A switch statement which calls the card that was drawn, THESE NAMES NEED TO BE EXACTLY WHAT THE CARDS ARE CALLED
        public void play(string name)
        {
            switch (name)
            {
                case "Chivalrous Deed":
                    chivalrousDeed();
                    break;

                case "Court Called to Camelot":
                    courtCalled();
                    break;

                case "King's Call to Arms":
                    kingCall();
                    break;

                case "King's Recognition":
                    kingRecognition();
                    break;

                case "Plague":
                    plague();
                    break;

                case "Pox":
                    pox();
                    break;

                case "Prosperity Throughout the Realm":
                    prosperityTtR();
                    break;

                case "Queen's Favor":
                    queensFavor();
                    break;

                default:
                    break;
            }
        }
        */
        //Functions for all the functionality of our events
        public void chivalrousDeed(Player[] players)
        { 
            //obj: Player(s) with lowest rank and least amount of shields gains 3 shields
            int cur = 1;
            Player lowestPlayer = players[cur - 1];

            //find the lowest rank
            for(int i = 0; i < players.Length; ++i){
                if(players[cur].getRank() < lowestPlayer.getRank()){
                    lowestPlayer = players[cur];
                }else if (players[cur].getRank() == lowestPlayer.getRank()){
                    //found the lowest rank now find out how many player have that Rank
                    if(players[cur].Shields < lowestPlayer.Shields){
                        //replaces the lowest player with the one with lowest rank and shields
                        lowestPlayer = players[cur];
                    }
                }
            }

            //adds 3 shields to the lowest player
            lowestPlayer.addShields(3);
        }
        
        public void courtCalled(Player[] players)
        {
            //All Allies in play are discarded
            for(int i = 0; i < players.Length; ++i){
        
            }
            
        }
        /*
        public void kingCall()
        {
            //Highest ranked player(s) must place 1 weapon in the discard
                //If unable to do so, 2 foe cards must be discarded
        }

        public void kingRecognition()
        {
            //Next player(s) to complete a Quest reicieve 2 extra shields
        }
        */
        public void plague(Player p)
        {
            //Drawer loses 2 shields, if possible
            p.removeShields(2);

        }

            /*
        public void pox()
        {
            //All other players lose one shield(if possible), drawer of this card is exempt
        }*/

        public void prosperityTtR(Player[] players, DeckController d)
        {
            //All players can immediately draw 2 Adventure Cards
            int i = 0;
            while (i < players.Length)
            {
                //add a card and add 1 to the amount of players who have drawn 2 cards
                players[i].addCards(d.DrawAdventureCards(2));
                i++;
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

