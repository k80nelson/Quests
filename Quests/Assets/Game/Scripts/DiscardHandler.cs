using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DiscardHandler : MonoBehaviour, IDropHandler
{
    [SerializeField] GameObject confirm;
    [SerializeField] Transform discardTransform;

    GameObject toRemove;
    GameObject tmpCard;

    public void OnDrop(PointerEventData ptr)
    {
        Draggable d = ptr.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            toRemove = d.gameObject;
            confirm.SetActive(true);
            tmpCard = Instantiate(toRemove, discardTransform);
            tmpCard.transform.localPosition = new Vector3(0, 0, 0);
        }
    }

    public void yes()
    {
        Destroy(tmpCard);
        NetPlayerController.LocalPlayer.discard(toRemove);
        confirm.SetActive(false);
    }

    public void no()
    {
        Destroy(tmpCard);
        confirm.SetActive(false);
    }
}