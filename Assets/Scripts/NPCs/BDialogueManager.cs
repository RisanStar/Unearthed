using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BDialogueManager : MonoBehaviour
{
    public Queue<string> sentences;

    private void Start()
    {
      sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting dialogue with " + dialogue.name);
    }
}
