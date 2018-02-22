using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestOTRT;

public class DeckController : MonoBehaviour {

    public AdventureDeck AdvDeck;
    public StoryDeck StrDeck;

    public DeckController()
    {
        AdvDeck = new AdventureDeck();
        StrDeck = new StoryDeck();
    }
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

    public int numAdvCards()
    {
        return AdvDeck.Count;
    }
    
}
