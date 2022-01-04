using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;
    
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigitbodyComponenet;
    
    
    //private bool isGrounded;

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
        rigitbodyComponenet.velocity = new Vector3(horizontalInput, rigitbodyComponenet.velocity.y, 0);
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            return;
        }

        if (jumpKeyWasPressed)
        {
            rigitbodyComponenet.AddForce(Vector3.up * 7, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            Destroy(other.gameObject);
        }
    }
}