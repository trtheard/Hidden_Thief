using System.Collections;
using UnityEngine;

public class Artifacts : MonoBehaviour
{
    public int value = 10;
    public bool hasArtifact;

    private GameManager gm;
    public GameObject exits;

    void ShowExit()
    {
        if(hasArtifact)
        {
            IconTracker.it.changeVentAlpha();
            exits.gameObject.SetActive(true);
        }
        else
        {
            exits.gameObject.SetActive(false);
        }
        
    }
    
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(GameManager.gm !=null)
            {
                //tell gm to collect
                GameManager.gm.Collect(value);
                hasArtifact = true;
                //Check if the player collected all the artifacts in the scene
                ShowExit();
            }

        Destroy(gameObject);
        
        }
    }
}
