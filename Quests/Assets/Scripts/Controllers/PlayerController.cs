using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestOTRT;

public class PlayerController : GameElement {

    public QuestOTRT.Player player;
    public PlayerView view;

    // When absolutely first loaded
    void Awake()
    {
        
    }
    // When first enabled
    void Start ()
    {
        player = new QuestOTRT.Player();
        view = GetComponent<PlayerView>();
    }
	
	// Update is called once per frame
	void Update () {
        player.displayHand();
	}

    public void addCards(List<QuestOTRT.AdventureCard> cards)
    {
        player.addCards(cards);
        foreach (AdventureCard card in cards)
        {
            view.createCard(card.Name);
        }
    }
    public void onSponsorQuest()
    {

    }

}
