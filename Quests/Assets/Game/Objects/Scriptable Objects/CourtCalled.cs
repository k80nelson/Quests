using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourtCalled : BaseEvent
{
    public override void apply()
    {
        //throw new System.NotImplementedException();
        List<NetPlayerController> players = GameManager.players;
    }
}
