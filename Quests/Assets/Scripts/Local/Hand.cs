using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Hand : ScriptableObject {

    public List<AdventureCard> cards;
    public int max = 12;

    public int Count
    {
        get
        {
            return cards.Count;
        }
    }

    private void Awake()
    {
        cards = new List<AdventureCard>();
    }

    public IEnumerable<AdventureCard> getICards()
    {
        foreach (AdventureCard card in cards)
        {
            yield return card;
        }
    }

    public List<AdventureCard> getCards()
    {
        return new List<AdventureCard>(cards);
    }

    public List<AdventureCard> getWeapons()
    {
        List<AdventureCard> ret = cards.Where(i => i.type == AdventureCardType.WEAPON).ToList();
        return ret;
    }

    public List<AdventureCard> getAllies()
    {
        List<AdventureCard> ret = cards.Where(i => i.type == AdventureCardType.ALLY).ToList();
        return ret;
    }
    public List<AdventureCard> getFoes()
    {
        List<AdventureCard> ret = cards.Where(i => i.type == AdventureCardType.FOE).ToList();
        return ret;
    }

    public bool containsFoes(int num)
    {
        return (cards.Where(i => i.type == AdventureCardType.FOE).ToList().Count >= num);
    }

    public bool containsTest()
    {
        return (cards.Find(i => i.type == AdventureCardType.TEST) != null);
    }
    public List<AdventureCard> getTests()
    {
        List<AdventureCard> ret = cards.Where(i => i.type == AdventureCardType.TEST).ToList();
        return ret;
    }
    public List<AdventureCard> getAmours()
    {
        List<AdventureCard> ret = cards.Where(i => i.type == AdventureCardType.AMOUR).ToList();
        return ret;
    }
    public void Add(AdventureCard card)
    {
        if (cards == null) cards = new List<AdventureCard>();
        cards.Add(card);
    }

    public void add(List<AdventureCard> cards)
    {
        if (cards == null) cards = new List<AdventureCard>();
        this.cards.AddRange(cards);
    }

    public void remove(AdventureCard card)
    {
        cards.Remove(card);
    }
}
