using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestOTRT{
    public class AllyScript : MonoBehaviour {

        Ally allycard =  new Ally("temp",1,1,1,1,"temp");

	    // Use this for initialization
	    void Start () {
		
	    }
	
	    // Update is called once per frame
	    void Update () {
		
	    }

        //When card is clicked, only on 
        private void OnMouseUpAsButton()
        {

        }

        private void OnMouseOver()
        {
            //print(allycard.getBP());
        }
    }
}
