using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestView : GameElement {

    public GameObject amourPrefab;
    
    public GameObject combatArea;
    public GameObject testArea;

    public Transform cardsInPlay;

    public void showCombat()
    {
        combatArea.SetActive(true);
        testArea.SetActive(false);
    }

    public void showTest()
    {
        testArea.SetActive(true);
        combatArea.SetActive(false);
    }

    public void showCards()
    {
        foreach(Transform child in cardsInPlay)
        {
            Destroy(child.gameObject);
        }
        List<GameObject> allies = game.players[game.activePlayer].GetComponent<PlayerController>().getAllies();
        foreach (GameObject ally in allies)
        {
            GameObject objtmp = Instantiate(ally, cardsInPlay);
            objtmp.GetComponent<Draggable>().draggable = false;
        }
        if (game.players[game.activePlayer].GetComponent<PlayerModel>().cardsPlayed4Quest.containsAmour())
        {
            GameObject objtmp = Instantiate(amourPrefab, cardsInPlay);
            objtmp.GetComponent<Draggable>().draggable = false;
        }
    }
}
