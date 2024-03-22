using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, IInteractable
{
    public GameObject button;

    private void Start()
    {
       var buttoncolour = button.GetComponent<Renderer>();
    }
    public void Interact()
    {

    }
}
