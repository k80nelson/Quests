using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//All players can immediately draw 2 Adventure Cards
[CreateAssetMenu(menuName = "Prosperity")]
public class ProsperityTTR : EventCard
{

    public override void Apply()
    {
        //throw new System.NotImplementedException();
        List<NetPlayerController> players = GameManager.players;

        foreach (NetPlayerController player in players)
            player.drawAdvCards(2);

        Debug.Log("[ProsperityTrR:play] Prosperity Throughout the Realm complete -> All players add 2 adventure cards");
    }
}
