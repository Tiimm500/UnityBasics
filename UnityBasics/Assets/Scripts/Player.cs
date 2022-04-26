using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool spacePressed;
    private bool rotateRight;
    private bool rotateLeft;

    private float horizontalInput;
    private Rigidbody rigidbodyComponent;
    private float jumpPower;

    public int DoubleJumpsRemaining;
    public bool facingRight = true;
    public bool facingLeft = false;


    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private float rotationSpeed = 4f;
    [SerializeField] private float flipDistance = 1f;
    [SerializeField] private Coin coinUI;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
        jumpPower = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spacePressed = true;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rotateRight = true;
        }        
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotateLeft = true;
        }

        if (Input.GetKey(KeyCode.W))
        {

        }

        horizontalInput = Input.GetAxis("Horizontal") * 2;
    }

    // FixedUpdate is called once every physic update
    void FixedUpdate()
    {
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length > 0)
        {
            rigidbodyComponent.constraints = RigidbodyConstraints.FreezeRotation;
        }
        else
        {
            rigidbodyComponent.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
        }

        if (rotateRight)
        {
            if (facingRight)
            {
                transform.Rotate(Vector3.back * rotationSpeed);
                rigidbodyComponent.AddForce(Vector3.right * flipDistance, ForceMode.VelocityChange);
            }
            else
            {
                transform.Rotate(Vector3.forward * rotationSpeed);
                rigidbodyComponent.AddForce(Vector3.left * flipDistance, ForceMode.VelocityChange);
            }
            rigidbodyComponent.angularVelocity = Vector3.back * rotationSpeed;

            rotateRight = false;
        }   
        
        if (rotateLeft)
        {

            if (facingLeft)
            {
                transform.Rotate(Vector3.back * rotationSpeed);
                rigidbodyComponent.AddForce(Vector3.left * flipDistance, ForceMode.VelocityChange);
            }
            else
            {
                transform.Rotate(Vector3.forward * rotationSpeed);
                rigidbodyComponent.AddForce(Vector3.right * flipDistance, ForceMode.VelocityChange);
            }
            rigidbodyComponent.angularVelocity = Vector3.forward * rotationSpeed;

            rotateLeft = false;
        }

        if (spacePressed)
        {
            if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length > 0)
            {
                rigidbodyComponent.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            }
            else if (DoubleJumpsRemaining > 0)
            {
                rigidbodyComponent.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
                DoubleJumpsRemaining--;
                coinUI.UpdateCoin(this);
            }
            spacePressed = false;

        }

        if (horizontalInput > 0 && facingLeft)
        {
            transform.Rotate(0f, 180f, 0f);
            facingLeft = false;
            facingRight = true;
        }

        if (horizontalInput < 0 && facingRight)
        {
            transform.Rotate(0f, 180f, 0f);
            facingLeft = true;
            facingRight = false;
        }
        rigidbodyComponent.velocity = new Vector3(horizontalInput, rigidbodyComponent.velocity.y, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            other.gameObject.SetActive(false);
            DoubleJumpsRemaining++;
            coinUI.UpdateCoin(this);
        }
    }
}
