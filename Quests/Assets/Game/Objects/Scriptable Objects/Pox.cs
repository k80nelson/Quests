using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 //All other players lose one shield(if possible), drawer of this card is exempt
public class Pox : BaseEvent{
   
    public override void apply()
    {
        //throw new System.NotImplementedException(); 
        List<NetPlayerController> players = GameManager.players;
        
    }
    
}
