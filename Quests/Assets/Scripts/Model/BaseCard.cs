using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCard : MonoBehaviour
{

    public string Name;

    public bool Equals(BaseCard other)
    {
        return (Name == other.Name);
    }

    public bool Equals(string other)
    {
        return (Name == other);
    }

}