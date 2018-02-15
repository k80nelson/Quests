using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestOTRT
{
    public class WeaponController : GameElement
    {

        public Weapon card;


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
            card = new Weapon(name, bp, bids);
        }

        public void initialize(Weapon weapon)
        {
            card = weapon;
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
