using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private Image gameOverMenu;
    [SerializeField] private Player player;

    private void Start()
    {
        gameOverMenu.gameObject.SetActive(false);
        player.OnPlayerDie += PlayerDie;
    }

    private void PlayerDie()
    {
        gameOverMenu.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnButtonMenuClick()
    {

    }

    public void OnButtonRetryClick()
    {

    }
}
