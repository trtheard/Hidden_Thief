using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem Instance;
    public List<string> dialogueLines = new List<string>();
    public string npcName;
    public GameObject dialoguePanel;
    public GameObject panelActive;
    public string interactedName;
    public string LevelToLoad;

    //Private variables below
    Text dialogueText, nameText;
    int dialgueIndex;
    Controller _charController;
    bool continued;

    
    //use for initialization
    void Awake()
    {
        dialogueText = dialoguePanel.transform.Find("Dialogue").GetComponent<Text>();
        nameText = dialoguePanel.transform.Find("Name").GetComponent<Text>();
        _charController = GameObject.FindObjectOfType<Controller>();
        dialoguePanel.SetActive(false);

		if (Instance == null) 
			Instance = this.gameObject.GetComponent<DialogueSystem>();
    }

    void Update()
    {
        if(!continued)
        {
            if(Input.GetKey(KeyCode.Return))
            {
                continued = true;
                continueDialogue();
            }
        }
    }

    public void GetInteracted(string intName)
    {
        interactedName = intName;
    }

    public void AddNewDialogue(string[] lines, string npcName)
    {
        dialgueIndex = 0;
        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);
        this.npcName = npcName;
        createDialogue();
    }

    public void createDialogue()
    {
        dialogueText.text = dialogueLines[dialgueIndex];
        nameText.text = npcName;
        dialoguePanel.SetActive(true);
    }

    public void continueDialogue()
    {
        if (dialgueIndex < dialogueLines.Count - 1)
        {
            dialgueIndex++;
            Debug.Log("dialogue index: " + dialgueIndex);
            dialogueText.text = dialogueLines[dialgueIndex];
            continued = false;
        }
        else
        {
            Debug.Log("End of conversation");
            dialogueLines.Clear();
            dialoguePanel.SetActive(false);
            continued = false;
            if(Exit.em != null)
            {
                if(Exit.em.hasEscaped)
                {
                    if(GameManager.gm != null)
                    {
                        GameManager.gm.Collect(10);
                        SceneManager.LoadScene(LevelToLoad);
                    }
                }
            }
        }
    }
}
