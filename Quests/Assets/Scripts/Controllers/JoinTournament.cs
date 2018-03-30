using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinTournament : GameElement
{

    public GameObject StoryCard;
    public GameObject card;
    public Transform parentTransform;

    public List<int> players;
    public int counter;

    private void OnEnable()
    {
        Debug.Log("[JoinTournament:OnEnable] Initializing Join Tournament");
        players = new List<int>();
        GameObject tmp = StoryCard.transform.GetChild(0).gameObject;
        card = Instantiate(tmp, parentTransform);
        card.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        card.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        card.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        counter = 0;

        Debug.Log("[JoinTournament:OnEnable] Initialization complete");
    }

    public void yes()
    {
        counter += 1;
        players.Add(game.currPlayer);

        Debug.Log("[JoinTournament:yes] Tournament accepted by player " + (game.currPlayer + 1));

        if (counter == game.numPlayers)
        {
            end();
        }
        else
        {
            game.setNextPlayer();
        }
    }

    public void no()
    {
        counter += 1;

        Debug.Log("[JoinTournament:no] Tournament refused by player " + (game.currPlayer + 1));

        if (counter == game.numPlayers)
        {
            end();
        }
        else
        {
            game.setNextPlayer();
        }
    }

    void end()
    {

        Debug.Log("[JoinTournament:end] Join Tournament complete");

        Destroy(card);
        game.CreateTournament(players);
        game.view.EndJoinTournament();
    }
}
