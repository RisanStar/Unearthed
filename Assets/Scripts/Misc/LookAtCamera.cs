using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform objectToRotate;
    [SerializeField] private GameObject player;
    private void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= 7f)
        {
            objectToRotate.rotation = Quaternion.Slerp(objectToRotate.rotation, mainCamera.transform.rotation, 3f * Time.deltaTime);
        }
    }

}
