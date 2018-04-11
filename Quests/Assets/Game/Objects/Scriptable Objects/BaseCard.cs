using UnityEngine;
using System;

[Serializable]
public class BaseCard : ScriptableObject {

    new public string name = "Card";
    public Sprite image = null;
    public int index;
}
