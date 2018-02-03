using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestOTRT
{
    public class AmourController : GameElement
    {
        public Amour card;

        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void initialize(string name, int bp, int bids)
        {
            card = new Amour(name, bp, bids);
        }

        public void initialize(Amour amour)
        {
            card = amour;
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