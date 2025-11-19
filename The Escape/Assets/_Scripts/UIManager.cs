using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject gameOverUI;
    public GameObject winUI;

    void Start()
    {
        // Show main menu when game starts
        mainMenuUI.SetActive(true);
        gameOverUI.SetActive(false);
        winUI.SetActive(false);

        Time.timeScale = 0f; // pause gameplay on menu
    }

    public void StartGame()
    {
        mainMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ShowGameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ShowWinScreen()
    {
        winUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
