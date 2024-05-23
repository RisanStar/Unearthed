using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkOverPickUp : MonoBehaviour
{
    [SerializeField] private GameObject gObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gObject);
        }
    }
}
