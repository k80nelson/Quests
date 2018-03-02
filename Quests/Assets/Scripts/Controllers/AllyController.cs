using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestOTRT {
    public class AllyController : CardController<Ally>
    {
        public void OnClick()
        {
            if (game.state == Game.gameState.Sponsorship) return;
            else base.OnClick();
        }
    }
}
