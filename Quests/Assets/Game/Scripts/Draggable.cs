using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform returnParent = null;      
    public Transform placeHolderParent = null;
    GameObject placeHolder = null;
    LayoutElement layout = null;
    RectTransform rect = null;
    public bool draggable = true; 
    public DropZone.ScrollType direction = DropZone.ScrollType.HORIZONTAL; // For placeholder placement

    void Awake()
    {
        layout = GetComponent<LayoutElement>();
        rect = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData data)
    {
        if (!draggable) return;
        returnParent = this.transform.parent;
        setPlaceHolder();
        this.transform.SetParent(GameManager.instance.getActiveArea());
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData data)
    {
        if (!draggable) return;
        this.transform.position = data.position;
        adjustPlaceHolder();
    }

    public void OnEndDrag(PointerEventData data)
    {
        if (!draggable) return;
        this.transform.SetParent(returnParent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        transform.SetSiblingIndex(placeHolder.transform.GetSiblingIndex());

        Destroy(placeHolder);
    }

    void setPlaceHolder()
    {
        placeHolder = new GameObject();
        placeHolder.name = "PlaceHolder";
        placeHolderParent = returnParent;
        placeHolder.transform.SetParent(this.transform.parent);
        LayoutElement le = placeHolder.AddComponent<LayoutElement>();
        RectTransform rt = placeHolder.GetComponent<RectTransform>();

        le.preferredHeight = layout.preferredHeight;
        le.preferredWidth = layout.preferredWidth;
        le.flexibleHeight = layout.flexibleHeight;
        le.flexibleWidth = layout.flexibleWidth;

        rt.sizeDelta = rect.sizeDelta;

        placeHolder.transform.SetSiblingIndex(transform.GetSiblingIndex());
    }

    int adjustVert()
    {
        int newIndex = placeHolderParent.childCount;
        for (int i = 0; i < placeHolderParent.childCount; i++)
        {
            if (this.transform.position.y > placeHolderParent.GetChild(i).transform.position.y)
            {
                newIndex = i;
                if (placeHolder.transform.GetSiblingIndex() < newIndex)
                {
                    newIndex--;
                }
                break;
            }
        }
        return newIndex;
    }

    int adjustHoriz()
    {
        int newIndex = placeHolderParent.childCount;
        for (int i = 0; i < placeHolderParent.childCount; i++)
        {
            if (this.transform.position.x < placeHolderParent.GetChild(i).transform.position.x)
            {
                newIndex = i;
                if (placeHolder.transform.GetSiblingIndex() < newIndex)
                {
                    newIndex--;
                }
                break;
            }
        }
        return newIndex;
    }

    void adjustPlaceHolder()
    {
        placeHolder.transform.SetParent(placeHolderParent);

        int newIndex = 0;
        if (direction == DropZone.ScrollType.VERTICAL) newIndex = adjustVert();
        else newIndex = adjustHoriz();
        placeHolder.transform.SetSiblingIndex(newIndex);
    }


}
