using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestOTRT;
using UnityEngine.UI;

public class PlayerController : GameElement {

    public QuestOTRT.Player player;
    public PlayerView view;
    public Text rankText;
    public Text shieldText;
    public Text cardText;

    // When absolutely first loaded
    void Awake()
    {
        player = new QuestOTRT.Player();
    }
    // When first enabled
    void Start ()
    {
    }

    public Rank getRank()
    {
        return player.getRank();
    }

    public void addShields(int num)
    {
        player.addShields(num);
    }
	
	// Update is called once per frame
	void Update ()
    {
        rankText.text = "Rank: " + ((QuestOTRT.Rank)this.player.getRank()).ToString();
        shieldText.text = "Shields: " + this.player.Shields.ToString();
        cardText.text = "Cards: " + this.player.hand.Cards.Count.ToString();

    }

    public void removeCard(AdventureCard card)
    {
        player.removeCard(card);
        view.removeCard(card);
        view.adjustHand();
    }

    public void addCards(List<QuestOTRT.AdventureCard> cards)
    {
        foreach (AdventureCard card in cards)
        {
            view.createCard(card);
        }
        player.addCards(cards);
        view.adjustHand();
    }

    public void onSponsorQuest()
    {

    }

    public void initCards()
    {
        foreach (AdventureCard card in player.hand.Cards)
        {
            view.createCard(card);
        }
        view.adjustHand();
    }
    public void upgradeRank()
    {
        player.rankUp();
    }

}
