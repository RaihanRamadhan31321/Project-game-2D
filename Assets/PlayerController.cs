using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Handle character movement and input here.

        // For example, set the "IsWalking" parameter based on input.
        bool isWalking = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
        animator.SetBool("IsWalking", isWalking);

    }
}
