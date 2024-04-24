using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ink.Runtime;

public class Dialogue : MonoBehaviour
{
   private static Dialogue instance;

    [SerializeField] private GameObject dialogueUI;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private Story currentStory;

    private bool dialogueIsPlaying;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found More Than One Dialogue In The Scene");
        }
        instance = this;
    }

    public static Dialogue GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialogueUI.SetActive(false);
    }

    private void Update()
    {
        if(!dialogueIsPlaying)
        {
            return; 
        }

        if (Input.GetButtonDown("E"))
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset ink)
    {
        currentStory = new Story(ink.text);
        dialogueIsPlaying = true;
        dialogueUI.SetActive(true);

        ContinueStory();
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialogueUI.SetActive(false);
        dialogueText.text = "";
    }
}
