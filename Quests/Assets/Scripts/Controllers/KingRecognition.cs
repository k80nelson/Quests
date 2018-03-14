using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Next player(s) to complete a Quest reicieve 2 extra shields
public class KingRecognition : MonoBehaviour
{
    Gameplay game;
    void Start()
    {
        game = GameObject.FindGameObjectWithTag("Game").GetComponent<Gameplay>();
        play();
    }

    public void play()
    {
    }
}