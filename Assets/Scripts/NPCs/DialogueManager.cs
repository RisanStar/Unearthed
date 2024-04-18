using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UIElements;
using UnityEditor.UI;

public class DialogueManager : MonoBehaviour
{
    //DIALOUGE OPTIONS AND TEXT
    [SerializeField] private GameObject dialogueParent;
    [SerializeField] private TMP_Text dialogueText;

    private Button option1Button;
    private Button option2Button;

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

    public void DialogueStart(List<dialogueString> textToPrint, Transform NPC)
    {
        dialogueParent.SetActive(true);
        playerMovement.enabled = false;

        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;

        StartCoroutine(TurnCameraTowardsNPC(NPC));

        dialogueList = textToPrint;
        currentDialogueIndex = 0;

        DisableButtons();

        StartCoroutine(PrintDialogue());

    }

    private void DisableButtons()
    {
        option1Button.enabled = false;
        option2Button.enabled = false;

        option1Button.GetComponentInChildren<TMP_Text>().text = "No Option";
        option2Button.GetComponentInChildren<TMP_Text>().text = "No Option";
 

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

                option1Button.GetComponentInChildren<TMP_Text>().text = line.answerOption1;
                option2Button.GetComponentInChildren<TMP_Text>().text = line.answerOption2;

                HandleOptionSelected(line.option1Index);
                HandleOptionSelected(line.option2Index);
                
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
    
    public void HandleOptionSelected(int indexJump)
    {
        optionSelected = false;
        DisableButtons();

        currentDialogueIndex = indexJump;
    }

    private IEnumerator TypeText(string text)
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

    private void DialogueStop()
    {
        StopAllCoroutines();
        dialogueText.text = "";
        dialogueParent.SetActive(false);

        playerMovement.enabled = true;

        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
    }
            
}
