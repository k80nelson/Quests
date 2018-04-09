using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.EventSystems;


public class DeckController : NetworkBehaviour, IDropHandler//, IPointerEnterHandler, IPointerExitHandler
{

    #region singleton
    public static DeckController instance;
    #endregion

    public Deck advDeck;
    public Deck storyDeck;

    public GameObject toRemove;
    public GameObject tmpCard;
    public Transform discardTransform;

    private void Start()
    {
        instance = this;
    }
    
    public List<int> drawAdvCards(int num)
    {
        return advDeck.drawMany(num);
    }

    //when player drops a card over the discard area
    public void OnDrop(PointerEventData data)
    {
        Debug.Log("In the on drop function to remove a card");
        Draggable d = data.pointerDrag.GetComponent<Draggable>();
        Debug.Log(d);
        if (d != null)
        {
            Debug.Log("d was not null");
            Debug.Log("The name of the to discard is " + d.gameObject.name);
            toRemove = d.gameObject;
            //confirm.SetActive(true);
            tmpCard = Instantiate(toRemove, discardTransform);
            tmpCard.transform.localPosition = new Vector2(0, 0);
            discardCard();
        }
    }

    public void discardCard()
    {
        //deck .discard(toRemove);
        //game.players[game.activePlayer].GetComponent<PlayerController>().discardCard(toRemove);
    }


    //discarding cards hopefully
    public void discard()
    {
        //if (!isLocalPlayer) return;

        Debug.Log("[StoryDeckController.cs::discard] Story card discarded");
        //Destroy(CardTransform.transform.GetChild(0).gameObject);
    }

}
