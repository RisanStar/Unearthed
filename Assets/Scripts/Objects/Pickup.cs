using UnityEngine;


public class Pickup : MonoBehaviour, IInteractable
{
    //FIREWOOD GAMEOBJ AND RANGE OF INTERACTION
    [SerializeField] private Transform interactorSource;
    [SerializeField] private GameObject firewood;
    [SerializeField] private GameObject uiPromptFirewood;
    [SerializeField] private float interactRange;

    private void Start()
    {
        //UI DOESN'T SHOW UNTIL CLOSE
        uiPromptFirewood.SetActive(false);
    }

    private void Update()
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
