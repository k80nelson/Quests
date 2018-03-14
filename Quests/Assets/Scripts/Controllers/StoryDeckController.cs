using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryDeckController : GameElement {

    public Transform CardTransform;
    public StoryDeckModel model;

    public void draw()
    {
        if (CardTransform.transform.childCount > 0) Destroy(CardTransform.transform.GetChild(0).gameObject);
        GameObject prefab = model.draw();
        GameObject card = Instantiate(prefab, CardTransform);
        card.name = prefab.name;

        if (card.GetComponent<QuestCard>() != null)
        {
            game.state.currCard = card.GetComponent<QuestCard>();
        }

        else if (card.GetComponent<TournamentCard>() != null)
        {
            game.state.currCard = card.GetComponent<TournamentCard>();
        }

        game.PlayStoryCard();
    }

    public void discard()
    {
        Destroy(CardTransform.transform.GetChild(0).gameObject);
        game.state.currCard = null; 
    }
}
