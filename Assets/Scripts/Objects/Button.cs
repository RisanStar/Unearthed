using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, IInteractable
{
    public Renderer button;
    [SerializeField] private Color newColor;
    [SerializeField] private Color[] colors;
    private int colorValue;
    
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
