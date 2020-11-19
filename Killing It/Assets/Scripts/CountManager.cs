using UnityEngine;
using UnityEngine.UI;

public class CountManager : MonoBehaviour
{
    public Text coinCountText;
    public Text highScoreText;

    /*private void Start()
    {
        coinCountText.text = PlayerPrefs.GetInt("CoinCount", 0).ToString();
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }*/


    public void Update()
    {
        coinCountText.text = PlayerPrefs.GetInt("CoinCount", 0).ToString();
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
}
