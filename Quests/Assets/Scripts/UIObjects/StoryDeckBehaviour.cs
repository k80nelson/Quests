using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QuestOTRT;

public class StoryDeckBehaviour : GameElement {
    public DeckController deck;
    public Button btn;
    

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TaskOnClick()
    {
        //Can only draw a story card if youre in the startTurn state and have an appropriate hand size
        if ((game.state==Game.gameState.startTurn || game.state == Game.gameState.Discard) && game.current.GetComponent<PlayerController>().goodHand())
        {
            deck.DrawStoryCard();
            game.turn.init();
            btn.interactable = false;
        }
    }
}
