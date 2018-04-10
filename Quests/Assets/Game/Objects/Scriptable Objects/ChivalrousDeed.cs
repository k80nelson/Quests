using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//obj: Player(s) with lowest rank and least amount of shields gains 3 shields
public class ChivalrousDeed : BaseEvent {

    public override void apply()
    {
        //throw new System.NotImplementedException();
        List<NetPlayerController> players = GameManager.players;
    }

}
