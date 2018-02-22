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
                //if rank is lower than the current lowest player
                if(players[cur].getRank() < lowestPlayer.getRank()){
                    lowestPlayer = players[cur];
                }else if (players[cur].getRank() == lowestPlayer.getRank()){
                    //if the ranks are the same then you have to find out who has the lowest Rank
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
            //loops through all allies and find their allies
            for(int i = 0; i < players.Length; ++i){
                players[i].removeAllies();
            }
            
        }
       
        public void kingCall()
        {
            //Highest ranked player(s) must place 1 weapon in the discard
                //If unable to do so, 2 foe cards must be discarded
    
            Player highestPlayer = players[0];

            //find the highest rank
            for(int i = 1; i < players.Length; ++i){
                //if rank is higher than current highest player
                if(players[i].getRank() > highestPlayer.getRank()){
                    highestPlayer = players[i];
                }else if (players[i].getRank() == highestPlayer.getRank()){
                    //if the ranks are the same then you have to find out who has the highest Rank
                    if(players[i].Shields > highestPlayer.Shields){
                        //replaces the Highest player with the one with Highest rank and shields
                        highestPlayer = players[i];
                    }
                }
            }

            //highest player must remove highest card.
                //highest player has to select one weapon card to discard
                    //check to make sure the cards selected is a weapon card
                        //valid then remove it from players hand
                //if they have no weapon cards then they have to discard 2 foe cards
                   //check to make sure the cards selected is a foe card
                        //valid then remove it from players hand
/*
            for(int i = 0; i < HighestPlayer.Cards.Count; ++i){
                AdventureCard card = highestPlayer.Cards[i];

                //supposed to check if the card is a weapon
                if (card is Weapon){
                   highestPlayer.Cards.Remove(card);
                }else if (card is Foe){

                }
            }
            */
        }

         /*
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

            
        public void pox(Player p, Player[] players)
        {
            //All other players lose one shield(if possible), drawer of this card is exempt
            for(int i = 0; i < players.Length; ++i){
                //if the player is the one who drew the card then he doesnt lose a sheild
                if(players[i] == p){
                    continue;
                }
                //all other players lose one shield
                else{
                    players[i].removeShields(1);
                }
            }

        }

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

