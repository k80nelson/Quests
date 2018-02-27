using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestOTRT;

public class DeckController : MonoBehaviour {

    AdventureDeck AdvDeck = new AdventureDeck();
    StoryDeck StrDeck = new StoryDeck();

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

    public StoryCard DrawStoryCard()
    {
        return StrDeck.draw();
    }

    public int numAdvCards()
    {
        return AdvDeck.Count;
    }
    
    public void drawStory()
    {

    }
}
