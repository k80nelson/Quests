using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestOTRT{
    public class AllyScript : MonoBehaviour {

        public Ally card;
        public string name;
        public int bp;
        public int bids;
        public string special;
        public int specialBP;
        public int specialBids;

	    // Use this for initialization
	    void Start () {
            card = new Ally(name, bp, bids, specialBP, specialBids, special);
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
            string[] temp = { "hey", "howareyou" };
            print(card.getBP(temp));
        }
    }
}
