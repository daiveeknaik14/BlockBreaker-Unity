using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadNextScene()
    {

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);

    }

    public void LoadStartScene()
    {
        FindObjectOfType<GameState>().resetGame();
        SceneManager.LoadScene(0);
    }
    public void LoadGameOverScene()
    {
        int x = SceneManager.sceneCount;
        SceneManager.LoadScene("WinScreen");
    }

}
