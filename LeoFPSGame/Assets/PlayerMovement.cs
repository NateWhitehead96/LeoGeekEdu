using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed; // how fast our player can move

    public Rigidbody rigidbody; // the rigidbody aka physics body to help with jumping
    public float jumpForce; // how high can out player jump

    public Vector3 moveDirection; // the new position we use to move

    public float horizontalSpeed; // how fast we can rotate left and right
    public float verticalSpeed; // how fast we rotate up and down

    public float xRotation; // hold our x rotation
    public float yRotation; // hold our y rotation

    // Bullet stuff
    public GameObject bullet; // the prefab bullet to fire
    public float bulletForce; // how fast the bullet travels
    public Transform shootPosition; // where the bullet comes out of
    public int maxAmmo; // how much ammo we can have
    public int currentAmmo; // how much ammo we have currently

    public int maxHealth; // how much hp we have to start
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; // this will lock the mouse to the center of the screen
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.W)) // move forward
        //{
        //    // moving forward by adding movespeed to the z position
        //    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveSpeed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.S)) // move backward
        //{
        //    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - moveSpeed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.D)) // move to the right
        //{
        //    transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        //}
        //if (Input.GetKey(KeyCode.A)) // move left
        //{
        //    transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        //}
        // movement code
        float horizontal = Input.GetAxisRaw("Horizontal"); // find our horizontal input (left and right input also works with gamepads)
        float vertical = Input.GetAxisRaw("Vertical"); // find the vertical input
        moveDirection = (transform.forward * vertical) + (transform.right * horizontal); // applying input to new move direction
        Vector3 force = moveDirection * (moveSpeed * Time.deltaTime); // create the force for movement
        transform.position += force; // apply all the jazz to the position

        // rotation code
        float mouseX = Input.GetAxisRaw("Mouse X"); // mouse x position
        yRotation = mouseX * horizontalSpeed * Time.deltaTime; // the new Y rotation
        float mouseY = Input.GetAxisRaw("Mouse Y"); // mouse y position
        xRotation = mouseY * verticalSpeed * Time.deltaTime; // the new X rotation

        Vector3 playerRotation = transform.rotation.eulerAngles; // this hold our current rotation
        playerRotation.y += yRotation; // sets the y rotation
        playerRotation.x -= xRotation; // sets the x rotation
        transform.rotation = Quaternion.Euler(playerRotation); // apply the rotation to the character

        // jump code
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // adding force up on the player to jump
        }

        ShootBullet(); // make sure to call the shoot function

        if (Input.GetKeyDown(KeyCode.Z))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); // to reset rotation if its all messed up when we play
        }
    }

    void ShootBullet() // how we shoot/fire the bullet from our gun
    {
        if (Input.GetMouseButtonDown(0) && currentAmmo > 0) // when we left click and have ammo
        {
            currentAmmo--; // subtract one bullet
            GameObject newBullet = Instantiate(bullet, shootPosition.position, transform.rotation); // create new bullet
            newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletForce); // make the bullet go forward
        }
        if (Input.GetKeyDown(KeyCode.R)) // reloading with R
        {
            currentAmmo = maxAmmo; // reload all of our bullets
        }
    }
}
