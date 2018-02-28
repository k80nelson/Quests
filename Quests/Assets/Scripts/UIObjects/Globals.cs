using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour {

    public static int numPlayers=0;
    public static int numStrongAi=0;
    public static int numWeakAi=0;


	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void addPlayers()
    {
        numPlayers++;
    }
    public void addWeakAi()
    {
        numWeakAi++;
    }
    public void addStrongAi()
    {
        numStrongAi++;
    }
}
