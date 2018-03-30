using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinSponsor : MonoBehaviour
{
    public Gameplay game;

    public GameObject StoryCard;
    public GameObject card;
    public Transform parentTransform;

    public int sponsor;
    public int counter;
    
    private void OnEnable()
    {
        Debug.Log("[JoinSponsor.cs:OnEnable] Initializing Join Sponsor");
        GameObject tmp = StoryCard.transform.GetChild(0).gameObject;
        card = Instantiate(tmp, parentTransform);
        card.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        card.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        card.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        counter = 0;
        sponsor = -1;
        Debug.Log("[JoinSponsor.cs:OnEnable] Initialization complete");
    }

    public void yes()
    {
        Debug.Log("[JoinSponsor.cs:yes] Quest sponsored by player " + (game.activePlayer + 1));
        sponsor = game.activePlayer;
        end();
    }

    public void no()
    {
        counter += 1;

        Debug.Log("[JoinSponsor.cs:no] Quest sponsorship refused by player " + (game.activePlayer + 1));
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
        Debug.Log("[JoinSponsor.cs:end] Join Sponsor complete");

        Destroy(card.gameObject);
        game.CreateSponsor(sponsor);
        game.view.EndJoinSponsor();
    }
}
