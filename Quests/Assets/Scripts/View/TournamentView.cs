using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TournamentView : GameElement {

    public GameObject amourPrefab;
    public Transform cardsInPlay;

    public void showCards()
    {
        foreach (Transform child in cardsInPlay)
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
