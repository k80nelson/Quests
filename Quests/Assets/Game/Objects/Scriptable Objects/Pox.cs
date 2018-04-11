using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 //All other players lose one shield(if possible), drawer of this card is exempt
public class Pox : BaseEvent{
   
    public override void apply()
    {
        //throw new System.NotImplementedException(); 
        List<NetPlayerController> players = GameManager.players;

        foreach (NetPlayerController player in players)
            player.removeShields(false, 2);

        Debug.Log("[Pox.cs:play] Pox complete -> All players except local player loses 1 shield");
    }
    
}
