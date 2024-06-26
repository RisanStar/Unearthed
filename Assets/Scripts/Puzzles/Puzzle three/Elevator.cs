using System.Collections;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private ElevatorTrigger trigger;
    [SerializeField] private GameObject player;

    [SerializeField] GameObject[] waypoints;
    private int currentWaypointIndex = 1;
    [SerializeField] float speed = 1f;


    private void Update()
    {

        if (trigger != null)
        {
            if (trigger.isInElevator == true)
            {
                StartCoroutine(MoveElevator());
            }

        }

    }

    private IEnumerator MoveElevator()
    {
        yield return new WaitForSeconds(.5f);
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) != 0f)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
        }
  
    }
}