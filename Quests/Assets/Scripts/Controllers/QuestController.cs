using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestOTRT
{
    public class QuestController : CardController<Quest>
    {
        public void OnClick()
        {
            if (this.game.state == Game.gameState.Sponsorship)
            {
                this.game.state = Game.gameState.startTurn;
                Destroy(gameObject);
            }
        }
    }
}
