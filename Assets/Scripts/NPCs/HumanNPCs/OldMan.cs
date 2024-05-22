using Ink.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OldMan : MonoBehaviour
{
    private bool allowed;
    public bool started {  get; private set; }
    private Dialogue dialogue;


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
            FlashBack();
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

}
