using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BDialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<BDialogueManager>().StartDialogue(dialogue);
    }
}
