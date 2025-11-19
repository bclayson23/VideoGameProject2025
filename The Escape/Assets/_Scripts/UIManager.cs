using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject gameOverUI;
    public GameObject winUI;

    // global flag for UI mode
    public static bool isUIActive = false;

    void Start()
    {
        ShowScreen(mainMenuUI);
        Time.timeScale = 0f; // pause game for menu
    }

    private void Update()
    {
        Debug.Log("Cursor.visible: " + Cursor.visible + " | lockState: " + Cursor.lockState);
    }


    public void StartGame()
    {
        HideAllScreens();
        Time.timeScale = 1f;
        isUIActive = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ShowGameOver()
    {
        ShowScreen(gameOverUI);
        Time.timeScale = 0f;
    }

    public void ShowWinScreen()
    {
        ShowScreen(winUI);
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

    // ---------------- Helper Methods ---------------- //

    private void ShowScreen(GameObject screen)
    {
        HideAllScreens();
        screen.SetActive(true);

        // tell player movement to stop locking cursor
        isUIActive = true;

        // just in case
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void HideAllScreens()
    {
        mainMenuUI.SetActive(false);
        gameOverUI.SetActive(false);
        winUI.SetActive(false);
    }

    private void SetCursor(bool visible)
    {
        Cursor.visible = visible;
        Cursor.lockState = visible ? CursorLockMode.None : CursorLockMode.Locked;
    }
}
