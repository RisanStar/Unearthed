using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoors : MonoBehaviour
{
    [SerializeField] private ElevatorTrigger trigger;

    [SerializeField] GameObject[] waypoints;
    private int currentWaypointIndex = 1;
    [SerializeField] float speed = 1f;

    void Update()
    {
        if (trigger.doorIsClosing == true)
        {
            if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) != 0f)
            {
                transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
            }

            if (trigger.doorIsClosing == false)
            {
                if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) != 0f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
                }
            }
        }
        
    }
}
