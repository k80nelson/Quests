using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType { ADV, STORY };
public class Deck : MonoBehaviour
{

    public CardType deckType;
    
    [SerializeField] List<int> cardIndex;     // The original and untouched list of card indices
    [SerializeField] List<int> initialCards;  // initial numbers of each card
    [SerializeField] int cardsRemaining;      // num cards remaining
    [SerializeField] int numUniqueCards;      // should be length of cardIndex


    // used to keep track of currently viable cards
    List<int> validCards = new List<int>();

    // dictionary mapping index to num cards
    Dictionary<int, int> numCards = new Dictionary<int, int>();

    // rng
    static System.Random rng = new System.Random();

    // discard pile
    List<int> discardList = new List<int>();

    void initialize()
    {
        validCards.AddRange(cardIndex);

        for (int i = 0; i < initialCards.Count; i++)
        {
            numCards[cardIndex[i]] = initialCards[i];
        }
    }

    private void Awake()
    {
        initialize();
    }

    public void discard(int num)
    {
        discardList.Add(num);
    }

    public int draw()
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


        removeCard(selected);

        return selected;
    }

    void removeCard(int selected)
    {
        if (numCards[selected] == 1)
        {
            validCards.Remove(selected);
        }

        numCards[selected] -= 1;
        cardsRemaining -= 1;
    }

    public int draw(string name)
    {
        int index = GameManager.instance.dict.findIndex(name);
        if (index == -1) return -1;
        return draw(index);
    }

    public int draw(int index)
    {
        if (cardsRemaining == 0) emptyDeck();
        if (!validCards.Contains(index)) return -1;

        removeCard(index);

        return index;
    }

    public List<int> drawMany(int num)
    {
        List<int> ret = new List<int>();
        for (int i = 0; i < num; i++)
        {
            ret.Add(draw());
        }
        return ret;
    }

    public void emptyDeck()
    {
        foreach (int index in discardList)
        {
            if (!validCards.Contains(index)) validCards.Add(index);
            numCards[index] += 1;
        }

        discardList.Clear();
    }

}
