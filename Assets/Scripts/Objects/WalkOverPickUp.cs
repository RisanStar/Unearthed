using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkOverPickUp : MonoBehaviour
{
    [SerializeField] private GameObject gObject;
    [SerializeField] private GameObject bInventory;
    [SerializeField] private GameObject fInventory;

    private void Start()
    {
        bInventory.SetActive(true);
        fInventory.SetActive(false);
    }

    private void Update()
    {
        if (gObject == null)
        {
            fInventory.SetActive(true);
            bInventory.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gObject);
        }
    }
}
