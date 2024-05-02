using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private ElevatorTrigger trigger;

    [SerializeField] GameObject[] waypoints;

    [SerializeField] float speed = 1f;

    private void Update()
    {
        if (trigger != null)
        {
            if (trigger.isInElevator == true)
            {
                if (Vector3.Distance(waypoints[0].transform.position, waypoints[1].transform.position) < .1f)
                {
                    StartCoroutine(MoveElevator());
                }

            }
        }

    }

    private IEnumerator MoveElevator()
    {
        yield return new WaitForSeconds(.5f);
        transform.position = Vector3.MoveTowards(waypoints[0].transform.position, waypoints[1].transform.position, speed * Time.deltaTime);
    }
}