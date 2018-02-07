using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestOTRT{
    public class AllyController : GameElement {

        public Ally card = null;


	    // Use this for initialization
	    void Start () {
	    }
	
	    // Update is called once per frame
	    void Update () {
		    
	    }

        public void initialize(string name, int bp, int bids, int sbp, int sbids, string squest)
        {
            if (card == null) card = new Ally(name, bp, bids, sbp, sbids, squest);
        }

        public void initialize(Ally ally)
        {
            if (card == null) card = ally;
        }

        //When card is clicked, only on 
        private void OnMouseDown()
        {
            if (card != null) print(card.Name);
            print(getBP());
        }

        public int getBP()
        {
            return card.getBP(gameState.currCards);
        }

    }
}
