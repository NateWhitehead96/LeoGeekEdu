using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public float moveSpeed; // how fast we move
    public float rotationSpeed; // how fast we rotate

    public Vector3 MoveDirection; // how we move forward

    private Rigidbody rb; // to help move the car with physics
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // link rigidbody to the car
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveForward()
    {
        rb.AddForce(transform.forward * moveSpeed); // add force forward
    }
    public void TurnLeft()
    {
        transform.Rotate(Vector3.up * -rotationSpeed); // turn left
    }
    public void TurnRight()
    {
        transform.Rotate(Vector3.up * rotationSpeed); // turn left
    }
}
