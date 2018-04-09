using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Transform CardContainer;
    public enum ScrollType { HORIZONTAL, VERTICAL };

    public ScrollType direction = ScrollType.HORIZONTAL;


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
            d.direction = direction;
        }
    }

    public virtual void OnDrop(PointerEventData data)
    {
        Draggable d = data.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            if (isValid(d))
            {
                d.returnParent = CardContainer;
                d.direction = direction;
            }
        }
    }

    public virtual void OnPointerExit(PointerEventData data)
    {
        if (data.pointerDrag == null) return;

        Draggable d = data.pointerDrag.GetComponent<Draggable>();
        if (d != null && d.placeHolderParent == CardContainer)
        {
            d.placeHolderParent = d.returnParent;
            d.direction = ScrollType.HORIZONTAL;
        }
    }

    protected virtual bool isValid(Draggable d)
    {
        return true;
    }
}

