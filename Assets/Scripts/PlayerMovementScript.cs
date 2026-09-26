using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public CharacterController controller;
    public AudioSource footsteps;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    // Variables related to checking if the player is on the ground
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector2 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        // Checks if the player is on the ground to reset gravity
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        // Checks if movement input is being pressed
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Updates the position of the player to move them
        Vector3 move = (transform.right * x) + (transform.forward * z);

        controller.Move(move * speed * Time.deltaTime);

        // Apply gravity 
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (controller.velocity.magnitude > 0.1f)
        {
            footsteps.enabled = true;
        }
        else
        {
            footsteps.enabled = false;
        }
    }
}
