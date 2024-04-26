using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
   private static Dialogue instance;

    [SerializeField] private GameObject dialogueUI;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private DialogueTrigger trigger;
    [SerializeField] private float typingSpeed = 1f;

    [SerializeField] private GameObject[] choices;
    public Button choice0;
    public Button choice1;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;

    public KeyCode continueKey;

    public bool dialogueIsPlaying { get; private set; }

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


        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        if(!dialogueIsPlaying)
        {
            return; 
        }

        if (currentStory.currentChoices.Count == 0 && Input.GetKeyDown(continueKey)) 
        {
            StartCoroutine(ContinueStory());
        }
    }

    public void EnterDialogueMode(TextAsset ink)
    {
        currentStory = new Story(ink.text);

        dialogueIsPlaying = true;
        dialogueUI.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        

        StartCoroutine(ContinueStory());
    }

    private IEnumerator ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            DisplayChoices();
            choice0.interactable = false;
            choice1.interactable = false;
            yield return StartCoroutine(TypeText(dialogueText.text));
            choice0.interactable = true;
            choice1.interactable = true;

        }
        else
        {
            StartCoroutine(ExitDialogueMode());
          
        }
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(.1f);

        dialogueIsPlaying = false;
        dialogueUI.SetActive(false);
    
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        dialogueText.text = "";
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More Choices Given Than The Ui Can Support " + currentChoices.Count);
        }

        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[index].SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].SetActive(false);

        }

        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator TypeText(string text)
    {
        dialogueText.text = "";
        foreach (char letter in text.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }


    }

    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0]);
    }

    public void MakeChoice(int choiceIndex)
    {
      currentStory.ChooseChoiceIndex(choiceIndex);
        StartCoroutine(ContinueStory());
       
    }
}
