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

    // returns a list of card indices to instantiate
    public List<int> drawAdvCards(int num) 
    {
        return advDeck.drawMany(num);
    }

    // returns a single index
    public int drawAdvCard()
    {
        return advDeck.draw();
    }

    // returns a single index
    public int drawStoryCard()
    {
        return storyDeck.draw();
    }

    // MUST be called if you discard a card to keep the card in circulation
    public void discardAdvCard(int num)
    {
        advDeck.discard(num);
    }

    // MUST be called if you discard a card to keep the card in circulation
    public void discardStoryCard(int num)
    {
        storyDeck.discard(num);
    }
}
