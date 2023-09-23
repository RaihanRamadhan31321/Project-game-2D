using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform patrolArea;  // Reference to the patrol area GameObject
    public float moveSpeed = 2.0f;  // Speed at which the enemy moves
    private Vector2 initialPosition;
    private bool movingRight = true;
    public Transform[] waypoints; // An array to hold the waypoints
    private int currentWaypointIndex = 0; // Index of the current waypoint


    private void Start()
    {
        initialPosition = transform.position;
        Debug.LogWarning("No waypoints assigned.");
        return;
    }

    private void Update()
    {
        // Calculate the left and right boundaries of the patrol area
        float leftBoundary = initialPosition.x - patrolArea.localScale.x / 2;
        float rightBoundary = initialPosition.x + patrolArea.localScale.x / 2;

        // Move the enemy
        if (movingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            if (transform.position.x >= rightBoundary)
            {
                Flip();
            }
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            if (transform.position.x <= leftBoundary)
            {
                Flip();
            }
        }
    }

    // Flip the enemy's direction
    private void Flip()
    {
        movingRight = !movingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

           // Calculate the direction to the current waypoint
        Vector3 targetPosition = waypoints[currentWaypointIndex].position;
        Vector3 moveDirection = (targetPosition - transform.position).normalized;

        // Move the enemy towards the current waypoint
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Check if the enemy has reached the current waypoint
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Switch to the next waypoint
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }

}
