using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] public float jumpStrength = 5f;
    [SerializeField] private MovementType movementType;

    [SerializeField] private Animator animator;

    private Vector3 moveBy;
    private bool isMoving;
    private bool isJumpingOrFalling;

    [SerializeField] private float groundCheckDistance = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    private bool IsGrounded()
    {
        // Perform a raycast downward to check if the player is touching the ground
        RaycastHit hit;
        Vector3 raycastOrigin = transform.position + Vector3.right * 0.1f;

        Debug.DrawRay(raycastOrigin, Vector3.down * 1f);

        if (Physics.Raycast(raycastOrigin, Vector3.down, out hit, groundCheckDistance, groundLayer))
        {
            return true;
        }

        return false;
    }

    private Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ExecuteMovement();
    }

    void OnMovement(InputValue input)
    {
        // Handle the movement input from the player
        Vector2 inputValue = input.Get<Vector2>();
        moveBy = new Vector3(inputValue.x, 0, inputValue.y);
    }

    void OnJump(InputValue input)
    {
        // Handle the jump input from the player
        if (isJumpingOrFalling) return; // Ignore jump input if the player is already jumping or falling
        rigidBody.AddForce(Vector3.up * jumpStrength, ForceMode.VelocityChange);
    }

    void ExecuteMovement()
    {
        // Determine if the player is currently jumping or falling
        isJumpingOrFalling = rigidBody.velocity.y < -0.01f || rigidBody.velocity.y > 0.01f;

        // Determine if the player is currently moving
        if (moveBy == Vector3.zero) isMoving = false;
        else isMoving = true;

        // Set animator parameters based on player movement state
        animator.SetBool("run", isMoving);
        animator.SetBool("jump", isJumpingOrFalling);

        if (!isMoving)
        {
            // Stop player rotation and animation if not moving
            transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
            return;
        }

        if (movementType == MovementType.TransformBased)
        {
            // Rotate the player and move it using transform translation
            RotatePlayerFigure(moveBy);
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        }
        else if (movementType == MovementType.PhysicsBased)
        {
            // Move the player using Rigidbody physics
            rigidBody.AddForce(moveBy * 2, ForceMode.Acceleration);
        }
    }

    private void RotatePlayerFigure(Vector3 rotateVector)
    {
        // Rotate the player model based on the movement direction
        rotateVector = Vector3.Normalize(rotateVector);
        transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
        var rotationY = 90 * rotateVector.x;

        if (rotateVector.z < 0)
        {
            transform.Rotate(0, 180, 0);
            rotationY *= -1;
        }

        transform.Rotate(0, rotationY, 0);
    }
}
