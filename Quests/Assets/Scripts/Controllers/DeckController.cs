using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestOTRT;

public class DeckController : GameElement {

    AdventureDeck AdvDeck = new AdventureDeck();
    StoryDeck StrDeck = new StoryDeck();
    public CardFactory factory;
    public GameObject parent;

    void Awake()
    { 
        AdvDeck = new AdventureDeck();
        StrDeck = new StoryDeck();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public List<AdventureCard> DrawAdventureCards(int num)
    {
        return AdvDeck.draw(num);
    }

    public StoryCard getStoryCard()
    {
        return StrDeck.draw();
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
        card.transform.position = new Vector3(720, 524, 0);

        if (c is QuestOTRT.Quest) game.state = Game.gameState.Sponsorship;
        else if (c is QuestOTRT.Event) game.state = Game.gameState.Event;
        else game.state = Game.gameState.Tournament;
    }
    
    public int numAdvCards()
    {
        return AdvDeck.Count;
    }
    
}
