using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HelperFunctions : NetworkBehaviour {

    //public PlayerView view;

    public PlayerController player = GameObject.FindObjectOfType<PlayerController>();
    // ONLY CHANGE MODEL ON THE SERVER !!!!!
    //public PlayerModel model;

    private void Awake()
    {
       //view = GetComponent<PlayerView>();
        //model = GetComponent<PlayerModel>();
    }
    public void startTurn()
    {
        if (!isLocalPlayer) return;
        Cmd_StartTurn();
    }


    [Command]
    public void Cmd_StartTurn()
    {
        //check players hand to make sure the have 12 or less cards
        int numCards = player.model.hand.Count;
        //if more than 12 
        //print error message
        //if 12 or less
        //draw the story card from story deck
        //place the story card on the screen
        //active/play the story card that was drawn

        //change the text of the button to end turn

    }

    [ClientRpc]
    public void Rpc_StartTurn()
    {
        //check players hand to make sure the have 12 or less cards
        
        //if more than 12 
        //print error message
        //if 12 or less
        //draw the story card from story deck
        //place the story card on the screen
        //active/play the story card that was drawn

        //change the text of the button to end turn

    }
    public void endTurn()
    {
        //remove story card from screen
        //discard story card

        //pass player turn to next player
        //notify other players that the player is done
        //notify the new player that its their turn
        
    }

}
