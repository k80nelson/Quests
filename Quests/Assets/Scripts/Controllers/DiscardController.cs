using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class DiscardController : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public AdventureDeckModel deck;
    public Gameplay game;
    public GameObject toRemove;
    public GameObject tmpCard;
    public GameObject confirm;
    private Transform orig;
    public Transform discard;
    
    public virtual void OnPointerEnter(PointerEventData data)
    {
       
    }

    public void OnDrop(PointerEventData data)
    {
        Draggable d = data.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            toRemove = d.gameObject;
            confirm.SetActive(true);
            tmpCard = Instantiate(toRemove, discard);
            tmpCard.transform.localPosition = new Vector2(0, 0);

        }
    }

    public void discardCard()
    {
        deck.discard(toRemove);
        game.players[game.activePlayer].GetComponent<PlayerController>().discardCard(toRemove);
    }

    public void OnPointerExit(PointerEventData data)
    {
       
    }

    public void yes()
    {
        discardCard();
        Destroy(tmpCard);
        confirm.SetActive(false);
    }

    public void no()
    {
        Destroy(tmpCard);
        confirm.SetActive(false);
    }

}
