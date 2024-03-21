using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //PLAYER VARIABLES;
    float horizontal;
    float vertical;
    private float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;

    public Transform orientation;
    Rigidbody rb;
    Vector3 moveDirection;

    //GROUND CHECK
    public float playerHeight;
    public float groundDrag;
    public LayerMask Ground;
    bool grounded;

    //SLOPE VARIABLES
    public float maxSlopeAngle;
    private RaycastHit slopeHit;
    private bool exitingSlope;

    //JUMP VARIABLES
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public float fallMultiplier;
    bool readyToJump;

    //CROUCH VARIABLES
    public float crouchSpeed;
    public float crouchYScale;
    private float startYScale;

    //KEYBINDS
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode crouchKey = KeyCode.LeftControl;

    public MovementState state;
    //STATES OF MOVEMENT
      //*creates grouped constants
    public enum MovementState
    {
        walking,
        sprinting,
        crouching,
        air,
    }

    private void Start()
    {
        //PLAYER
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
        startYScale = transform.localScale.y;
    }

    private void Update()
    {
        //CALLING PLAYER INPUT
        MyInput();
        //CALLING PLAYER SPEED
        SpeedControl();
        //CALLING STATE OF PLAYER
        StateHandler();

        //CALCULATING WHAT IS GROUND
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * .5f + .2f, Ground);
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
            rb.drag = 0;
            rb.velocity += Vector3.up * Physics.gravity.y * fallMultiplier * Time.deltaTime;
        

    }

    private void FixedUpdate()
    {
        //CALLING PLAYER MOVEMENT
        MovePlayer();
    }

    private void SpeedControl()
    {
        if (OnSlope() && !exitingSlope)
        {
            if (rb.velocity.magnitude > moveSpeed)
                rb.velocity = rb.velocity.normalized * moveSpeed;
                  
        }
        else
        {
            //MAX VELOCITY 
            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            if (flatVel.magnitude > moveSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * moveSpeed;
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }
        }
    }

    private void MyInput()
    {
        //PLAYER WASD INPUT
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        //PLAYER JUMP INPUT
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();
            //CONTINUOUS JUMPING
            Invoke(nameof(ResetJump), jumpCooldown);
        }

        //PLAYER CROUCH INPUT
        if (Input.GetKeyDown(crouchKey))
        {
            //START CROUCHING
            transform.localScale = new Vector3 (transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        }

        if (Input.GetKeyUp(crouchKey))
        {
            //STOP CROUCHING
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
        }
        
    }

    private void MovePlayer()
    {
        //CALCULATE MOVEMENT DIRECTION
        moveDirection = orientation.forward * vertical + orientation.right * horizontal;

        //SLOPE MOVEMENT
        if (OnSlope() && !exitingSlope)
        {
            rb.AddForce(GetSlopeMoveDirection() * moveSpeed * 20f, ForceMode.Force);
            if (rb.velocity.y > 0)
            rb.AddForce(Vector3.down * 80f, ForceMode.Force); 
        }

        //PLAYER MOVEMENT
        else if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }

        //TURN GRAVITY OFF ON SLOPE
        rb.useGravity = !OnSlope();

    }

    private void Jump()
    {
        //RESET THE Y-VELOCITY
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

        //JUMPING ON SLOPE
        exitingSlope = true;
    }

    private void ResetJump()
    {
        //ALLOWS FOR ANOTHER JUMP
        readyToJump = true;

        //RESETTING JUMP ON SLOPE
        exitingSlope = false;
    }

    //FINDS THE ANGLE OF THE SLOPE
    private bool OnSlope()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * .5f + .2f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }

        return false;
    }

    //ALLOWS MOVEMENT UP THE SLOPE
    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    }

    private void StateHandler()
    {
        //MODE - CROUCHING
        if(grounded && Input.GetKey(crouchKey))
        {
            state = MovementState.crouching;
            moveSpeed = crouchSpeed;
        }

        //MODE - SPRINTING
        else if (grounded && Input.GetKey(sprintKey))
        {
            state = MovementState.sprinting;
            moveSpeed = sprintSpeed;
        }

        //MODE - WALKING
        else if (grounded)
        {
            state = MovementState.walking;
            moveSpeed = walkSpeed;
        }

        //MODE - AIR
        else
        {
            state = MovementState.air;
        }

    }
}
