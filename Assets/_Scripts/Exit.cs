using System.Collections;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public int value = 10;
    public bool hasEscaped = false;

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(GameManager.gm !=null)
            {
                //tell gm to collect
                GameManager.gm.Collect(value);
                hasEscaped = true;
            }
        }
    }
}
