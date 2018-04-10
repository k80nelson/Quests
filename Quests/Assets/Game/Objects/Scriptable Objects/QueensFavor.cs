using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Lowest ranked player(s) immediately recieve 2 Adventure Cards
public class QueensFavor : BaseEvent
{
    
    public override void apply()
    {
        //throw new System.NotImplementedException();
        List<NetPlayerController> players = GameManager.players;
    }
}
