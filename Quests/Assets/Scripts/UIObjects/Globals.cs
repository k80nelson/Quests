using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using QuestOTRT;
    public class Globals : GameElement
    {

        public int numPlayers;
        public int[] choices;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
}

