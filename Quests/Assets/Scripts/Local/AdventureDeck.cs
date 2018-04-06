using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureDeck : MonoBehaviour {
    
    public List<AdventureCard> CardObjects;
    public List<int> validCards;
    public Dictionary<int, int> numCards;
    public int cardsRemaining;
    public static System.Random rng = new System.Random();
    public List<int> discardDeck;


    private void Awake()
    {
        numCards = new Dictionary<int, int>();
        initialize();
    }

    void initialize()
    {
        discardDeck = new List<int>();

        for (int i = 0; i < 32; i++)
        {
            validCards.Add(i);
        }

        numCards[0] = 1;      // King Arthur
        numCards[1] = 1;      // King Pellinore
        numCards[2] = 1;      // Merlin
        numCards[3] = 1;      // Queen Guinevere
        numCards[4] = 1;      // Queen Iseult
        numCards[5] = 1;      // Sir Galahad
        numCards[6] = 1;      // Sir Gawain
        numCards[7] = 1;      // Sir Lancelot
        numCards[8] = 1;      // Sir Percival
        numCards[9] = 1;      // Sir Tristan
        numCards[10] = 3;     // Black Knight
        numCards[11] = 4;     // Boar
        numCards[12] = 1;     // Dragon
        numCards[13] = 6;     // Evil Knight
        numCards[14] = 2;     // Giant
        numCards[15] = 2;     // Green Knight
        numCards[16] = 4;     // Mordred
        numCards[17] = 7;     // Robber Knight
        numCards[18] = 8;     // Saxon Knight
        numCards[19] = 5;     // Saxons
        numCards[20] = 8;     // Thieves
        numCards[21] = 8;     // Battle-ax
        numCards[22] = 6;     // Dagger
        numCards[23] = 2;     // Excalibur
        numCards[24] = 11;    // Horse 
        numCards[25] = 6;     // Lance
        numCards[26] = 16;    // Sword
        numCards[27] = 2;     // Test of Morgan Le Fey
        numCards[28] = 2;     // Test of Temptation
        numCards[29] = 2;     // Test of the Questing Beast
        numCards[30] = 2;     // Test of Valor
        numCards[31] = 8;     // Amour

        cardsRemaining = 125;
    }

    // returns an AdventureCard scriptableObject
    public AdventureCard draw()
    {
        if (cardsRemaining == 0) emptyDeck();
        int rand = rng.Next(0, cardsRemaining);
        int selected = -1;

        foreach (int i in validCards)
        {
            if (rand < numCards[i])
            {
                selected = i;
                break;
            }
            rand -= numCards[i];
        }


        if (numCards[selected] == 1)
        {
            validCards.Remove(selected);
        }

        numCards[selected] -= 1;
        cardsRemaining -= 1;

        AdventureCard ret = CardObjects[selected];
        return ret;
    }

    public AdventureCard draw(string name)
    {
        int index = CardObjects.FindIndex(x => x.name == name);
        if (index == -1) return null;
        if (!validCards.Contains(index)) return null;
        return draw(index);
    }

    /* returns a card to instantiate */
    public AdventureCard draw(int num)
    {
        if (cardsRemaining == 0) emptyDeck();

        if (numCards[num] == 1)
        {
            validCards.Remove(num);
        }

        numCards[num] -= 1;
        cardsRemaining -= 1;

        AdventureCard ret = CardObjects[num];
        return ret;
    }

    /* returns a list of cards to instantiate */
    public List<AdventureCard> drawMany(int num)
    {
        List<AdventureCard> ret = new List<AdventureCard>();
        for (int i = 0; i < num; i++)
        {
            ret.Add(draw());
        }
        return ret;
    }

    public void emptyDeck()
    {
        foreach (int index in discardDeck)
        {
            if (!validCards.Contains(index)) validCards.Add(index);
            numCards[index] += 1;
        }

        discardDeck.Clear();
    }
}
