using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestOTRT;

public class DeckController : MonoBehaviour {

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

    public Game.gameState DrawStoryCard()
    {
        // if (story card already in play)
        if (false)
        {
            // dont let them take another
        }
        foreach(Transform child in parent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        StoryCard c = getStoryCard();
        GameObject card = factory.create(c);
        card.transform.SetParent(parent.transform);
        card.transform.position = new Vector3(720, 524, 0);
        if (c is QuestOTRT.Quest) return Game.gameState.Quest;
        else if (c is QuestOTRT.Event) return Game.gameState.Event;
        else return Game.gameState.Tournment;
        
    }

    public int numAdvCards()
    {
        return AdvDeck.Count;
    }
    
}
