using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestOTRT
{

    public class QuestController : MonoBehaviour
    {
        private int sponsorBP;
        private int playerBP;

        //Used to sponsor a quest, although I believe this is implemented elsewhere
        public void sponsor(PlayerModel player)
        {

        }

        //Used for the player to play the cards they want for a stage, this may need to be its own class similar to sponsor
        public void stage(PlayerModel player)
        {

        }

        //Used to calculate the BP for the stage, youll pass it the appropriate list of cards. See stage model is passed and not setup model!
        public int calculateBP(StageModel player)
        {
            int BP = 0;

            for (int i = 0; i < player.Count; i++)
            {
                BP += player.cardsPlayed[i].getBP();
            }

            return BP;
        }

        //Returns true for passing the stage, false for failing the stage
        public bool compareBP(int sponsorBP, int playerBP)
        {
            if (playerBP >= sponsorBP) return true;
            return false;
        }

        //Will be the actual brain of the quest
        public void play(QuestCard quest, int numPlayers)
        {
            int numStages = quest.stages;
            int currentStage = 0;

            SetupModel sponsor = new SetupModel(); //This will change later

            for(int i = 0; i < numPlayers; ++i)
            {

            }
            SetupModel player = new SetupModel(); //This will change later



            //Used later to actually resolve each stage
            sponsorBP = calculateBP(sponsor.stageSetup[currentStage]);
            playerBP = calculateBP(player.stageSetup[currentStage]);
            compareBP(sponsorBP, playerBP);
        }
    }
}