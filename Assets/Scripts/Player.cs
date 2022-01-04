using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform groundCheckTransform = null;
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigitbodyComponenet;
    private bool isGrounded;
    
    // Start is called before the first frame update
    void Start()
    {
        rigitbodyComponenet = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Chack if space key is pressed down
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");

    }

    // FixUppdate is colld once every physic update
    private void FixedUpdate()
    {
        if (!isGrounded)
        {
            return;
        }
        
        if (jumpKeyWasPressed)
        {
            rigitbodyComponenet.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }

        rigitbodyComponenet.velocity = new Vector3(horizontalInput, rigitbodyComponenet.velocity.y,0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
    
    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
