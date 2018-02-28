using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestOTRT
{
    public abstract class CardController<T> : GameElement where T : Card
    {

        public T card = null;
        public int index;


        public void initialize(T newCard)
        {
            if (card == null) card = newCard;
            index = gameObject.transform.GetSiblingIndex();
        }

        public void OnMouseExit()
        {
            transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
            transform.SetSiblingIndex(index);
        }

        public void OnMouseEnter()
        {
            index = gameObject.transform.GetSiblingIndex();
            transform.localScale += new Vector3(0.1F, 0.1f, 0.1f);
            transform.SetAsLastSibling();
        }

    }
}
