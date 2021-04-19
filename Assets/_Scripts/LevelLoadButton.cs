using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoadButton : MonoBehaviour
{
    public string LevelToLoad;

    public void loadLevel()
    {
        SceneManager.LoadScene(LevelToLoad);
    }
}
