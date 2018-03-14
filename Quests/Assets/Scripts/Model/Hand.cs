using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Hand : MonoBehaviour
{

    private List<AdventureCard> cards;
    public int max;

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
        List<AdventureCard> ret = cards.Where(i => i.type == AdventureCard.Type.WEAPON).ToList();
        return ret;
    }

    public List<AdventureCard> getAllies()
    {
        List<AdventureCard> ret = cards.Where(i => i.type == AdventureCard.Type.ALLY).ToList();
        return ret;
    }
    public List<AdventureCard> getFoes()
    {
        List<AdventureCard> ret = cards.Where(i => i.type == AdventureCard.Type.FOE).ToList();
        return ret;
    }
    public List<AdventureCard> getTests()
    {
        List<AdventureCard> ret = cards.Where(i => i.type == AdventureCard.Type.TEST).ToList();
        return ret;
    }
    public List<AdventureCard> getAmours()
    {
        List<AdventureCard> ret = cards.Where(i => i.type == AdventureCard.Type.AMOUR).ToList();
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