using UnityEngine;

public class StaticDataManager : MonoBehaviour
{
    #region Instance
    public static StaticDataManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            if (instance != this)
                Destroy(gameObject);
            else
                instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }
    #endregion

    public const int MenuSceneIndex = 0;
    public const int GameSceenIndex = 1;

    public static float playerMoveSpeed = 5f;
    
    public static float minWaitTimeToSpawn = 5f;
    public static float timeToSpawnCoins = 10f;

    public static int highScore;
    public static int totalCoin;

    public static int health = 3;
    public static int currentCoins = 0;
    public static int currentScore = 0;
    public static int bullets = 60;
}