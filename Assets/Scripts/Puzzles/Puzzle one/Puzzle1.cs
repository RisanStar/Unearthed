using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1 : MonoBehaviour, IInteractable
{
    [SerializeField]private GameObject wirePuzzle;
    public Transform interactorSource;
    [SerializeField] GameObject uiPromptButton;
    public float interactRange;


    private void Start()
    {
        wirePuzzle.SetActive(false);
    }

    private void Update()
    {
        //IF RAY HITS UI SHOWS UP
        Ray r = new Ray(interactorSource.position, interactorSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
        {
            uiPromptButton.SetActive(true);
        }
        else
        {
            uiPromptButton.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.S) || (Input.GetKeyDown(KeyCode.D)))))
        {
            wirePuzzle.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

    }
  
    private void WirePuzzle()
    {
        wirePuzzle.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void Interact()
    {
        WirePuzzle();
    }
}
