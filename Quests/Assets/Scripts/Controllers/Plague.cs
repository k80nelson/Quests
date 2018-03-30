using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Drawer loses 2 shields, if possible
public class Plague : GameElement
{
    void Start()
    {
        
        play();
    }

    public void play()
    {
        PlayerModel p = game.players[game.currPlayer].GetComponent<PlayerModel>();
        p.removeShields(2);
    }
}
