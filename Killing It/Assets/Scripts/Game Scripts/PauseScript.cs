using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class PauseScript : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject pauseMenuUI;
    public GameObject gameOverUI;

    void Update()
    {
        if (CrossPlatformInputManager.GetButton("Pause"))
        {
            if (GameIsPause)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(StaticDataManager.MenuSceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        ResetStats();
        SceneManager.LoadSceneAsync(StaticDataManager.GameSceenIndex);
    }

    private void ResetStats()
    {
        StaticDataManager.health = 3;
        StaticDataManager.bullets = 60;
        StaticDataManager.currentScore = 0;
        StaticDataManager.currentCoins = 0;
        StaticDataManager.minWaitTimeToSpawn = 5f;
        StaticDataManager.timeToSpawnCoins = 10f;
    }
}