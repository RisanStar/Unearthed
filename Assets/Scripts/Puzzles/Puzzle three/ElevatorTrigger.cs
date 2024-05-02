using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject realElevator;

    public float doorCloseTime;
    public bool isInElevator;


    private void Start()
    {
        isInElevator = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("You have entered the collision");
            StartCoroutine(StartElevator());
        }
        else
            StopCoroutine(StartElevator());
    }

    private IEnumerator StartElevator()
    {
        yield return new WaitForSeconds(doorCloseTime);
        Vector3 target = new (realElevator.transform.position.x, realElevator.transform.position.y + 5f, realElevator.transform.position.z);
        player.transform.position = target;
        yield return new WaitForSeconds(1f);
        isInElevator = true;
    }
}
