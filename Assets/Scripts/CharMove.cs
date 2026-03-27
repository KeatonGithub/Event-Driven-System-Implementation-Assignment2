using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    CharacterController controller;

    public float speed = 6f;
    public float gravity = -19.62f;
    public float jumpHeight = 2f;
    public Transform cam;
    public float rotationSmoothTime = 0.1f;
    float turnSmoothVelocity;

    Vector3 velocity; // Handles falling and jumping
    bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Ground Check
        // CharacterController has a built-in .isGrounded, but it can be finicky.
        // We reset velocity when on the ground so gravity doesn't build up infinitely.
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Slight downward force to keep the player stuck to the floor
        }

        //Horizontal Movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, rotationSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        //Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // The formula for jump velocity is: v = sqrt(jumpHeight * -2 * gravity)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

       //Applying Gravity
        velocity.y += gravity * Time.deltaTime;

        // We multiply by Time.deltaTime twice (once for velocity, once for Move) 
        // because this is an acceleration over time.
        controller.Move(velocity * Time.deltaTime);
    }
}