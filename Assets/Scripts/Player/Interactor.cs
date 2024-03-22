using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//WHAT AN INTERACTABLE OBJ WILL INHERIT
interface IInteractable
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    //WHERE THE RAYCAST IS CAST FROM
    public Transform interactorSource;
    public float interactRange;

    public KeyCode interactKey = KeyCode.E;

    private void FixedUpdate()
    {
        //IF THE PLAYER IS PRESSING E SHOOT A RAYCAST IN THAT DIRECTION
        if (Input.GetKeyDown(interactKey))
        {
            Ray r = new Ray(interactorSource.position, interactorSource.forward);
            if(Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
            {
                //IF IT HITS THE RAY WILL TRY GET AN INTERFACE OF THAT OBJECT
                if(hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactobj))
                {
                    interactobj.Interact();
                }
            }
        }
    }
}
