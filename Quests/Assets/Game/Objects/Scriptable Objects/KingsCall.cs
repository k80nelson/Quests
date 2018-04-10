using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Highest ranked player(s) must place 1 weapon in the discard
//If unable to do so, 2 foe cards must be discarded
public class KingsCall : BaseEvent
{

    public override void apply()
    {
        //throw new System.NotImplementedException();
        List<NetPlayerController> players = GameManager.players;
    }
}


