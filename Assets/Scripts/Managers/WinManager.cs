using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    }

    public void OnButtonNextClick()
    {

    }
}
