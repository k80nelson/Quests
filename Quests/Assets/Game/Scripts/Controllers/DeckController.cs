using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS SHOULD ONLY EXIST ON THE SERVER //
public class DeckController : MonoBehaviour
{

    #region Singleton
    public static DeckController instance;
    #endregion

    [SerializeField] Deck advDeck;     // Adventure Deck Instance
    [SerializeField] Deck storyDeck;   // Story Deck instance
    

    private void Awake()
    {
        instance = this;
    }

    // ----- ADVENTURE DECK -----
    
        
    public List<int> drawAdvCards(int num)
    {
        // returns a list of card indices to instantiate
        Debug.Log("[DeckController.cs:drawAdvCards] Retrieving "+num+" adventure cards");
        return advDeck.drawMany(num);
    }

    public int drawAdvCard()
    {
        // returns a single index
        Debug.Log("[DeckController.cs:drawAdvCard] Retrieving adventure card");
        return advDeck.draw();
    }
    
    public void discardAdvCard(int num)
    {
        // MUST be called if you discard a card to keep the card in circulation
        Debug.Log("[DeckController.cs:discardAdvCard] Discarding adventure card " + num);
        advDeck.discard(num);
    }

    // ----- STORY DECK -----
    
        
    public int drawStoryCard()
    {
        // returns a single index
        Debug.Log("[DeckController.cs:drawStorycard] Drawing story card.");
        return storyDeck.draw();
    }

   
    public void discardStoryCard(int num)
    {
        // MUST be called if you discard a card to keep the card in circulation
        Debug.Log("[DeckController.cs:discardStoryCard] Discarding active story card");
        storyDeck.discard(num);
    }
}
