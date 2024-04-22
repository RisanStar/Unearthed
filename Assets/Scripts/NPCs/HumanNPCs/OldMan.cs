using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OldMan : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject oldManDialogue;
    public Transform interactorSource;
    public float interactRange;

    private void Start()
    {
        oldManDialogue.SetActive(false);
    }

    private void Update()
    {
        Ray r = new Ray(interactorSource.position, interactorSource.forward);
        if (Physics.Raycast(r, interactRange))
        {
            oldManDialogue.SetActive(true);
        }
        else
        {
            oldManDialogue.SetActive(false);
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
