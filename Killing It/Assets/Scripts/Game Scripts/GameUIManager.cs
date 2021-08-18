using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class GameUIManager : MonoBehaviour
{
    public List<GameObject> lifesImage;

    public TMP_Text currentScoreText;
    public TMP_Text highScoreText;
    public TMP_Text bulletCount;
    public TMP_Text coinCount;

    private void Start()
    {
        foreach(GameObject life in lifesImage)
            life.SetActive(true);

        highScoreText.text = StaticDataManager.highScore.ToString();
    }

    void Update()
    {
        currentScoreText.text = StaticDataManager.currentScore.ToString();

        bulletCount.text = StaticDataManager.bullets.ToString();

        coinCount.text = StaticDataManager.currentCoins.ToString();
    }
}