using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Highest ranked player(s) must place 1 weapon in the discard
//If unable to do so, 2 foe cards must be discarded
public class KingsCall : BaseEvent
{

    public override void apply()
    {
        Debug.Log("Sorry King's Call has Not been Implemented yet");
        /*
        List<NetPlayerController> players = GameManager.players;

        //list of the lowest player(s)
        List<NetPlayerController> highest = new List<NetPlayerController>();

        //Automatically set the lowest player to the first player
        NetPlayerController highestPlayer = players[0];

        //Adds the first player in the list automatically
        highest.Add(highestPlayer);

        //find the lowest rank
        for (int cur = 1; cur < players.Count; ++cur)
        {

            //if rank is higher than current highest player clear the list and add the new highest
            if (players[cur].getRank() > highestPlayer.getRank())
            {

                //set the new highest player
                highestPlayer = players[cur];

                //clear the list and re-add the newest highest player
                highest.Clear();
                highest.Add(highestPlayer);

            }
            //if rank is equal to current highest player add the player to highest
            else if (players[cur].getRank() == highestPlayer.getRank())
            {
                highest.Add(highestPlayer);
            }
        }

        //found highest player now need to discard cards from those users

        //highest player has to select one weapon card to discard
        //check to make sure the cards selected is a weapon card
        //valid then remove it from players hand
        //if they have no weapon cards then they have to discard 2 foe cards
        //check to make sure the cards selected is a foe card
        //valid then remove it from players hand

        foreach (NetPlayerController player in highest)
        {
            //player.
        }


        Debug.Log("[KingsCall.cs:play] Kings Call to Arms complete -> 3 shields added to the highest " + highest.Count + " players");
        
        */
    }
}


