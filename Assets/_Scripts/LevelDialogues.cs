using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDialogues : MonoBehaviour
{
    public string currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        GetDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetDialogue()
    {
        switch(currentLevel)
        {
            case "Level1":
                Debug.Log("Calling Dialogue");
                DialogueSystem.Instance.AddNewDialogue(new string[] {"Alright listen up.","I need you to sneak past these two gaurds to grab the gem.","After you have snagged it, head to the vent and we'll meet you on the other side.","Good luck."}, "Radio partner");
                break;

            case "Level2":
                Debug.Log("Calling Dialogue");
                DialogueSystem.Instance.AddNewDialogue(new string[] {"Alright listen up.","The scout reported that security patrols here. You need to be carefull not to get caught.","Good luck."}, "Radio partner");
                break;

            default:
                //nothing
                break;    
        }
    }
}
