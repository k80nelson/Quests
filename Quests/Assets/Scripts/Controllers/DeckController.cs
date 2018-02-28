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

    public void DrawStoryCard()
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
        GameObject card = factory.create(getStoryCard());
        card.transform.SetParent(parent.transform);
        card.transform.position = new Vector3(720, 524, 0);
    }

    public int numAdvCards()
    {
        return AdvDeck.Count;
    }
    
}
