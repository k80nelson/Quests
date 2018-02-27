using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestOTRT;

public class PlayerController : GameElement {

    public QuestOTRT.Player player;
    //public PlayerView view;

    // When absolutely first loaded
    void Awake()
    {
        player = new QuestOTRT.Player();
    }
    // When first enabled
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void addCards(List<QuestOTRT.AdventureCard> cards)
    {
        player.addCards(cards);
    }

    public void onSponsorQuest()
    {

    }

}
