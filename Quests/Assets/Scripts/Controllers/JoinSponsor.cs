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
        GameObject tmp = StoryCard.transform.GetChild(0).gameObject;
        card = Instantiate(tmp, parentTransform);
        card.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        card.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        card.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        counter = 0;
        sponsor = -1;
    }

    public void yes()
    {
        sponsor = game.activePlayer;
        end();
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
        Destroy(card.gameObject);
        game.CreateSponsor(sponsor);
        game.view.EndJoinSponsor();


        // this is where we whill have to activate the droppable area for the players cards that they want to sponsor and activates a button.
        //also would need to have a button that allows the sponsor to move to the next stage.. 
        
    }
}
