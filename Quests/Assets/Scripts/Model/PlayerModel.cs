using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{

    public enum Rank { Squire, Knight, Champion }

    public int index;
    public int rank;
    public int shields;
    public int bp;
    public Hand hand;
    public int numCards
    {
        get
        {
            return hand.Count;
        }
    }

    public int getRank()
    {
        return rank;
    }

    public void addShields(int num)
    {
        shields += num;
        if (canUpgrade(0)) rankUp();
    }

    public void removeShields(int numToRemove)
    {
        this.shields -= numToRemove;
        if (this.shields < 0)
        {
            shields = 0;
        }
    }

    public List<AdventureCard> allies;

    public List<AdventureCard> getAllies()
    {
        return new List<AdventureCard>(allies);
    }
    
    public void removeAllies()
    {
        //removes all allies for the player
        allies.Clear();

    }

    public List<AdventureCard> getCards()
    {
        return hand.getCards();
    }

    public void removeCard(AdventureCard card)
    {
        hand.remove(card);
    }

    public bool overMax()
    {
        return (hand.Count > hand.max);
    }

    public void addCard(GameObject card)
    {
        hand.Add(card.GetComponent<AdventureCard>());
    }

    public bool canUpgrade(int additionalShields)
    {
        bool upgrade = false;
        if (rank == 0 && ((shields + additionalShields) >= 5))
        {
            upgrade = true;
        }
        else if (rank == 1 && ((shields + additionalShields) >= 7))
        {
            upgrade = true;
        }
        else if (rank == 2 && ((shields + additionalShields) >= 10))
        {
            upgrade = true;
        }
        return upgrade;
    }

    public bool rankUp()
    {
        switch (this.rank)
        {
            case 0:
                if (shields >= 5)
                {
                    shields -= 5;
                    rank++;
                    bp += 5;
                    return true;
                }
                return false;
            case 1:
                if (shields >= 7)
                {
                    shields -= 7;
                    rank++;
                    bp += 5;
                    return true;
                }
                return false;
            default:
                throw new System.Exception("Trying to rank up past the end game");
        }
    }
}


