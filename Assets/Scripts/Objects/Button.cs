using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour, IInteractable
{
    //BUTTON GAMEOBJ AND COLOUR VALUES + RANGE OF INTERACTION
    public Renderer button;
    [SerializeField] private Color newColor;
    [SerializeField] private Color[] colors;
    private int colorValue;
    public Transform interactorSource;
    [SerializeField] GameObject uiPromptButton;
    public float interactRange;
    internal object onClick;

    private void Start()
    {
        //UI DOESN'T SHOW UNTIL CLOSE
        uiPromptButton.SetActive(false);
    }

    private void FixedUpdate()
    {
        //IF RAY HITS UI SHOWS UP
        Ray r = new (interactorSource.position, interactorSource.forward);
        if (Physics.Raycast(r, interactRange))
        {
            uiPromptButton.SetActive(true);
        }
        else
        {
            uiPromptButton.SetActive(false);
        }
    }

    private void ChangeMaterial()
    {
        //CHANGES THE COLOUR OF THE BUTTON
        colorValue++;
        if(colorValue > 1)
        {
            colorValue = 0;
        }

        button.material.color = colors[colorValue];

    }
    public void Interact()
    {
        //IF THE PLAYER INTERACTS THE BUTTON CHANGES MATERIAL
        ChangeMaterial();
    }
}
