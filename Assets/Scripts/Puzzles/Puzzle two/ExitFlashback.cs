using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitFlashback : MonoBehaviour
{
    [SerializeField] private GameObject keyCard;
    [SerializeField] private GameObject hutLight;
    private bool keyCollected;

    private void Update()
    {
        if (keyCard == null)
        {
            keyCollected = true;
            hutLight.SetActive(true);
        }
        else
        {
            keyCollected = false;
            hutLight.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && keyCollected)
        {
            ExitLevel();
        }
    }

    private void ExitLevel()
    {
        SceneManager.LoadScene("Slums #2");
    }

}
