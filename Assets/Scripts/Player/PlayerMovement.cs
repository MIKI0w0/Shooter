using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;

    public float speed = 10f;

    public float gravity = -10f;

    public Transform groundCheck;

    public float esfereRadius = 0.3f;

    public LayerMask groundMask;

    bool isGrounded;

    Vector3 velocity;

    public float jumpHeigth = 1.5f;


    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, esfereRadius, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -3f;
        }

        float x = Input.GetAxis("Horizontal");

        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeigth * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(move * speed * Time.deltaTime);

        characterController.Move(velocity * Time.deltaTime);
    }
}
