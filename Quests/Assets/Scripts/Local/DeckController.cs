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

    public GameObject toRemove;
    public GameObject tmpCard;
    public Transform discardTransform;

    private void Start()
    {
        instance = this;
    }
    
    public List<int> drawAdvCards(int num)
    {
        return advDeck.drawMany(num);
    }
}
