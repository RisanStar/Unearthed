using Ink.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OldMan : MonoBehaviour, IInteractable
{
    private bool allowed;
    public bool started {  get; private set; }



    private void Update()
    {

        string collectTask = ((StringValue)Dialogue.GetInstance().GetVariableState("collectTask")).value;

        switch (collectTask)
        {
            case "":
                started = false;
                break;
            case "no":
                started = false;
                break;
            case "yes":
                started = true;
                break;
            default:
                Debug.LogWarning("Answer not handeled by switch statement: " + collectTask);
                break;
        }

        if (GameObject.FindWithTag("Firewood") == null)
        {
            allowed = true;
        }
        else
        {
            allowed = false;
        }
    }
    private void FlashBack()
    {
        if (allowed)
        {
            SceneManager.LoadScene("FlashBack");
        }

    }
 

    public void Interact()
    {
        FlashBack();
    }
}
