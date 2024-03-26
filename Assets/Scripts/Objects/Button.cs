using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour, IInteractable
{
    public Renderer button;
    [SerializeField] private Color newColor;
    [SerializeField] private Color[] colors;
    private int colorValue;
    public Transform interactorSource;
    [SerializeField] GameObject uiPromptButton;
    public float interactRange;
    private void Start()
    {
        uiPromptButton.SetActive(false);
    }

    private void Update()
    {
        Ray r = new Ray(interactorSource.position, interactorSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
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
        colorValue++;
        if(colorValue > 1)
        {
            colorValue = 0;
        }

        button.material.color = colors[colorValue];

    }
    public void Interact()
    {
        ChangeMaterial();
    }
}
