using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestOTRT
{
    public class QuestController : GameElement
    {

        public Quest card;


        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void initialize(string name, int stages)
        {
            card = new Quest(name, stages);
        }

        public void initialize(Quest quest)
        {
            card = quest;
        }

        //When card is clicked, only on 
        private void OnMouseDown()
        {
            if (card != null) print(card.Name);
            print(getName());
            print(getStage());
        }

        public string getName()
        {
            return card.Name;
        }

        public int getStage()
        {
            return card.Stages;
        }


    }
}
