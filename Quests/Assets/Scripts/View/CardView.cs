using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestOTRT;

namespace QuestOTRT
{
    public class CardView : GameElement
    {
        public Vector3 initialScale;
        public Vector3 largeScale;
        public int index;

        void Start()
        {
            this.initialScale = new Vector3(0.5f, 0.5f, 0.5f);
            this.largeScale = new Vector3(0.6f, 0.6f, 0.6f);
            this.index = gameObject.transform.GetSiblingIndex();
        }

        public void ScaleUp()
        {
            transform.localScale = this.largeScale;
            transform.SetAsLastSibling();
        }

        public void ScaleDown()
        {
            transform.localScale = this.initialScale;
            transform.SetSiblingIndex(index);
        }
        
    }
}

