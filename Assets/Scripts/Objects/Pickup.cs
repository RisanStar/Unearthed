using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject firewood;
    public void Interact()
    {
         Destroy(firewood);
    }
}
