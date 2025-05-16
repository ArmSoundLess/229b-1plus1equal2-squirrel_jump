using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void PlayGame()
    {
        SceneManager.LoadScene("InGame");
    }

    void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

}
