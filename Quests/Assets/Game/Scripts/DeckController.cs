using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeckController : MonoBehaviour
{

    #region Singleton
    public static DeckController instance;
    #endregion

    [SerializeField] Deck advDeck;
    [SerializeField] Deck storyDeck;
    

    private void Awake()
    {
        instance = this;
    }

    public List<int> drawAdvCards(int num)
    {
        return advDeck.drawMany(num);
    }

    public int drawStoryCard()
    {
        return storyDeck.draw();
    }

    public void discardAdvCard(int num)
    {
        advDeck.discard(num);
    }
}
