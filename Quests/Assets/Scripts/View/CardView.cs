using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardView : MonoBehaviour, IPointerEnterHandler, IDragHandler, IPointerExitHandler
{
    public Sprite face;
    public Sprite back;

    public Image image;
    public Vector3 initialScale;
    public Vector3 bigScale;

    public void toggleFace(bool show)
    {
        if (show)
        {
            image.sprite = face;
        }
        else
        {
            image.sprite = back;
        }
    }

    public void OnPointerEnter(PointerEventData pointer)
    {
        this.transform.localScale = bigScale;
    }

    public void OnPointerExit(PointerEventData pointer)
    {
        this.transform.localScale = initialScale;
    }

    public void OnDrag(PointerEventData pointer)
    {
        this.transform.localScale = bigScale;
    }

    private void Awake()
    {
        image = GetComponent<Image>();
        initialScale = this.transform.localScale;
        bigScale = initialScale + new Vector3(0.1f, 0.1f, 0.1f);
    }

}
