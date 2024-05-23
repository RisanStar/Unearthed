using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlienTower : MonoBehaviour
{
    private bool allowedAccess;
    [SerializeField] private GameObject keyCard;

    private void Start()
    {
        allowedAccess = false;
    }
    private void Update()
    {
        if (keyCard == null)
        {
            allowedAccess = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (allowedAccess)
        {
            if (other.CompareTag("Player"))
            {
                SceneManager.LoadScene("AlienTower");
            }
        }
    }
}
