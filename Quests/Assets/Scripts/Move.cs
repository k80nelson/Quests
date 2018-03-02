using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    void clean()
    {
        move = move.Where(x => x != null).ToList();
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
            this.total += game.deck.getBP(obj.name.Substring(0, obj.name.Length - 2), names.ToArray());
        }
    }
    
    public bool isValid(GameObject card)
    {
        clean();
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

            foreach (GameObject card in move)
            {
                Debug.Log(card.GetComponent<WeaponController>().card);
            }
        }
	}

    public void Remove(GameObject card)
    {
        move.Remove(card);
        names.Remove(card.name.Substring(0, card.name.Length - 2));
    }
}
