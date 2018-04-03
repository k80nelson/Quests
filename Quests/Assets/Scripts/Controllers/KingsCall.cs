using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Highest ranked player(s) must place 1 weapon in the discard
//If unable to do so, 2 foe cards must be discarded
public class KingsCall : GameElement
{

    void Start()
    {
        play();
    }

    public void play()
    {
        //Loops through each game object and adds them to the list of players
        List<PlayerModel> players = new List<PlayerModel>();
        List<PlayerController> playersCtr = new List<PlayerController>();
        bool hasWeapon = false;
        bool hasFoe = false;
        int weaponCounter = 0;
        int foeCounter = 0;

        //Loops through each game object and creates the list of models and controllers 
        foreach (GameObject player in game.players)
        {
            players.Add(player.GetComponent<PlayerModel>());
            playersCtr.Add(player.GetComponent<PlayerController>());
        }

        //Sets the inital highestPlayer
        List<PlayerModel> highestPlayerModel = new List<PlayerModel>();
        List<PlayerController> highestPlayerController = new List<PlayerController>();
        highestPlayerModel.Add(players[0]);
        highestPlayerController.Add(playersCtr[0]);


        //find the highest rank
        for (int i = 1; i < players.Count; ++i)
        {
            //if rank is higher than current highest player clear the list and add the new highest
            if (players[i].getRank() > highestPlayerModel[0].getRank())
            {
                highestPlayerModel.Clear();
                highestPlayerController.Clear();

                highestPlayerModel.Add(players[i]);
                highestPlayerController.Add(playersCtr[i]);

                Debug.Log("Inside rank check, current highestPlayer is " + (i + 1));

            }

            //If rank is equal then add them to the list
            else if (players[i].getRank() == highestPlayerModel[0].getRank())
            {
                highestPlayerModel.Add(players[i]);
                highestPlayerController.Add(playersCtr[i]);
            }

        }



        //highest player has to select one weapon card to discard
        //check to make sure the cards selected is a weapon card
        //valid then remove it from players hand
        //if they have no weapon cards then they have to discard 2 foe cards
        //check to make sure the cards selected is a foe card
        //valid then remove it from players hand
        


        foreach(AdventureCard card in cards)
        {
            if(card.type == AdventureCard.Type.WEAPON)
            {
                hasWeapon = true;
                weaponCounter += 1;
            }
            if (card.type == AdventureCard.Type.FOE)
            {
                hasFoe = true;
                foeCounter += 1;
            }
        }

        if (hasWeapon) game.view.promptUser("You must discard a Weapon card to continue");
        else if (!hasWeapon && hasFoe && foeCounter >= 2) game.view.promptUser("You must discard two Foe cards to continue");
        else if (!hasWeapon && hasFoe && foeCounter < 2) game.view.promptUser("You must discard a Foe card to continue");


        Debug.Log("Kings Call");
    }
}