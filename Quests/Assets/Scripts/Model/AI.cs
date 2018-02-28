using System;

namespace QuestOTRT
{
    public class AI
    {
        Strategy AIStrategy = null;

        public AI()
        {

        }

        private static Strategy GetAIStrategy(Strategy strategy)
        {
            Strategy option = null;
            //get the strategy selected by the user interface


            //find the proper strategy by what the user selected
            switch (option)
            {
                case ObjectToSort.StudentNumber:
                    AIStrategy = new Strategy1();
                    break;
                case ObjectToSort.RailwayPassengers:
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