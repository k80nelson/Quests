using System;

namespace QuestOTRT
{
    public class AI : GameElement
    {
        Strategy AIStrategy = null;

        public AI()
        {

        }

        private Strategy GetAIStrategy(string option)
        {
            //get the strategy selected by the user interface

            //find the proper strategy by what the user selected
            switch (option)
            {
               // case "strat1":
                   // AIStrategy = new Strategy1();
                   // break;
                case "strat2":
                    AIStrategy = new Strategy2(game.current.GetComponent<PlayerController>());
                    break;
                /*case "ourStrat":
                    AIStrategy = new QuickSort();
                    break;*/
                default:
                    break;
            }
            return AIStrategy;
        }
    }
}