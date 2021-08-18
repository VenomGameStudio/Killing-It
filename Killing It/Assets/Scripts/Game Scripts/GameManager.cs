using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemySpawner;
    [SerializeField] private GameObject[] enemySpawnPaterns;
    [SerializeField] private GameObject coins;
    [SerializeField] private List<GameObject> lifes = new List<GameObject>();

    private Vector2 screenBounds;

    private void Awake() => instance = this;

    private void Start()
    {
        StaticDataManager.health = 3;
        Initilize();
    }

    private void Initilize()
    {
        lifes.Clear();
        foreach (GameObject obj in GetComponent<GameUIManager>().lifesImage)
            lifes.Add(obj);

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnCoins());
    }

    private IEnumerator SpawnEnemy()
    {
        int rand = Random.Range(0, enemySpawnPaterns.Length);
        GameObject obj = Instantiate(enemySpawnPaterns[rand], enemySpawner.transform) as GameObject;

        yield return new WaitForSeconds(StaticDataManager.minWaitTimeToSpawn);

        if (StaticDataManager.minWaitTimeToSpawn >= 1.5f)
            StaticDataManager.minWaitTimeToSpawn -= 0.1f;

        Destroy(obj);
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnCoins()
    {
        yield return new WaitForSeconds(StaticDataManager.timeToSpawnCoins);

        GameObject c = Instantiate(coins);
        c.transform.position = new Vector2(
            Random.Range(-screenBounds.x + 5, screenBounds.x - 2),
            Random.Range(-screenBounds.y + 1, screenBounds.y - 1));

        StartCoroutine(SpawnCoins());
    }

    public void DecreaseHealth()
    {
        lifes[StaticDataManager.health - 1].SetActive(false);
        lifes.RemoveAt(StaticDataManager.health - 1);
        StaticDataManager.health -= 1;
        
        if (StaticDataManager.health == 0)
        {
            AfterDeathProcess();
            FindObjectOfType<PauseScript>().gameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void AfterDeathProcess()
    {
        Destroy(player);

        StaticDataManager.totalCoin += StaticDataManager.currentCoins;
        PlayerPrefs.SetInt("CoinCount", StaticDataManager.totalCoin);

        if (StaticDataManager.currentScore > StaticDataManager.highScore)
            PlayerPrefs.SetInt("HighScore", StaticDataManager.currentScore);
    }
}