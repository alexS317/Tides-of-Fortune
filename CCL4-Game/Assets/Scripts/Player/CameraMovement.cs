using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    [SerializeField] private float closestDistanceToPlayer;
    [SerializeField] private float maxAngle;

    private float maximumDistanceFromPlayer;
    private Vector3 previousPlayerPosition;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize variables
        previousPlayerPosition = playerObject.transform.position;
        maximumDistanceFromPlayer = Vector3.Distance(transform.position, previousPlayerPosition);
        maximumDistanceFromPlayer = Mathf.Abs(maximumDistanceFromPlayer);
        playerTransform = playerObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the camera with the player's movement
        var currentPlayerPosition = playerObject.transform.position;
        var deltaPlayerPosition = currentPlayerPosition - previousPlayerPosition;
        transform.position += deltaPlayerPosition;
        previousPlayerPosition = currentPlayerPosition;
    }

    void OnCameraMovement(InputValue inputValue)
    {
        // Handle camera movement input
        Vector2 inputVector = inputValue.Get<Vector2>();
        CameraRotationYAxis(inputVector);
        CameraRotationXAxis(inputVector);
    }

    void CameraRotationYAxis(Vector2 inputVector)
    {
        // Rotate the camera around the player on the Y-axis based on input
        this.transform.RotateAround(playerTransform.position, new Vector3(0, 1, 0), inputVector.x);
    }

    void CameraRotationXAxis(Vector2 inputVector)
    {
        // Rotate the camera around the player on the X-axis based on input
        var upValue = inputVector.y * 0.2f;
        var originalPos = transform.position;
        var originalRotation = transform.rotation;

        this.transform.RotateAround(playerTransform.position, transform.right, upValue);

        // Limit the camera rotation angle
        if (Vector3.Angle(playerTransform.forward, transform.forward) > maxAngle)
        {
            transform.position = originalPos;
            transform.rotation = originalRotation;
        }
    }

    void OnCameraZoom(InputValue inputValue)
    {
        // Handle camera zoom input
        Vector2 inputVector = inputValue.Get<Vector2>();
        CameraZoom(inputVector);
    }

    void CameraZoom(Vector2 inputVector)
    {
        // Zoom the camera based on input
        var shiftValue = inputVector.y * 0.03f;
        transform.Translate(new Vector3(0, 0, shiftValue));

        var distance = Vector3.Distance(transform.position, playerTransform.position);
        distance = Mathf.Abs(distance);

        // Limit the camera zoom distance
        if (distance > maximumDistanceFromPlayer || distance < closestDistanceToPlayer)
        {
            transform.Translate(new Vector3(0, 0, -shiftValue));
        }
    }
}
