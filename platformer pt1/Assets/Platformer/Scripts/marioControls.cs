using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marioControls : MonoBehaviour
{
    public float runForce = 50f;
    public float jumpForce = 20f;
    public float jumpBonus = 6f;
    public float runBonus = 5f;

    public float maxRunSpeed = 6f;

    public bool feetInContactWithGround;
    

    private Collider collider;

    private Animator animComp;
    
    
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
        animComp = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Bounds bounds = GetComponent<Collider>().bounds;
        feetInContactWithGround = Physics.Raycast(transform.position, Vector3.down, bounds.extents.y + 0.1f);

        float axis = Input.GetAxis("Horizontal");
        Rigidbody body = GetComponent<Rigidbody>();
        body.AddForce(Vector3.right * axis * runForce, ForceMode.Force);

        if (feetInContactWithGround && Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        
        else if (body.velocity.y > 0f &&  Input.GetKey(KeyCode.Space))
        {
            body.AddForce(Vector3.up * jumpBonus, ForceMode.Force);
        }

        float xVelocity = Mathf.Clamp(body.velocity.x, -maxRunSpeed, maxRunSpeed);

        if (Mathf.Abs(axis) < 0.1f)
        {
            xVelocity *= 0.9f;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            maxRunSpeed += 7f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            maxRunSpeed -= 7f;
        }

        body.velocity = new Vector3(xVelocity, body.velocity.y, body.velocity.z);
        
        animComp.SetFloat("Speed", body.velocity.magnitude);
    }
}
