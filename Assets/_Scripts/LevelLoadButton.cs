using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoadButton : MonoBehaviour
{
    public string LevelToLoad;

    public static LevelLoadButton LLButon;

    public void loadLevel()
    {
        SceneManager.LoadScene(LevelToLoad);
    }
}
