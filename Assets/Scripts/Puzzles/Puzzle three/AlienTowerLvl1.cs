using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienTowerLvl1 : MonoBehaviour
{
    [SerializeField] private GameObject targetPoint;
    [SerializeField] private GameObject Player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Level1();
        }
    }

    private void Level1()
    {
        Player.transform.position = targetPoint.transform.position;
    }
}
