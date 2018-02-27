using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class CreatorBase<T>: MonoBehaviour where T : QuestOTRT.Card
{
    public GameObject prefab;
    public Sprite[] sprites;

    public virtual void create(T card)
    {
        Sprite display = sprites[0];
        foreach (Sprite sp in sprites)
        {
            if (sp.ToString().Contains(card.Name))
            {
                display = sp;
                break;
            }
        }
        Debug.Log(card.Name);
        GameObject newcard = Instantiate(prefab);
        SpriteRenderer sr = newcard.GetComponent<SpriteRenderer>();
        sr.sprite = display;
    }
}
