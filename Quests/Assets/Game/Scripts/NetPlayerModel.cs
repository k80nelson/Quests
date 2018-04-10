using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public enum Rank { Squire, Knight, Champion, RoundTable };
public class NetPlayerModel : NetworkBehaviour {

    protected PlayerView _view;
    
    [SyncVar(hook = "OnRankChanged")]
    public int rankInt = 0;

    [SyncVar(hook = "OnShieldsChanged")]
    public int shields = 0;

    [SyncVar(hook = "OnCardsChanged")]
    public int cards = 0;

    public const int maxCards = 12;

    [SyncVar]
    public int bp = 5;

    Hand _hand;
    List<AdventureCard> _allies;

    private void Awake()
    {
        _view = GetComponent<PlayerView>();
    }

    [Server]
    public void AddCard(AdventureCard card)
    {
        if (_hand == null) _hand = ScriptableObject.CreateInstance<Hand>();
        _hand.Add(card);
        cards += 1;
    }

    [Server]
    public void AddAlly(AdventureCard card)
    {
        if (card == null) return;
        if (_allies == null) _allies = new List<AdventureCard>();
        if (card.type == AdventureCardType.ALLY) _allies.Add(card);
    }

    [Server]
    public void AddAllies(List<AdventureCard> cards)
    {
        if (cards == null) return;
        foreach (AdventureCard card in cards)
        {
            AddAlly(card);
        }
    }

    [Server]
    public List<AdventureCard> removeAllies()
    {
        List<AdventureCard> ret = new List<AdventureCard>(_allies);
        _allies.Clear();
        return ret;
    }

    [Server]
    public void removeShields(int num)
    {
        this.shields -= num;
        if (num < 0)
            shields = 0;
    }

    [Server]
    public bool hasTest()
    {
        return _hand.containsTest();
    }

    [Server]
    public bool enoughFoes(int num)
    {
        return _hand.containsFoes(num);
    }

    [Server]
    public int calculateAllyBP()
    {
        int total = 0;
        foreach (AdventureCard ally in _allies)
        {
            total += ally.getBP();
        }
        return total;
    }

    [Server]
    public void removeCard(AdventureCard card)
    {
        _hand.remove(card);
        cards -= 1;
    }

    [Server]
    public void Init()
    {
        rankInt = 0;
        shields = 0;
        cards = 0;
        bp = 5;
    }

    bool canUpgrade(int additionalShields)
    {
        bool upgrade = false;
        if (rankInt == 0 && ((shields + additionalShields) >= 5))
        {
            upgrade = true;
        }
        else if (rankInt == 1 && ((shields + additionalShields) >= 7))
        {
            upgrade = true;
        }
        else if (rankInt == 2 && ((shields + additionalShields) >= 10))
        {
            upgrade = true;
        }
        return upgrade;
    }

    [Server]
    public bool rankUp()
    {
        switch (this.rankInt)
        {
            case 0:
                if (shields >= 5)
                {
                    shields -= 5;
                    rankInt++;
                    bp += 5;
                    return true;
                }
                return false;
            case 1:
                if (shields >= 7)
                {
                    shields -= 7;
                    rankInt++;
                    bp += 5;
                    return true;
                }
                return false;
            case 2:
                if (shields >= 10)
                {
                    shields -= 10;
                    rankInt++;
                    bp += 5;
                    return true;
                }
                return false;
            default:
                throw new System.Exception("Trying to rank up past the end game");
        }
    }

    [Server]
    public void addShields(int num)
    {
        shields += num;
        if (canUpgrade(0))
        {
            rankUp();
            PromptHandler.instance.SendPromptToAll("Rank Up!", name + " has ranked up to " + ((Rank)rankInt).ToString() +".");
        }
    } 

    // -- SyncVar hooks
    void OnRankChanged(int newVal)
    {
        rankInt = newVal;
        _view.updateRankText(newVal);
        if (newVal == 3)
        {
            // GAME IS OVER
        }
    }

    void OnShieldsChanged(int newVal)
    {
        shields = newVal;
        _view.updateShieldText(newVal);
    }

    void OnCardsChanged(int newVal)
    {
        cards = newVal;
        _view.updateCardText(newVal);
    }

}
