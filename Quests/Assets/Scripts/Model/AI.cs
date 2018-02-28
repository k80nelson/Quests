using System;

namespace QuestOTRT
{
    public class AI
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
               // case "":
                   // AIStrategy = new Strategy1();
                   // break;
                case "":
                    AIStrategy = new Strategy2();
                    break;
                /*case ObjectToSort.CountyResidents:
                    AIStrategy = new QuickSort();
                    break;*/
                default:
                    break;
            }
            return AIStrategy;
        }
    }
}