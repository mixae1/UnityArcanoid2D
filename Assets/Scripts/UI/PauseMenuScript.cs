using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public PlayerScript player;
    private PauseManager pauseManager;
    public GameObject pauseMenu;
    private UIManager uiManager;
    private void Start()
    {
        pauseManager = PauseManager.Instance();
        uiManager = UIManager.Instance();
        Resume();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseManager.paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        pauseManager.paused = false;
        Time.timeScale = 1f;
    }
    void Pause()
    {
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        pauseManager.paused = true;
        Time.timeScale = 0f;
    }
    public void Restart()
    {
        player.gameData.Reset();
        SceneManager.LoadScene("MainScene");
    }
    public void QuitToMainMenu()
    {
        uiManager.AddScoreLine(player.gameData.points);
        uiManager.showQuitButton = true;
        player.gameData.Save();
        SceneManager.LoadScene("MainMenuScene");
    }
}
