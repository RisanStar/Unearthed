using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzle1 : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject wirePuzzle;
    public Transform interactorSource;
    [SerializeField] GameObject uiPromptButton;
    public float interactRange;

    public int Wirelevel;

    private void Start()
    {
        wirePuzzle.SetActive(false);
    }

    private void Update()
    {
        //IF RAY HITS UI SHOWS UP
        Ray r = new Ray(interactorSource.position, interactorSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange) && Wirelevel == 1)
        {
            uiPromptButton.SetActive(true);
        }
        else
        {
            uiPromptButton.SetActive(false);
        }

        string answered = ((StringValue)Dialogue.GetInstance().GetVariableState("answer")).value;

        switch (answered)
        {
            case "":
                Wirelevel = 0; 
                break;
            case "yes":
                Wirelevel = 1;
                break;
            default:
                Debug.LogWarning("Answer not handeled by switch statement: " +  answered);
                break;
        }
    }
  
    private void WirePuzzle()
    {
        wirePuzzle.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        SceneManager.LoadScene("WirePuzzle");
    }

    public void SavePlayer()
    {
        SavePosition.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        PlayerData data = SavePosition.LoadPlayer();

        Wirelevel = data.Wirelevel;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
    }

    public void Interact()
    {
        if (Wirelevel == 1)
        {
            WirePuzzle();
            SavePlayer();
        }
        
    }
}
