using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OldMan : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject uiPromptOldMan;
    public Transform interactorSource;
    public float interactRange;

    private void Start()
    {

        uiPromptOldMan.SetActive(false);
    }

    private void Update()
    {
        Ray r = new(interactorSource.position, interactorSource.forward);
        if (Physics.Raycast(r, interactRange))
        {
            uiPromptOldMan.SetActive(true);
        }
        else
        {
            uiPromptOldMan.SetActive(false);
        }
    }
    private void FlashBack()
    {
        
        SceneManager.LoadScene("FlashBack");

    }
 

    public void Interact()
    {
        FlashBack();
    }
}
