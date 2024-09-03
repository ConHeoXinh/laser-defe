using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 1f;
    ScoreKeeper scoreKeeper;
     void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void LoadGame()
    {
        scoreKeeper.ResetScore();
        WaitAndLoad("game", sceneLoadDelay);
    }

    public void LoadMainMenu()
    {
        WaitAndLoad("MainMenu", sceneLoadDelay);
    }

    public void LoadOverGame()
    {
        StartCoroutine(WaitAndLoad("GameOver", sceneLoadDelay));

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
