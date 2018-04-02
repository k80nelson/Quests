using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinQuest : MonoBehaviour {
    public GameObject StoryCard;
    public GameObject card;
    public Transform parentTransform;
    public Gameplay game;

    public List<int> players;
    public int counter;

    private void OnEnable()
    {
        Debug.Log("[JoinQuest.cs:OnEnable] Initializing Join Quest");
        players = new List<int>();
        GameObject tmp = StoryCard.transform.GetChild(0).gameObject;
        card = Instantiate(tmp, parentTransform);
        card.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        card.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        card.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        counter = 0;
        Debug.Log("[JoinQuest.cs:OnEnable] Initialization complete");
    }

    public void yes()
    {
        counter += 1;
        players.Add(game.currPlayer);

        Debug.Log("[JoinQuest:yes] Added player " + (game.currPlayer + 1) + " to Quest");

        if (counter == (game.numPlayers - 1))
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

        Debug.Log("[JoinQuest.cs:no] Player " + (game.currPlayer + 1) + " refused quest");

        if (counter == (game.numPlayers - 1))
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
        Debug.Log("[JoinQuest:end] Join Quest completed");
        Destroy(card);
        game.view.EndJoinQuest();
        game.CreateQuest(players);
    }
}
