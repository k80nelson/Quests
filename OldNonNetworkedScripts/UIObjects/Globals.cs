using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestOTRT;

public class Globals : MonoBehaviour
{
    public int numPlayers;
    public int[] choices;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}

