using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestOTRT
{
    public class FoeController : GameElement
    {

        public Foe card;


        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void initialize(string name, int bp, int bids, int specialBP, string[] specialCards)
        {
            card = new Foe(name, bp, bids, specialBP, specialCards);
        }

        public void initialize(Foe foe)
        {
            card = foe;
        }

        //When card is clicked, only on 
        private void OnMouseDown()
        {
            if (card != null) print(card.Name);
            print(getBP());
        }

        public int getBP()
        {
            return 0;
        }

    }
}
