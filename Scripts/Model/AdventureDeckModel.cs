using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AdventureDeckModel : BaseDeckModel {

    public List<int> discardDeck;

    void addCard(int index)
    {
        if (!validCards.Contains(index)) validCards.Add(index);
        numCards[index] += 1;
    }

    public void discard(GameObject card)
    {
        discardDeck.Add(getIndex(card));
    }

    public void discard(AdventureCard card)
    {
        Debug.Log("[AdventureDeck.cs:discard] " + card.Name + " discarded");
        discardDeck.Add(getIndex(card));
    }

    public void discard(List<AdventureCard> cards)
    {
        if (cards == null) return;
        foreach (AdventureCard card in cards)
        {
            discard(card);
        }
    }


    void initialize()
    {

        discardDeck = new List<int>();

        for (int i = 0; i < 32; i++)
        {
            validCards.Add(i);
        }
        
        numCards[0] = 1;
        numCards[1] = 1;
        numCards[2] = 1;
        numCards[3] = 1;
        numCards[4] = 1;
        numCards[5] = 1;
        numCards[6] = 1;
        numCards[7] = 1;
        numCards[8] = 1;
        numCards[9] = 1;
        numCards[10] = 3;
        numCards[11] = 4;
        numCards[12] = 1;
        numCards[13] = 6;
        numCards[14] = 2;
        numCards[15] = 2;
        numCards[16] = 4;
        numCards[17] = 7;
        numCards[18] = 8;
        numCards[19] = 5;
        numCards[20] = 8;
        numCards[21] = 8;
        numCards[22] = 6;
        numCards[23] = 2;
        numCards[24] = 11;
        numCards[25] = 6;
        numCards[26] = 16;
        numCards[27] = 2;
        numCards[28] = 2;
        numCards[29] = 2;
        numCards[30] = 2;
        numCards[31] = 8;

        cardsRemaining = 125;
    }

    public int getIndex(GameObject card)
    {
        return prefabs.ToList<GameObject>().FindIndex(x => card.name.Contains(x.name));
    }

    public int getIndex(AdventureCard card)
    {
        return prefabs.ToList<GameObject>().FindIndex(x => card.Name.Contains(x.name));
    }


    void Awake()
    {
        validCards = new List<int>();
        numCards = new Dictionary<int, int>();
        initialize();
    }

    public override void emptyDeck()
    {
        foreach(int index in discardDeck)
        {
            if (!validCards.Contains(index)) validCards.Add(index);
            numCards[index] += 1;
        }

        discardDeck.Clear();
    }
}
