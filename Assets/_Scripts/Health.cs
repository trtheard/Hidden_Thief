using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    private Vector3 respawnPosition;
    private Quaternion respawnRotation;
    public enum deathAction {loadLevelWhenDead, doNothingWhenDead};

    public float healthPoints = 1f;
    public float respawnHealthPoints = 1f; //base health points

    public int numberOfLives = 1;
    public bool isAlive = true;

    public GameObject spottedPrefab;
    public deathAction onLivesGone = deathAction.doNothingWhenDead;

    public string LevelToLoad = "";

    // Start is called before the first frame update
    void Start()
    {
        //store initial position as respawn location
        respawnPosition = transform.position;
        respawnRotation = transform.rotation;
        
        if (LevelToLoad=="") // default to current scene
        {
            LevelToLoad = Application.loadedLevelName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (healthPoints <= 0)    //If the object is dead
        {
            numberOfLives--;       //decrement # of lives, update lives GUI

            if (spottedPrefab!= null)
            {
                Instantiate (spottedPrefab, transform.position, Quaternion.identity);
            }

            if (numberOfLives > 0) //respawn
            {
                transform.position = respawnPosition;
                transform.rotation = respawnRotation;
                healthPoints = respawnHealthPoints;
            }
            else //here is where you do stuff once All lives are gone
            {
                isAlive = false;

                switch(onLivesGone)
                {
                    case deathAction.loadLevelWhenDead:
                        SceneManager.LoadScene(LevelToLoad);
                        break;
                    case deathAction.doNothingWhenDead:
                        //do nothing, death must be handled in another way elsewhere
                        break;
                }
                Destroy(gameObject);
            }
        }
    }

    public void ApplyDamage(float amount)
    {
        healthPoints = healthPoints - amount;
    }
    //For gaurds that allow the player to run away first
    public void ApplyHeal(float amount)
    {
        healthPoints = healthPoints + amount;
    }
    //Used for later levels
    //The level is set as if multiple theives have visited the establishment
    public void ApplyBonusLife(int amount)
    {
        numberOfLives = numberOfLives + amount;
    }
    public void updateRespawn(Vector3 newRespawnPosition, Quaternion newRespawnRotation)
    {
        respawnPosition = newRespawnPosition;
        respawnRotation = newRespawnRotation;
    }
}
