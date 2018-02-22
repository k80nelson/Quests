using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestOTRT
{
    public class EventController : GameElement
    {

        public Event card;


        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void initialize(string name)
        {
            card = new Event(name);
        }

        public void initialize(Event eventC)
        {
            card = eventC;
        }

        //When card is clicked, only on 
        private void OnMouseDown()
        {
            if (card != null) print(card.Name);
            print(getName());
        }

        public string getName()
        {
            return card.Name;
        }


    }
}
