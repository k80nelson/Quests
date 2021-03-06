﻿using System.Collections;
using System.Collections.Generic;
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
        this.transform.SetParent(GameObject.FindGameObjectWithTag("ActiveArea").transform);
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
        //OR: on drop in dropzone

        //List<RaycastResult> results = new List<RaycastResult>();
        //EventSystem.current.RaycastAll(data, results);
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

    void adjustPlaceHolder()
    {
        placeHolder.transform.SetParent(placeHolderParent);

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
        placeHolder.transform.SetSiblingIndex(newIndex);
    }


}
