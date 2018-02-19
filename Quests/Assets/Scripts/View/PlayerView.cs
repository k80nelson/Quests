using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour {
    public GameObject card;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void createCard(string name)
    {
        GameObject n = Instantiate(card);
        n.name = name;
        n.transform.parent = gameObject.transform;
    }
}
