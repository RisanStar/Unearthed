using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    //DIALOUGE OPTIONS AND TEXT
    [SerializeField] private GameObject dialougeParent;
    [SerializeField] private TMP_Text dialougeText;

    [SerializeField] private Button option1Button;
    [SerializeField] private Button option2Button;
    [SerializeField] private Button option3Button;
    [SerializeField] private Button option4Button;

    //TYPING AND TURN SPEED
    [SerializeField] private float typingSpeeed = .05f;
    [SerializeField] private float turnSpeed = 2f;

    //REFRENCE OF THE LIST OF DIALOUGE 
    private List<dialogueString> dialogueList;

    //REFRENCE TO PLAYER 
    [SerializeField] private PlayerMovement playerMovement;
    private Transform playerCamera;

    //ALLOWS FOR OPTIONS
    private int currentDialougeIndex = 0;

    private void Start()
    {
       dialougeParent.SetActive(false);
       playerCamera = Camera.main.transform;
    }

    private void DialougeStart(List<dialogueString> textToPrint, Transform NPC)
    {
        dialougeParent.SetActive(true);
        playerMovement.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        StartCoroutine(TurnCameraTowardsNPC());

        dialogueList = textToPrint;
        currentDialougeIndex = 0;

        DisableButtons();

        StartCoroutine(printDialogue());

    }

    private void DisableButtons()
    {
        option1Button.interactable = false;
        option2Button.interactable = false;
        option3Button.interactable = false;
        option4Button.interactable = false;

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
}
