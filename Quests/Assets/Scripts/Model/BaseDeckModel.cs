using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class BaseDeckModel : MonoBehaviour {

    public GameObject[] prefabs;
    public List<int> validCards;
    public Dictionary<int, int> numCards;
    public int cardsRemaining;
    public static System.Random rng = new System.Random();

    public abstract void emptyDeck();

    /* returns a card PREFAB to instantiate */
    public GameObject draw()
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
        
        GameObject ret = prefabs[selected];
        return ret;
    }
    /* returns a card PREFAB to instantiate */
    public GameObject draw(string name)
    {
        int index = prefabs.ToList<GameObject>().FindIndex(x => x.name == name);
        if (index == -1) return null;
        if (!validCards.Contains(index)) return null;
        return draw(index);
    }

    /* returns a card PREFAB to instantiate */
    public GameObject draw(int num)
    {
        if (cardsRemaining == 0) emptyDeck();

        if (numCards[num] == 1)
        {
            validCards.Remove(num);
        }

        numCards[num] -= 1;
        cardsRemaining -= 1;

        GameObject ret = prefabs[num];
        return ret;
    }

    /* returns a list of card PREFABS to instantiate */
    public List<GameObject> drawMany(int num)
    {
        List<GameObject> ret = new List<GameObject>();
        for (int i = 0; i < num; i++)
        {
            ret.Add(draw());
        }
        return ret;
    }
}
