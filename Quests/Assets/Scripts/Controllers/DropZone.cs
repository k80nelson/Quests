using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Transform CardContainer;

    void Awake()
    {
        if (CardContainer == null)
        {
            CardContainer = transform;
        }
    }

    public virtual void OnPointerEnter(PointerEventData data)
    {
        if (data.pointerDrag == null) return;

        Draggable d = data.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            d.placeHolderParent = CardContainer;
        }
    }

    public void OnDrop(PointerEventData data)
    {
        Draggable d = data.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            if (isValid(d))
            {
                d.returnParent = CardContainer;
            }
        }
    }

    public void OnPointerExit(PointerEventData data)
    {
        if (data.pointerDrag == null) return;

        Draggable d = data.pointerDrag.GetComponent<Draggable>();
        if (d != null && d.placeHolderParent == CardContainer)
        {
            d.placeHolderParent = d.returnParent;
        }
    }

    bool isValid(Draggable d)
    {
        return true;
    }
}
