using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    [HideInInspector]
    public Health playerHealth;
    private Exit playerExit;

    [Tooltip("If not set, the player will default to the gameobject tagged as Player.")]
    public GameObject player;
    public GameObject exits;

    public enum gameStates {Playing, Caught, GameOver, WonLevel};
    public gameStates gameState = gameStates.Playing;

    public int score=0;
    public bool canBeatLevel = false;
    public int beatLevelScore=0;

    public GameObject mainCanvas;
    public GameObject gameOverCanvas;
    public Text gameOverTextDisplay;

    public AudioSource backgroundMusic;
    public AudioClip gameOverSFX;

    [Tooltip("Only need to set if canBeatLevel is true.")]
    public AudioClip beatLevelSFX;


    // Start is called before the first frame update
    void Start()
    {
        if(gm == null)
            gm = gameObject.GetComponent<GameManager>();

        if(player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        playerHealth = player.GetComponent<Health>();
        playerExit = exits.GetComponent<Exit>();

        //Setup Score Display
        //Collect(0);

        gameOverCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch(gameState)
        {
            case gameStates.Playing:
                if (playerHealth.isAlive == false)
                {
                    //update gamestate
                    gameState = gameStates.Caught;

                    //set the end game score
                    gameOverTextDisplay.text = "You got caught!";
                    //switch which GUi is Showing
                    mainCanvas.SetActive(false);
                    gameOverCanvas.SetActive(true);
                } 
                else if (canBeatLevel && score >= beatLevelScore && playerExit.hasEscaped)
                {
                    //update gameState
                    gameState = gameStates.WonLevel;

                    //hide the player so game doesn't continue playing
                    //player.SetActive(false);

                    //switch which GUI is showing
                    mainCanvas.SetActive(false);
                }
                break;
            case gameStates.Caught:

                backgroundMusic.volume -= 0.01f;
                if(backgroundMusic.volume <=0.0f)
                {
                    AudioSource.PlayClipAtPoint (gameOverSFX,gameObject.transform.position);

                    gameState = gameStates.GameOver;
                }
                break;
            case gameStates.WonLevel:

                    backgroundMusic.volume -= 0.01f;
                    if(backgroundMusic.volume <=0.0f)
                    {
                        AudioSource.PlayClipAtPoint (beatLevelSFX,gameObject.transform.position);

                        gameState = gameStates.GameOver;
                    }
                
                break;
            case gameStates.GameOver:
                //nothing
                break;
        }
    }

    public void Collect(int amount)
    {
        score+= amount;
        if(canBeatLevel)
        {
            IconTracker.it.changeGemAlpha(score);
        }
    }
}
