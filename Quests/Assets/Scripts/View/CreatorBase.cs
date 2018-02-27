using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class CreatorBase<T>: MonoBehaviour where T : QuestOTRT.Card
{
    public GameObject[] prefabs;

    public virtual GameObject create(T card)
    {
        GameObject ret = null;
        foreach (GameObject prefab in prefabs)
        {
            if (prefab.name.ToLower().Equals(card.Name.ToLower()))
            {
                ret = Instantiate(prefab);
                ret.name = prefab.name;
                break;
            }
        }
        if (ret == null)
        {
            Debug.Log("Failed to create " + card.Name);
        }
        return ret;
    }
}
