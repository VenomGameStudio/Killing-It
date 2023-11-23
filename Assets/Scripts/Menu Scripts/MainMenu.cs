using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text highScoreText;
    [SerializeField] private Text totalCoinText;

    private void OnEnable()
    {
        StaticDataManager.highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = StaticDataManager.highScore.ToString();

        StaticDataManager.totalCoin = PlayerPrefs.GetInt("CoinCount");
        totalCoinText.text = StaticDataManager.totalCoin.ToString();
    }

    public void PlayGame()
    {
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

    public void QuitGame()
    {
        Application.Quit();
    }
}
