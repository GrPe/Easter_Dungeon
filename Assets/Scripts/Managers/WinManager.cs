using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinManager : MonoBehaviour
{
    [SerializeField] private Image gameWinMenu;
    [SerializeField] private EndPoint endPoint;

    private void Start()
    {
        endPoint.OnPlayerWin += PlayerWin;
        gameWinMenu.gameObject.SetActive(false);
    }

    private void PlayerWin()
    {
        gameWinMenu.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnButtonMenuClick()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnButtonNextClick()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (sceneIndex < SceneManager.sceneCountInBuildSettings - 1)
            SceneManager.LoadScene(sceneIndex + 1);
        else
            SceneManager.LoadScene("CreditsMenu");
    }
}
