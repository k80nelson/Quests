using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeckController : MonoBehaviour
{

    #region singleton
    public static DeckController instance;
    #endregion

    public Deck advDeck;
    public Deck storyDeck;

    private void Start()
    {
        instance = this;
    }
    
    public List<int> drawAdvCards(int num)
    {
        return advDeck.drawMany(num);
    }

    public void discardAdvCard(int num)
    {
        advDeck.discard(num);
    }

    public int drawStoryCard()
    {
        return storyDeck.draw();
    }

    public void discardStoryCard(int num)
    {
        storyDeck.discard(num);
    }
}
