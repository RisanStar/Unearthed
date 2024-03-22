using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public Camera mainCamera;
    public Transform objectToRotate;

    private void Update()
    {
        objectToRotate.rotation = Quaternion.Slerp(objectToRotate.rotation, mainCamera.transform.rotation, 3f * Time.deltaTime);
    }

}
