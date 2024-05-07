using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : MonoBehaviour
{
    public int firewoodLevel;

    private void Start()
    {
        firewoodLevel = 0;
    }

    private void Update()
    {
        string gathered = ((StringValue)Dialogue.GetInstance().GetVariableState("gathered")).value;
        if (GameObject.FindWithTag("Firewood") == null)
        {
            gathered = "yes";
        }

        switch (gathered)
        {
            case "":
                firewoodLevel = 0;
                break;
            case "no":
                firewoodLevel = 0;
                break;
            case "yes":
                firewoodLevel = 1;
                break;
            default:
                Debug.LogWarning("Answer not handeled by switch statement: " + gathered);
                break;
        }
    }
}
