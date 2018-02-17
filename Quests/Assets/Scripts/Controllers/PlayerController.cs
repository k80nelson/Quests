using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestOTRT;

public class PlayerController : GameElement {

    public QuestOTRT.Player player;

    // When absolutely first loaded
    void Awake()
    {
        
    }
    // When first enabled
    void Start ()
    {
        player = new QuestOTRT.Player();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

}
