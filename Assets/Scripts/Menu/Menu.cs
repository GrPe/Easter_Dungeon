using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnSelectLevelClick()
    {
        SceneManager.LoadScene("SelectLevelMenu");
    }

    public void OnCreditsClick()
    {
        SceneManager.LoadScene("CreditsMenu");
    }

    public void OnExitClick()
    {
        Application.Quit();
    }

    public void OnReturnButtonClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnSelectLevelClick(int level)
    {
        SceneManager.LoadScene(level + 3); // + (main, selectlevel and credits) 
    }
}
