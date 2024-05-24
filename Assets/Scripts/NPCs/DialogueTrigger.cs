using UnityEngine;


public class DialogueTrigger : MonoBehaviour,IInteractable
{
    [SerializeField] private GameObject pressEUI;
    [SerializeField] private Transform interactorSource;
    [SerializeField] private float interactRange;
    [SerializeField] private TextAsset ink;

    private void Start()
    {
        pressEUI.SetActive(false);
    }
    private void Update()
    {
        Ray r = new(interactorSource.position, interactorSource.forward);
        if (Physics.Raycast(r, interactRange) && !Dialogue.GetInstance().dialogueIsPlaying)
        {
            pressEUI.SetActive(true);
        }
        else
            pressEUI.SetActive(false);

    }
    public void Interact()
    {
        if (!Dialogue.GetInstance().dialogueIsPlaying)
        {
            StartCoroutine(Dialogue.GetInstance().EnterDialogueMode(ink));
        }
        
    }
}
