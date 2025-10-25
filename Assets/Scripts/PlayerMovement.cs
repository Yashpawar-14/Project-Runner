using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 10f;
    [SerializeField] private float sideSpeed = 5f;
    [SerializeField] private float turnSpeed = 5f;
    [SerializeField] private float turnAngle = 30f;

    private Rigidbody rb;
    private float targetRotationY = 0f;
    private float horizontalInput;

    public bool Isrunning = false;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // prevent unwanted physics rotation
    }

    void Update()
    {
        // Get horizontal input
        horizontalInput = Input.GetAxis("Horizontal");

        // Determine the target rotation
        if (horizontalInput > 0.1f)
            targetRotationY = turnAngle;
        else if (horizontalInput < -0.1f)
            targetRotationY = -turnAngle;
        else
            targetRotationY = 0f;
    }

    void FixedUpdate()
    {
        // Move forward constantly
        Vector3 moveDirection = transform.forward * forwardSpeed * Time.fixedDeltaTime;
        Isrunning = true;

        // Add left/right movement
        moveDirection += transform.right * horizontalInput * sideSpeed * Time.fixedDeltaTime;

        // Move using Rigidbody (smooth and physics-safe)
        rb.MovePosition(rb.position + moveDirection);

        // Smoothly rotate the player
        Quaternion targetRotation = Quaternion.Euler(0f, targetRotationY, 0f);
        rb.MoveRotation(Quaternion.Lerp(rb.rotation, targetRotation, turnSpeed * Time.fixedDeltaTime));
    }
}
