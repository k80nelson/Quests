using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestOTRT;

public class DeckController : GameElement {

    AdventureDeck AdvDeck = new AdventureDeck();
    StoryDeck StrDeck = new StoryDeck();
    public CardFactory factory;
    public GameObject parent;
    public List<AdventureCard> discardDeck;

    void Awake()
    { 
        AdvDeck = new AdventureDeck();
        StrDeck = new StoryDeck();
        discardDeck = new List<AdventureCard>();
    }

    public void discard(AdventureCard card)
    {
        discardDeck.Add(card);
        AdvDeck.discard = discardDeck;
    }

    public void discard(List<AdventureCard> cards)
    {
        discardDeck.AddRange(cards);
        AdvDeck.discard = discardDeck;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public int getBP(string name, string[] cards)
    {
        return AdvDeck.getBP(name, cards);
    }

    public List<AdventureCard> DrawAdventureCards(int num)
    {
        return AdvDeck.draw(num);
    }

    public StoryCard getStoryCard()
    {
        return StrDeck.draw();
    }

    public StoryCard getStoryCard(string name)
    {
        return StrDeck.draw(name);
    }

    public void DrawStoryCard()
    {
        foreach(Transform child in parent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        StoryCard c = getStoryCard();
        GameObject card = factory.create(c);
        card.tag = "CurrStory";
        card.transform.SetParent(parent.transform);
        card.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        card.transform.localPosition = new Vector3(0, 0, 0);

        if (c is QuestOTRT.Quest) game.state = Game.gameState.Sponsorship;
        else if (c is QuestOTRT.Event) game.state = Game.gameState.Event;
        else game.state = Game.gameState.TourDecision;
    }

    public void DrawStoryCard(string name)
    {
        foreach (Transform child in parent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        StoryCard c = getStoryCard(name);
        GameObject card = factory.create(c);
        card.tag = "CurrStory";
        card.transform.SetParent(parent.transform);
        card.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        card.transform.localPosition = new Vector3(0, 0, 0);

        if (c is QuestOTRT.Quest) game.state = Game.gameState.Sponsorship;
        else if (c is QuestOTRT.Event) game.state = Game.gameState.Event;
        else game.state = Game.gameState.TourDecision;
    }

    public int numAdvCards()
    {
        return AdvDeck.Count;
    }
    
}
