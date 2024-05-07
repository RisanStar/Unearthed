using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class Pickup : MonoBehaviour, IInteractable
{
    //FIREWOOD GAMEOBJ AND RANGE OF INTERACTION
    public Transform interactorSource;
    [SerializeField] private GameObject firewood;
    [SerializeField] GameObject uiPromptFirewood;
    public float interactRange;

    private void Start()
    {
        //UI DOESN'T SHOW UNTIL CLOSE
        uiPromptFirewood.SetActive(false);
    }

    private void FixedUpdate()
    {
        //IF RAY HITS OBJ THE UI SHOWS UP
        Ray r = new (interactorSource.position, interactorSource.forward);
        if (Physics.Raycast(r,interactRange))
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
        //GET RID OF FIREWOOD
        Destroy(firewood);
        
    }
}
