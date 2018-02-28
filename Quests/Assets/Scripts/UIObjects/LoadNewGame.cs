using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QuestOTRT;

namespace QuestOTRT
{
    public class LoadNewGame : MonoBehaviour
    {
        public Globals globals;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void OnClick()
        {
            foreach (Dropdown d in GameObject.FindObjectsOfType<Dropdown>())
            {
                if (d.value == 0) { globals.addPlayers(); }
                else if (d.value == 1) { globals.addWeakAi(); }
                else { globals.addStrongAi(); }
            }
            
            UnityEngine.SceneManagement.SceneManager.LoadScene("4pGame");
        }
    }
}