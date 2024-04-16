using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class dialogueString
{
    //NPC TEXT
    public string text;
    public bool isEnd;
    public bool isQuestion;

    public string answerOption1;
    public string answerOption2;

    public int option1Index;
    public int option2Index;    


    public UnityEvent startDialogueEvent;
    public UnityEvent endDialogueEvent;
}
public class DialougePrompt : MonoBehaviour, IInteractable
{
    
    [SerializeField] private List<dialogueString> dialogueStrings = new List<dialogueString>();
    [SerializeField] private Transform NPCTransform;

    private bool hasSpoken = false;
    
    private void StartDialogue()
    {
        if (!hasSpoken)
        {
            gameObject.GetComponent<DialogueManager>().DialogueStart(dialogueStrings, NPCTransform);
            hasSpoken = true;
        }
    }
    
    public void Interact()
    {
       StartDialogue();
    }
    
}
