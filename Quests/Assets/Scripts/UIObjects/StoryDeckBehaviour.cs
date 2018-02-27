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
        btn.onClick.AddListener(TaskOnClick);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TaskOnClick()
    {
        StoryCard card = deck.DrawStoryCard();
        Debug.Log(card.Name);
    }
}
