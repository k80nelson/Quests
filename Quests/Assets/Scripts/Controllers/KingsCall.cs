using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS EVENT STILL NEEDS A LOT OF WORK BEFORE IT IS DONE

namespace QuestOTRT
{
    //Highest ranked player(s) must place 1 weapon in the discard
    //If unable to do so, 2 foe cards must be discarded
    public class KingsCall : GameElement
    {

        void Start()
        {
            play();
        }

        void play()
        {
            //Loops through each game object and adds them to the list of players
            List<Player> players = new List<Player>();

            //Loops through each game object 
            foreach (GameObject player in this.game.players)
            {
                players.Add(player.GetComponent<PlayerController>().player);
            }

            Player highestPlayer = players[0];

            //find the highest rank
            for (int i = 1; i < players.Count; ++i)
            {
                //if rank is higher than current highest player
                if (players[i].getRank() > highestPlayer.getRank())
                {
                    highestPlayer = players[i];
                }
                else if (players[i].getRank() == highestPlayer.getRank())
                {
                    //if the ranks are the same then you have to find out who has the highest Rank
                    if (players[i].Shields > highestPlayer.Shields)
                    {
                        //replaces the Highest player with the one with Highest rank and shields
                        highestPlayer = players[i];
                    }
                }
                
            }


            Debug.Log("kings call");
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
    }
}