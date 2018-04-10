using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtonManager : MonoBehaviour {

    public Button rmBtn;
    public Button adBtn;

    public GameObject player3;
    public GameObject player4;

    public Text text;
    int numActive = 2;

    public Globals global;

    public Dropdown[] choices;
    

    public void removeBtn()
    {
        numActive -= 1;
        switch (numActive)
        {
            case 3:
                text.text = "3"; //Sets the display text in the choose player menu to 3
                adBtn.interactable = true;
                player4.SetActive(false);
                break;
            case 2:
                text.text = "2"; //Sets the display text in the choose player menu to 2
                rmBtn.interactable = false;
                player3.SetActive(false);
                break;
            default:
                break;
        }
    }

    public void addBtn()
    {
        numActive += 1;
        switch (numActive)
        {
            case 3:
                text.text = "3"; //Sets the display text in the choose player menu to 3
                player3.SetActive(true);
                rmBtn.interactable = true;
                break;
            case 4:
                text.text = "4"; //Sets the display text in the choose player menu to 4
                player4.SetActive(true);
                adBtn.interactable = false;
                break;
            default:
                adBtn.interactable = false;
                break;
        }
    }

    public void quit()
    {
        Application.Quit();
    }

    public void playBtn()
    {
        global.numPlayers = numActive;
        global.choices = new int[numActive];
        for(int i=0; i<numActive; i++)
        {
            global.choices[i] = choices[i].value;
        }
        StartCoroutine(LoadYourAsyncScene());
    }

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background at the same time as the current Scene.
        //This is particularly good for creating loading screens. You could also load the Scene by build //number.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Game");

        //Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
