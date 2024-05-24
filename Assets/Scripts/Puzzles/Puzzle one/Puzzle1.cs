using Ink.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzle1 : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject wirePuzzle;
    [SerializeField] private Transform interactorSource;
    [SerializeField] GameObject uiPromptButton;
    [SerializeField] private float interactRange;

    public int Wirelevel;

    private void Start()
    {
        wirePuzzle.SetActive(false);
        Wirelevel = 0;
    }

    private void Update()
    {
        //IF RAY HITS UI SHOWS UP
        Ray r = new(interactorSource.position, interactorSource.forward);
        if (Physics.Raycast(r,interactRange) && Wirelevel == 1)
        {
            uiPromptButton.SetActive(true);
        }
        else
        {
            uiPromptButton.SetActive(false);
        }

        string answered = ((StringValue)Dialogue.GetInstance().GetVariableState("answered")).value;

        switch (answered)
        {
            case "":
                Wirelevel = 0; 
                break;
            case "no":
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

    public void Interact()
    {
        if (Wirelevel == 1)
        {
            WirePuzzle();
        }
        
    }
}
