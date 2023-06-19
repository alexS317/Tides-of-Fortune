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

        // isJumpingOrFalling = !IsGrounded();

        // print(isJumpingOrFalling);
    }

    void OnMovement(InputValue input)
    {
        Vector2 inputValue = input.Get<Vector2>();
        moveBy = new Vector3(inputValue.x, 0, inputValue.y);
    }

    void OnJump(InputValue input)
    {
        if (isJumpingOrFalling) return;
        rigidBody.AddForce(Vector3.up * jumpStrength, ForceMode.VelocityChange);
    }

    void ExecuteMovement()
    {
        isJumpingOrFalling = rigidBody.velocity.y < -.01 || rigidBody.velocity.y > .01;

        if (moveBy == Vector3.zero) isMoving = false;
        else isMoving = true;

        animator.SetBool("run", isMoving);
        animator.SetBool("jump", isJumpingOrFalling);

        // if (!isMoving && !isJumpingOrFalling)
        if (!isMoving)
        {
            transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
            // animator.SetBool("run", false);
            // animator.SetBool("jump", false);
            return;
        }
        // else if(!isMoving && isJumpingOrFalling)
        // {
        //     animator.SetBool("jump", true);
        //
        // } else if(isMoving && !isJumpingOrFalling)
        // {
        //     animator.SetBool("run", true);
        //     animator.SetBool("jump", false);
        //
        // } else if(isMoving && isJumpingOrFalling)
        //         {
        //     animator.SetBool("jump", true);
        // }


        if (movementType == MovementType.TransformBased)
        {
            RotatePlayerFigure(moveBy);
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        }
        else if (movementType == MovementType.PhysicsBased)
        {
            rigidBody.AddForce(moveBy * 2, ForceMode.Acceleration);
        }
    }

    private void RotatePlayerFigure(Vector3 rotateVector)
    {
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