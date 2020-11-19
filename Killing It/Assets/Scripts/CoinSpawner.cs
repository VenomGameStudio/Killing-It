using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coin;
    public int coinCount = 0;
    public int totalCoin;
    public float respawnTime = 5f;

    private Vector2 screenBounds;

    void Start()
    {
        totalCoin = PlayerPrefs.GetInt("CoinCount", 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(CoinGen());
    }

    public void Update()
    {
        if (FindObjectOfType<PlayerManager>().health == 0)
        {
            totalCoin += coinCount;
            PlayerPrefs.SetInt("CoinCount", totalCoin);
        }
    }

    private void SpawnCoin()
    {
        GameObject c = Instantiate(coin) as GameObject;
        c.transform.position = new Vector2(Random.Range(-screenBounds.x + 5, screenBounds.x - 2), Random.Range(-screenBounds.y + 1, screenBounds.y - 1));
    }

    IEnumerator CoinGen()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnCoin();
        }
    }
}
