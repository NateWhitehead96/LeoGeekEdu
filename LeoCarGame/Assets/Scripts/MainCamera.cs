using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform player; // player position

    public Vector3 positionOffset; // a set distance from the player (current distance from the car)
    public Vector3 rotationOffset; // help us go back to original rotation of the car even when turning
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move the camera contantly towards the players position, but lag behind a little bit
        transform.position = Vector3.Lerp(transform.position, player.position + positionOffset, 2 * Time.deltaTime);

        // make sure the camera has the same rotations as the player (turning) and add the slight downward angle as an offset for the x axis
        //transform.rotation = player.rotation;
        //transform.RotateAround(player.position, player.rotation.x + transform.rotation.x);
    }
}
