using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private Image gameOverMenu;
    [SerializeField] private Player player;

    private void Start()
    {
        player.OnPlayerDie += PlayerDie;
        gameOverMenu.gameObject.SetActive(false);
    }

    private void PlayerDie()
    {
        gameOverMenu.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnButtonMenuClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void OnButtonRetryClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
