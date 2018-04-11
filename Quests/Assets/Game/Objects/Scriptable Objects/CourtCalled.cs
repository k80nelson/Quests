using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//All Allies in play are discarded
public class CourtCalled : BaseEvent
{

    public override void apply()
    {
        //throw new System.NotImplementedException();
        List<NetPlayerController> players = GameManager.players;

        foreach (NetPlayerController player in players)
            player.discardAllies();

        Debug.Log("[CourtCalled.cs:play] Court Called to Camelot complete -> Every ally in play discarded");
    }
}
