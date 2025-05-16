using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public string endGameScene = "EndGameScene";

    void OnTriggerEnter2D(Collider2D collider2d)
    {
        if (collider2d.CompareTag("Player"))
        {
            EndGame();
        }
    }

    void EndGame()
    {
        Debug.Log("End Game Triggered");
        SceneManager.LoadScene(endGameScene);
    }
}
