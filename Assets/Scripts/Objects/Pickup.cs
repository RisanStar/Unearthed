using System.Collections;
using UnityEngine;


public class Pickup : MonoBehaviour, IInteractable
{
    //FIREWOOD GAMEOBJ AND RANGE OF INTERACTION
    [SerializeField] private Transform interactorSource;
    [SerializeField] private GameObject gObject;
    [SerializeField] private GameObject gObjectUI;
    [SerializeField] private float interactRange;

    private void Start()
    {
        //UI DOESN'T SHOW UNTIL CLOSE
        gObjectUI.SetActive(false);
    }

    private void Update()
    {
        //IF RAY HITS OBJ THE UI SHOWS UP
        Ray r = new(interactorSource.position, interactorSource.forward);
        if (Physics.Raycast(r, interactRange))
        {
            gObjectUI.SetActive(true);
        }
        else
        {
            gObjectUI.SetActive(false);
        }
    }

    public void Interact()
    {
        //GET RID OF GAMEOBJECT
        Destroy(gObject);
    }
}
