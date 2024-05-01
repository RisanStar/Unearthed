using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //CAMERA VARIABLES
    public float sensX;
    public float sensY;
  //private float turnSpeed = 2f;

    float xRotation;
    float yRotation;

    public Transform orientation;
    //private Transform playerCamera;

    //[SerializeField] Transform NPC;



    private void Start()
    {
        //CURSOR 
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
       
    }
    private void Update()
    {
        if (Dialogue.GetInstance().dialogueIsPlaying)
        {
            //DialogueStart(NPC);
            return;
        }

        //MOUSE INPUT
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        //CAMERA ROTATION AND ORIENTATION
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    /*private void DialogueStart(Transform NPC)
    {
        StartCoroutine(TurnCameraTowardsNPC(NPC));
    }

    private IEnumerator TurnCameraTowardsNPC(Transform NPC)
    {
        //CAMERA LOCKS TO NPC
        Quaternion startRotation = playerCamera.rotation;
        Quaternion targetrotation = Quaternion.LookRotation(NPC.position - playerCamera.position);

        float elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            playerCamera.rotation = Quaternion.Slerp(startRotation, targetrotation, elapsedTime);
            elapsedTime += Time.deltaTime * turnSpeed;
            yield return null;
        }
        playerCamera.rotation = targetrotation;
    }
    */

}