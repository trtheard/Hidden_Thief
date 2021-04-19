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
                ShowExit();
            }

        Destroy(gameObject);
        
        }
    }
}
