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
    // these will help with triggering which camera to use
    [SerializeField]
    public GameObject ThirdPersonCamera;
    public GameObject FirstPersonCamera;

    //public WheelCollider[] wheels; // all of our wheels
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // link rigidbody to the car
        FirstPersonCamera.SetActive(false); // make sure we start in thirdperson
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) // when you hit tab toggle between camera views
        {
            if (ThirdPersonCamera.activeInHierarchy) // if our thirdperson camera is the active camera
            {
                ThirdPersonCamera.SetActive(false); // disable thirdperson camera
                FirstPersonCamera.SetActive(true); // enable first person camera
            }
            else // first person camera is active
            {
                ThirdPersonCamera.SetActive(true); // enable thirdperson camera
                FirstPersonCamera.SetActive(false); // disable first person camera
            }
        }


        //help with testing on Computer
        if (Input.GetKey(KeyCode.RightArrow) && rb.velocity != Vector3.zero || Input.GetKey(KeyCode.D)) // turning right
        {
            TurnRight();
        }
        if (Input.GetKey(KeyCode.LeftArrow) && rb.velocity != Vector3.zero || Input.GetKey(KeyCode.A)) // turning left
        {
            TurnLeft();
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) // going forward
        {
            MoveForward();
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) // reversing
        {
            rb.AddForce(transform.forward * -moveSpeed);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.rotation = Quaternion.identity; // just to reset our rotations if we flip out / flip over
        }

    }

//private void FixedUpdate()
//{
//    foreach (var wheel in wheels) // loop through all wheels and apply torque
//    {
//        wheel.motorTorque = Input.GetAxis("Vertical") * moveSpeed;
//    }

//    for (int i = 0; i < wheels.Length; i++) // for the first 2 wheels, rotate the wheels
//    {
//        if(i < 2)
//        {
//            wheels[i].steerAngle = Input.GetAxis("Horizontal") * rotationSpeed;
//        }
//    }
//}

public void MoveForward()
    {
        rb.AddForce(transform.forward * moveSpeed, ForceMode.Force); // add force forward
        //MoveDirection = transform.forward; // storing our forward direction in the move direction
        //rb.position += MoveDirection * moveSpeed * Time.deltaTime; // apply our speed to the move direction, then add that to our position
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
