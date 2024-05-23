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
    [SerializeField] private Transform interactorSource;
    [SerializeField] private float interactRange;

    private LayerMask IgnoreRaycast;
    
    //INTERACT KEY
    private KeyCode interactKey = KeyCode.E;

    private void Start()
    {
        IgnoreRaycast = ~IgnoreRaycast;
    }
    private void Update()
    {
        //FROM THE FRONT OF THE PLAYER SHOOT A RAYCAST IN THAT DIRECTION WHEN PRESSING E
         if (Input.GetKeyDown(interactKey)) 
        {
               Ray r = new (interactorSource.position, interactorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange, IgnoreRaycast))
            {
                //IF IT HITS THE RAY WILL TRY GET AN INTERFACE OF THAT OBJECT 
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactobj))
                { 
                    interactobj.Interact();
                }
            }
            
        }
    }


}
