using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public enum Rank { Squire, Knight, Champion, RoundTable };
public class NetPlayerModel : NetworkBehaviour {

    public const int maxCards = 12;

    protected PlayerView _view;
    
    [SyncVar(hook = "OnRankChanged")] public int rankInt = 0;
    [SyncVar(hook = "OnShieldsChanged")] public int shields = 0;
    [SyncVar(hook = "OnCardsChanged")]  public int cards = 0;
    [SyncVar] public int bp = 5;

    Hand _hand;
    List<AdventureCard> _allies;

    // ---- INITIALIZATION ----

    private void Awake()
    {
        _view = GetComponent<PlayerView>();
    }

    [Server]  public void Init()
    {
        rankInt = 0;
        shields = 0;
        cards = 0;
        bp = 5;
    }

    // ---- HOOKS ----

    #region SyncVar Hooks
    void OnRankChanged(int newVal)
    {
        // THIS FUNCTION ENDS THE GAME!!!!!!!
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
    #endregion

    // ---- CARD MANIPULATION ----

    [Server] public void AddCard(AdventureCard card)
    {
        // calls OnCardsChanged() through the syncVar hook
        if (_hand == null) _hand = ScriptableObject.CreateInstance<Hand>();
        _hand.Add(card);
        cards += 1;
    }
    [Server] public void removeCard(AdventureCard card)
    {
        _hand.remove(card);
        cards -= 1;
    }

    [Server] public void AddAlly(AdventureCard card)
    {
        // _allies only exists on the server 
        if (card == null) return;
        if (_allies == null) _allies = new List<AdventureCard>();
        if (card.type == AdventureCardType.ALLY) _allies.Add(card);
    }

    [Server] public void AddAllies(List<AdventureCard> cards)
    {
        if (cards == null) return;
        foreach (AdventureCard card in cards)
        {
            AddAlly(card);
        }
    }

    [Server] public List<AdventureCard> removeAllies()
    {
        List<AdventureCard> ret = new List<AdventureCard>(_allies);
        _allies.Clear();
        return ret;
    }

    // ---- SHIELD AND RANK MANIPULATION ----

    [Server] public void removeShields(int num)
    {
        this.shields -= num;
        if (this.shields < 0)
            shields = 0;
    }

    [Server]  public void addShields(int num)
    {
        // calls PromptHandler to prompt every player that another player has ranked up
        shields += num;
        if (canUpgrade(0))
        {
            rankUp();
            PromptHandler.instance.SendPromptToAll("Rank Up!", name + " has ranked up to " + ((Rank)rankInt).ToString() + ".");
        }
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

    [Server]  public bool rankUp()
    {
        // modifies rankInt, so must be called on the server
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


    // ---- CARD GETTERS ----

    [Server] public bool hasTest()
    {
        return _hand.containsTest();
    }

    [Server] public bool enoughFoes(int num)
    {
        return _hand.containsFoes(num);
    }

    [Server] public int calculateAllyBP()
    {
        // _allies only exists on the server
        int total = 0;
        foreach (AdventureCard ally in _allies)
        {
            total += ally.getBP();
        }
        return total;
    }
    
}
