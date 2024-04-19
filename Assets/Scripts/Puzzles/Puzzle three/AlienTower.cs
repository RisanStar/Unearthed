using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlienTower : MonoBehaviour
{
    private bool allowedAccess;

    private void Start()
    {
        allowedAccess = false;
    }
    private void Update()
    {
        if (GameObject.FindWithTag("Firewood") == null)
        {
            allowedAccess = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (allowedAccess)
        {
            if (other.tag == "Player")
            {
                SceneManager.LoadScene("AlienTower");
            }
        }
    }
}
