using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool transmit = false;

    void Update()
    {
        if (transmit)
        {
            PlayGame();
        }
    }

    public void PlayGame()
    {
        transmit = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
