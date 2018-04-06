using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryDeckModel : BaseDeckModel {

    void initialize()
    {
        for (int i = 0; i < 22; i++)
        {
            validCards.Add(i);
        }
        
        numCards[0] = 2;
        numCards[1] = 1;
        numCards[2] = 1;
        numCards[3] = 2;
        numCards[4] = 1;
        numCards[5] = 1;
        numCards[6] = 1;
        numCards[7] = 1;
        numCards[8] = 1;
        numCards[9] = 2;
        numCards[10] = 1;
        numCards[11] = 1;
        numCards[12] = 1;
        numCards[13] = 1;
        numCards[14] = 1;
        numCards[15] = 2;
        numCards[16] = 1;
        numCards[17] = 2;
        numCards[18] = 1;
        numCards[19] = 1;
        numCards[20] = 1;
        numCards[21] = 2;

        cardsRemaining = 28;
    }

    void Awake()
    {
        validCards = new List<int>();
        numCards = new Dictionary<int, int>();
        initialize();
    }

    public override void emptyDeck()
    {
        initialize();
    }

    
}
