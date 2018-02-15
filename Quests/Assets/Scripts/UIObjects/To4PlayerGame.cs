using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class To4PlayerGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("4pGame");
    }
}
