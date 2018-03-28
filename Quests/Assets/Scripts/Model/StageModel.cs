using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StageModel
{

    public List<AdventureCard> cardsPlayed;

    public StageModel()
    {
        cardsPlayed = new List<AdventureCard>();
    }

    //Returns the number of cards for that stage
    public int Count
    {
        get
        {
            return cardsPlayed.Count;
        }
    }

    public void RemoveAll()
    {
        cardsPlayed.Clear();
    }

    public bool Contains(string name)
    {
        return (cardsPlayed.Find(i => i.Name == name) != null);
    }

    public bool containsTest()
    {
        return (cardsPlayed.Find(i => i.type == AdventureCard.Type.TEST) != null);
    }

    public bool containsFoe()
    {
        return (cardsPlayed.Find(i => i.type == AdventureCard.Type.FOE) != null);
    }

    public bool isEmpty()
    {
        return (cardsPlayed.Count == 0);
    }

    //Adds one adventure card to the list
    public void Add(AdventureCard card)
    {
        if (cardsPlayed == null) cardsPlayed = new List<AdventureCard>();
        cardsPlayed.Add(card);
    }

    //Adds a list of adventure cards to the list
    public void addList(List<AdventureCard> cards)
    {
        if (cards == null) cards = new List<AdventureCard>();
        this.cardsPlayed.AddRange(cards);
    }

    //Remove one adventure card from the list, this can be used to remove the amour card at the end of the quest. So we can keep the other cards
    public void Remove(AdventureCard card)
    {
        if (cardsPlayed == null) return;
        cardsPlayed.Remove(card);
    }

    //Will remove all weapons cards from the list, this can be used for removing the weapons at the end of each stage
    public void RemoveWeapons()
    {
        if (cardsPlayed == null) return;

        for (int i = 0; i < cardsPlayed.Count; i++)
        {
            if (cardsPlayed[i].type == AdventureCard.Type.WEAPON)
            {
                cardsPlayed.Remove(cardsPlayed[i]);
            }
        }
    }

    public bool validState()
    {
        //makes sure that the stage is not empty
        if (cardsPlayed.Count == 0)
            return false;

        //if no foe and no test
        if (cardsPlayed.Find(i => i.type == AdventureCard.Type.TEST) == null || cardsPlayed.Find(i => i.type == AdventureCard.Type.FOE) == null)
            return false;

        return true;
    }

    public void Empty()
    {
        cardsPlayed.Clear();
    }
}
