using UnityEngine;
using TMPro;

public class UITextManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text bulletCount;
    public TMP_Text coinCount;
    
    void Update()
    {
        scoreText.text = FindObjectOfType<Weapon>().highScore.ToString();

        bulletCount.text = FindObjectOfType<Weapon>().bullets.ToString();

        coinCount.text = FindObjectOfType<CoinSpawner>().coinCount.ToString();
    }
}
