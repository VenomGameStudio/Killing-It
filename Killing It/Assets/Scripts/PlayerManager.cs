using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public int health = 3;

    public GameObject life1, life2, life3;

    private void Start()
    {
        life1.SetActive(true);
        life2.SetActive(true);
        life3.SetActive(true);
    }

    private void Update()
    {
        switch (health)
        {
            case 3: 
                life3.SetActive(true);
                life2.SetActive(true);
                life1.SetActive(true);
                break;
            case 2:
                life3.SetActive(false);
                life2.SetActive(true);
                life1.SetActive(true);
                break;
            case 1:
                life3.SetActive(false);
                life2.SetActive(false);
                life1.SetActive(true);
                break;
            case 0:
                life3.SetActive(false);
                life2.SetActive(false);
                life1.SetActive(false);
                break;
            default:
                break;
        }

        if (health <= 0)
        {
            FindObjectOfType<PauseScript>().gameOverUI.SetActive(true);
            Time.timeScale = 0f;
            Destroy(gameObject);
        }
    }
}
