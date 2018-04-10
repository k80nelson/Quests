using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Next player(s) to complete a Quest reicieve 2 extra shields
public class KingsRecognition : BaseEvent
{
    
    public override void apply()
    {
        //throw new System.NotImplementedException();
        List<NetPlayerController> players = GameManager.players;
    }
}
