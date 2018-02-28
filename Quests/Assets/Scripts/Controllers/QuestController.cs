using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestOTRT
{
    public class QuestController : CardController<Quest>
    {
        public override void OnClick()
        {
            if (this.game.state == Game.gameState.Quest)
            {
                this.game.state = Game.gameState.startTurn;
                this.game.turn.removeAll();
                Destroy(gameObject);
            }
        }

    }
}
