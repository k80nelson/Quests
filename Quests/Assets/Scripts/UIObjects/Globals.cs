using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using QuestOTRT;
    public class Globals : GameElement
    {

        public int numPlayers = 0;
        public int numStrongAi = 0;
        public int numWeakAi = 0;


        // Use this for initialization
        void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void addPlayers()
        {
            numPlayers++;
        }
        public void addWeakAi()
        {
            numWeakAi++;
        }
        public void addStrongAi()
        {
            numStrongAi++;
        }
    }

