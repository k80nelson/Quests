using System;

namespace QuestOTRT {
    /*
     * View of MVC
     */
    public class View
    {
        int size;
        public Renderables[] renderables;

        //Render function contrained and called by all renderable objects
        //this will (most likely) call the .cs sripts from unity.
	    public render()
	    {
            /* 
             * this is where we will have a loop for the renderables of the MVC
             */
            for (int i = 0; i < size; i++)
            {
                renderables[i].draw();
            }
	    }
    }
}
