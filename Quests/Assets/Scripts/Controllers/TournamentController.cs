using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestOTRT
{
    public class TournamentController : GameElement
    {

        public Tournament card;


        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void initialize(string name, int shields)
        {
            card = new Tournament(name, shields);
        }

        public void initialize(Tournament tournament)
        {
            card = tournament;
        }

        //When card is clicked, only on 
        private void OnMouseDown()
        {
            if (card != null) print(card.Name);
            print(getShields());
        }

        public int getShields()
        {
            return card.Shields;
        }

    }
}
