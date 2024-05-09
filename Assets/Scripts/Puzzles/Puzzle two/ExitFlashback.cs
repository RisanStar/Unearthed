using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitFlashback : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ExitLevel();
        }
    }

    private void ExitLevel()
    {
        SceneManager.LoadScene("Slums #2");
    }
}
