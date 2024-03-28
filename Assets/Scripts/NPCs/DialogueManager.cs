using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;


public class DialogueManager : MonoBehaviour
{
    //DIALOUGE OPTIONS AND TEXT
    [SerializeField] private GameObject dialogueParent;
    [SerializeField] private TMP_Text dialogueText;

    [SerializeField] private Button option1Button;
    [SerializeField] private Button option2Button;
    [SerializeField] private Button option3Button;
    [SerializeField] private Button option4Button;

    //TYPING AND TURN SPEED
    [SerializeField] private float typingSpeed = .05f;
    [SerializeField] private float turnSpeed = 2f;

    //REFRENCE OF THE LIST OF DIALOUGE 
    private List<dialogueString> dialogueList;

    //REFRENCE TO PLAYER 
    [SerializeField] private PlayerMovement playerMovement;
    private Transform playerCamera;

    //ALLOWS FOR OPTIONS
    private int currentDialogueIndex = 0;

    private void Start()
    {
       dialogueParent.SetActive(false);
       playerCamera = Camera.main.transform;
       
    }

    private void DialougeStart(List<dialogueString> textToPrint, Transform NPC)
    {
        dialogueParent.SetActive(true);
        playerMovement.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        StartCoroutine(TurnCameraTowardsNPC());

        dialogueList = textToPrint;
        currentDialogueIndex = 0;

        DisableButtons();

        StartCoroutine(PrintDialogue());

    }

    private void DisableButtons()
    {
        option1Button.enabled = false;
        option2Button.enabled = false;
        option3Button.enabled = false;
        option4Button.enabled = false;

        option1Button.GetComponentInChildren<TMP_Text>().text = "No Option";
        option2Button.GetComponentInChildren<TMP_Text>().text = "No Option";
        option3Button.GetComponentInChildren<TMP_Text>().text = "No Option";
        option4Button.GetComponentInChildren<TMP_Text>().text = "No Option";

    }

    private IEnumerator TurnCameraTowardsNPC(Transform NPC)
    {
        Quaternion startRotation = playerCamera.rotation;
        Quaternion targetrotation = Quaternion.LookRotation(NPC.position - playerCamera.position);

        float elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            playerCamera.rotation = Quaternion.Slerp(startRotation, targetrotation, elapsedTime);
            elapsedTime += Time.deltaTime * turnSpeed;
            yield return null;
        }
        playerCamera.rotation = targetrotation;
    }

    private bool optionSelected = false;
    private IEnumerator PrintDialogue()
    {
        while(currentDialogueIndex < dialogueList.Count)
        {
            dialogueString line = dialogueList[currentDialogueIndex];

            line.startDialogueEvent?.Invoke();
            if (line.isQuestion)
            {
                yield return StartCoroutine(TypeText(line.text));
                option1Button.enabled = true;
                option2Button.enabled = true;
                option3Button.enabled = true;
                option4Button.enabled = true;

                option1Button.GetComponentInChildren<TMP_Text>().text = line.answerOption1;
                option2Button.GetComponentInChildren<TMP_Text>().text = line.answerOption2;
                option3Button.GetComponentInChildren<TMP_Text>().text = line.answerOption3;
                option4Button.GetComponentInChildren<TMP_Text>().text = line.answerOption4;

                option1Button.onClick.AddListener(() => HandleOptionSelected(line.option1Index));
                option2Button.onClick.AddListener(() => HandleOptionSelected(line.option2Index));
                option3Button.onClick.AddListener(() => HandleOptionSelected(line.option3Index));
                option4Button.onClick.AddListener(() => HandleOptionSelected(line.option4Index));

                yield return new WaitUntil(() => optionSelected);
            }
            else
            {
                yield return StartCoroutine(TypeText(line.text));
            }
            line.endDialogueEvent?.Invoke();
            optionSelected = false;
        }

        DialogueStop();
    }

    private void HandleOptionSelected(int indexJump)
    {
        optionSelected = true;
        DisableButtons();

        currentDialogueIndex = indexJump;
    }

    private IEnumerator typeText(string text)
    {
        dialogueText.text = "";
        foreach (char letter in text.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        if (!dialogueList[currentDialogueIndex].isQuestion)
        {
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        }
    }
            
}
