using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Ink.UnityIntegration;

public class Dialogue : MonoBehaviour
{
   private static Dialogue instance;

    [SerializeField] private GameObject dialogueUI;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private DialogueTrigger trigger;
    [SerializeField] private float typingSpeed = 1f;
    private bool typing;

    [SerializeField] private GameObject[] choices;
    public Button choice0;
    public Button choice1;
    private TextMeshProUGUI[] choicesText;

    private DialogueVariables dialogueVariables;

    private Story currentStory;
    [SerializeField] private InkFile globalsInkFile;

    public KeyCode continueKey;

    public bool dialogueIsPlaying { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found More Than One Dialogue In The Scene");
        }
        instance = this;

        dialogueVariables = new DialogueVariables(globalsInkFile.filePath);
    }

    public static Dialogue GetInstance()
    {
        return instance;
    }


    private void Start()
    {
        dialogueIsPlaying = false;
        dialogueUI.SetActive(false);
        typing = false;


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

        if (currentStory.currentChoices.Count == 0 && Input.GetKeyDown(continueKey) && !typing) 
        {
            StartCoroutine(ContinueStory());
        }
    }

    public IEnumerator EnterDialogueMode(TextAsset ink)
    {
        yield return new WaitForSeconds(.1f);
        currentStory = new Story(ink.text);

        dialogueIsPlaying = true;
        dialogueUI.SetActive(true);
        dialogueVariables.StartListening(currentStory);
        
        StartCoroutine(ContinueStory());
    }

    private IEnumerator ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            choice0.interactable = false;
            choice1.interactable = false;
            DisplayChoices();
            typing = true;
            yield return StartCoroutine(TypeText(dialogueText.text));
            typing = false;
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
        dialogueVariables.StopListening(currentStory);

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

    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        dialogueVariables.variables.TryGetValue(variableName, out variableValue);
        if (variableValue == null)
        {
            Debug.LogWarning("Ink Variable was found to be null: " + variableName);
        }
        return variableValue; 
    }
}
