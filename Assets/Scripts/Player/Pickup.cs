using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour, IInteractable
{
    public Transform interactorSource;
    [SerializeField] private GameObject firewood;
    [SerializeField] GameObject uiPromptFirewood;
    public float interactRange;

    private void Start()
    {
        uiPromptFirewood.SetActive(false);
    }

    private void Update()
    {
        Ray r = new Ray(interactorSource.position, interactorSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
        {
            uiPromptFirewood.SetActive(true);
        }
        else
        {
            uiPromptFirewood.SetActive(false);
        }
    }
    public void Interact()
    {
        Destroy(firewood);
        
    }
}
