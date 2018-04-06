using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerStatsView : NetworkBehaviour {

    public PlayerController player;

    public Text RankObj;
    public Text ShieldObj;
    public Text CardsObj;
    public Text PlayerObj;
    
    [SyncVar]
    public string rankstr = "Rank: ";
    [SyncVar]
    public string shieldstr = "Shields: ";
    [SyncVar]
    public string cardsstr = "Cards: ";

    public void setPlayerText(int index)
    {
        PlayerObj.text = "P" + (index + 1);
    }
    
    [Server]
    public void setValues()
    {
        this.rankstr = "Rank: " + player.model.rank.ToString();
        this.shieldstr = "Shields: " + player.model.shields;
        this.cardsstr = "Cards: " + player.model.hand.Count;
    }

    [Server]
    public void updateValues()
    {
        setValues();
        RpcUpdateValues();
    }
    
    [Server]
    public void addPlayer(PlayerController player)
    {
        this.player = player;
    }

    [ClientRpc]
    public void RpcUpdateValues()
    {
        RankObj.text = rankstr;
        ShieldObj.text = shieldstr;
        CardsObj.text = cardsstr;
    }
}
