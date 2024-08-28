using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    public float speed = 10f;
    public float turnSpeed = 50f;

    private float movementInputValue;
    private float turnInputValue;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    } 
    
    private void Update()
    {
        movementInputValue = Input.GetAxis("Vertical");
        turnInputValue = Input.GetAxis("Horizontal");

    }
    
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    // Update is called once per frame
    private void Move()
    {
        Vector3 movement = transform.forward * movementInputValue * speed*Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }
    private void Turn()
    {
        float turn = turnInputValue * speed*Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f,turn,0f);
        rb.MoveRotation(rb.rotation*turnRotation);
    }
}
