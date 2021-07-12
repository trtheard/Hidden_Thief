using System.Collections;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public static Exit em;
    public int value = 10;
    public bool hasEscaped = false;

    void Awake()
    {
		if (em == null) 
			em =gameObject.GetComponent<Exit>();
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //tell gm to collect
            hasEscaped = true;
            DialogueSystem.Instance.AddNewDialogue(new string[] {"Good Job, now lets get out of here."}, "Radio Partner");
        }
    }
}
