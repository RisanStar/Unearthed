using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject realElevator;

    public float doorCloseTime;
    



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == player)
        {
            StartCoroutine(StartElevator());
        }
    }

    private IEnumerator StartElevator()
    {
        yield return new WaitForSeconds(doorCloseTime);
        player.transform.position = realElevator.transform.position;
    }
}
