using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] float GameOverLoadDelaySeconds = 2f;

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadGameOver()
    {
        StartCoroutine(LoadGameOverAfterDelay());
    }

    IEnumerator LoadGameOverAfterDelay()
    {
        yield return new WaitForSeconds(GameOverLoadDelaySeconds);
        SceneManager.LoadScene("Game Over");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
