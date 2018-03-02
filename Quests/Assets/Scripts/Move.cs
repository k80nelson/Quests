using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestOTRT;

public class Move : GameElement {

    public List<GameObject> move;
    public List<string> names;
    public int total;
	
	void Start () {
        move = new List<GameObject>();
        names = new List<string>();
        total = 0;
    }

    public void Add(GameObject card)
    {
        move.Add(card);
        names.Add(card.name.Substring(0, card.name.Length - 2));
    }

    public void discardWeapons()
    {
        List<GameObject> tmp = move.FindAll(x => x.tag == "Weapon");
        foreach (GameObject obj in tmp)
        {
            Remove(obj);
        }

        gameObject.GetComponent<PlayerController>().playMove(tmp);
    }

    public void totalBP()
    {
        foreach(GameObject obj in move)
        {

            if (obj.tag == "Weapon")
            {
                total += obj.GetComponent<WeaponController>().card.getBP(names.ToArray());
            }
            if (obj.tag == "Foe")
            {
                total += obj.GetComponent<FoeController>().card.getBP(names.ToArray());
            }
            if (obj.tag == "Ally")
            {
                total += obj.GetComponent<AllyController>().card.getBP(names.ToArray());
            }
            if (obj.tag == "Test")
            {
                total += obj.GetComponent<TestController>().card.getBP(names.ToArray());
            }
            if (obj.tag == "Amour")
            {
                total += obj.GetComponent<AmourController>().card.getBP(names.ToArray());
            }
        }
    }
    
    public bool isValid(GameObject card)
    {
        if (card.tag == "Weapon")
        {
            List<GameObject> tmp = move.FindAll(x => x.tag == "Weapon");
            foreach(GameObject obj in tmp)
            {
                if (obj.name.Contains(card.name.Substring(0, card.name.Length - 2)))
                {
                    return false;
                }
            }
            return true;
        }
        if (card.tag == "Amour")
        {
            List<GameObject> tmp = move.FindAll(x => x.tag == "Amour");
            if (tmp.Count > 0) return false;
        }

        return true;
    }
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.J))
        {
            string tmp = "";
            foreach (string name in names)
            {
                tmp += name + ", ";
            }
            Debug.Log(tmp);
        }
	}

    public void Remove(GameObject card)
    {
        move.Remove(card);
        names.Remove(card.name.Substring(0, card.name.Length - 2));
    }
}
