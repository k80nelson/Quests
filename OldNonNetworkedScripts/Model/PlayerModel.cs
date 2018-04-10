using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class PlayerModel : NetworkBehaviour
{

    public enum Rank { Squire, Knight, Champion }

    [SyncVar]
    public int index;
    [SyncVar]
    public int rank;
    [SyncVar]
    public int shields;
    [SyncVar]
    public int bp;
    [SyncVar]
    public Hand hand;

    [SyncVar]
    public StageModel cardsPlayed4Quest;
    [SyncVar]
    public List<AdventureCard> allies;

    private void Awake()
    {
        allies = new List<AdventureCard>();
        cardsPlayed4Quest = new StageModel();
    }

    public bool enoughFoes(int num)
    {
        return hand.containsFoes(num);
    }

    public bool hasTest()
    {
        return hand.containsTest();
    }

    public int getBP()
    {
        int total = calculateAllyBP();
        return (total + bp);
    }

    public int calculateAllyBP()
    {
        int total = 0;
        foreach (AdventureCard ally in allies)
        {
            total += ally.getBP();
        }
        return total;
    }

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
        if (!isServer)
            return;
        shields += num;
        if (canUpgrade(0)) rankUp();
    }

    public void removeShields(int numToRemove)
    {
        if (!isServer)
            return;
        this.shields -= numToRemove;
        if (this.shields < 0)
        {
            shields = 0;
        }
    }

    public List<AdventureCard> getAllies()
    {
        return new List<AdventureCard>(allies);
    }
    

    public void addAlly(AdventureCard card)
    {
        if (!isServer)
            return;
        if (card == null) return;
        if(card.type == AdventureCard.Type.ALLY) allies.Add(card.GetComponent<AdventureCard>());
    }

    public void addAllies(List<AdventureCard> cards)
    {
        if (!isServer)
            return;
        if (cards == null) return;
        for(int i = 0; i < cards.Count; ++i)
        {
            if (cards[i].type == AdventureCard.Type.ALLY)
                allies.Add(cards[i].GetComponent<AdventureCard>());
        }
        
    }

    public List<AdventureCard> removeAllies()
    {
        //removes all allies for the player
        List<AdventureCard> ret = new List<AdventureCard>(allies);
        allies.Clear();
        return ret;
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

