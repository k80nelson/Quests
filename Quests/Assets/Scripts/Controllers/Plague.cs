using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Drawer loses 2 shields, if possible
public class Plague : MonoBehaviour
{
    Gameplay game;
    void Start()
    {
        game = GameObject.FindGameObjectWithTag("Game").GetComponent<Gameplay>();
        play();
    }

    public void play()
    {
        PlayerModel p = game.players[game.currPlayer].GetComponent<PlayerModel>();
        p.removeShields(2);
    }
}
