using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour {

    #region singleton
    public static DeckController instance;
    #endregion

    public Deck advDeck;
    
    private void Start()
    {
        instance = this;
    }
    
    public List<int> drawAdvCards(int num)
    {
        return advDeck.drawMany(num);
    }

}
