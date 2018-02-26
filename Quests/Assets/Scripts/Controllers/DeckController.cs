using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestOTRT;

public class DeckController : MonoBehaviour {

    AdventureDeck AdvDeck; 
    StoryDeck StrDeck; 

    void Awake()
    {
        //must create the decks in the start to avoid unity errors
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
