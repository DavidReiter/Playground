using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private Rigidbody body;

    public float speed = 2;
    public float rotationSpeed = 720;
    public float maxSpeed = 30;
    public float acceleration = 0;
    public Vector3 deltaMove;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        acceleration = vertical;

        if (speed < maxSpeed)
        {
            speed += acceleration * Time.deltaTime;
        }

        deltaMove = new Vector3(horizontal, 0, vertical);
        deltaMove.Normalize();
        transform.Translate(deltaMove * speed * Time.deltaTime, Space.World); 

        if(deltaMove != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(deltaMove, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        
        
    }
}
