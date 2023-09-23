using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 6f; // Adjust the movement speed in the Inspector.
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput);
        rb.velocity = moveDirection.normalized * moveSpeed;
        // Optionally, set up animations based on movement input.
        // For example, you can use Animator components and triggers.
    }
}
