using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestOTRT
{
    public class TestController : GameElement
    {

        public Test card;


        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void initialize(string name, int bp, int bids, int specialBids, string specialQuest)
        {
            card = new Test(name, bp, bids, specialBids, specialQuest);
        }

        public void initialize(Test test)
        {
            card = test;
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
