using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour {

    #region singleton
    public static DeckController instance;
    #endregion

    public AdventureDeck advDeck;
    public GameObject advCardPrefab;
    public GameObject storyCardPrefab;
    
    private void Start()
    {
        instance = this;
        advDeck = GetComponent<AdventureDeck>();
    }

    public List<GameObject> drawAdvCards(int num, Transform parent)
    {
        List<AdventureCard> cards = advDeck.drawMany(num);
        List<GameObject> cardObjs = new List<GameObject>();
        foreach (AdventureCard card in cards)
        {
            GameObject cardObj = Instantiate(advCardPrefab, parent);
            cardObj.GetComponent<Card>().registerCard("Adventure Cards/"+card.name);
            cardObj.name = card.name;
            cardObjs.Add(cardObj);
        }
        return cardObjs;
    }
    
}
