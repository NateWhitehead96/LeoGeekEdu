using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        // help with testing on Computer
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) // turning right
        {
            TurnRight();
        }
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) // turning left
        {
            TurnLeft();
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) // going forward
        {
            MoveForward();
        }
        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) // reversing
        {
            rb.AddForce(transform.forward * -moveSpeed);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.rotation = Quaternion.identity; // just to reset our rotations if we flip out / flip over
        }
    }

    public void MoveForward()
    {
        //rb.AddForce(transform.forward * moveSpeed); // add force forward
        MoveDirection = transform.forward; // storing our forward direction in the move direction
        rb.position += MoveDirection * moveSpeed * Time.deltaTime; // apply our speed to the move direction, then add that to our position
    }
    public void TurnLeft()
    {
        transform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime); // turn left
    }
    public void TurnRight()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime); // turn right
    }

    
}
