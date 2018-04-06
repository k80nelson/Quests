using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName ="Card Dictionary", menuName = "Card Dictionary")]
public class CardDictionary : ScriptableObject {

    #region cardIndices

    /*
     
    -- ADVENTURE CARDS --

    - ALLIES - 

    00   -   King Arthur - 1
    01   -   King Pellinore - 1
    02   -   Merlin - 1
    03   -   Queen Guinevere - 1
    04   -   Queen Iseult - 1
    05   -   Sir Galahad - 1
    06   -   Sir Gawain - 1
    07   -   Sir Lancelot - 1
    08   -   Sir Percival - 1
    09   -   Sir Tristan - 1
    
    - FOES -

    10   -   Black Knight - 3
    11   -   Boar - 4
    12   -   Dragon - 1
    13   -   Evil Knight - 6
    14   -   Giant - 2
    15   -   Green Knight - 2
    16   -   Mordred - 4
    17   -   Robber Knight - 7
    18   -   Saxon Knight - 8
    19   -   Saxons - 5
    20   -   Thieves - 8

    - TESTS -

    21   -   Test of Morgan Le Fey - 2
    22   -   Test of Temptation - 2
    23   -   Test of the Questing Beast - 2
    24   -   Test of Valor - 2

    - WEAPONS -

    25   -   Battle-ax - 8
    26   -   Dagger - 6
    27   -   Excalibur - 2
    28   -   Horse - 11
    29   -   Lance - 6
    30   -   Sword - 16

    - AMOUR -

    31   -   Amour - 8

    -- STORY CARDS --

    - EVENTS -

    32   -   Chivalrous Deed - 1
    33   -   Court Called to Camelot - 2
    34   -   King's Call to Arms - 1
    35   -   King's Recognition - 2
    36   -   Plague - 1
    37   -   Pox - 1
    38   -   Prosperity Throughout the Realm - 1
    39   -   Queen's Favor - 2

    - QUESTS -

    40   -   Boar Hunt - 2
    41   -   Defend the Queen's Honor - 1
    42   -   Journey Through the Enchanted Forest - 1
    43   -   Repel the Saxon Raiders - 2
    44   -   Rescue the Fair Maiden - 1
    45   -   Search for the Holy Grail - 1
    46   -   Search for the Questing Beast - 1
    47   -   Slay the Dragon - 1
    48   -   Test of the Green Knight - 1
    49   -   Vanquish King Arthur's Enemies - 2

    - TOURNAMENTS -

    50   -   Tournament at Camelot - 1
    51   -   Tournament at Orkney - 1
    52   -   Tournament at Tintagel - 1
    53   -   Tournament at York - 1
    
    */

    #endregion

    [SerializeField]
    List<BaseCard> cards;

    Dictionary<BaseCard, int> indices;

    public void Awake()
    {
        indices = new Dictionary<BaseCard, int>();
    }

    public void Start()
    {
        for (int i=0; i<cards.Count; i++)
        {
            indices.Add(cards[i], i);
        }
    }

    public BaseCard findCard(int index)
    {
        return cards[index];
    }

    public int findIndex(string name)
    {
        BaseCard key = indices.Keys.ToList<BaseCard>().Find(i => i.name == name);
        if (key == null) return -2;
        return indices[key];
    }

}
