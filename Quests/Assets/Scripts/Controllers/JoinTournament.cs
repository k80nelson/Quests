using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinTournament : MonoBehaviour
{

    public GameObject StoryCard;
    public GameObject card;
    public Transform parentTransform;
    public Gameplay game;

    public List<int> players;
    public int counter;

    private void OnEnable()
    {
        if (game == null) game = GameObject.FindGameObjectWithTag("Game").GetComponent<Gameplay>();

        players = new List<int>();
        GameObject tmp = StoryCard.transform.GetChild(0).gameObject;
        card = Instantiate(tmp, parentTransform);
        card.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        card.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        card.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        counter = 0;
    }

    public void yes()
    {
        counter += 1;
        players.Add(game.currPlayer);
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
        //Destroy(card);
        game.CreateTournament(players);
        game.view.EndJoinTournament();
    }
}
