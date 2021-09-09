using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public Rigidbody controller;

    public float speed = 12f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;
    public float gravity = 10;


    public Vector3 velocity;
    bool isGrounded;

    void Start()
    {
        controller.freezeRotation = true;
    }
    void FixedUpdate()
    {
        //grounding
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        else if (!isGrounded)
        {
            velocity.y -= gravity * Time.deltaTime;
        }
        //movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        
        controller.velocity = (move * speed * Time.deltaTime)+(this.transform.rotation * velocity * Time.deltaTime);




    }
    private void Update()
    {
        //jumping
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Abs(jumpHeight * -2 * gravity);
        }
        
    }

}
