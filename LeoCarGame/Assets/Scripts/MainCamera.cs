using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject car;
    public Transform[] camlocations;
    public int locationIndicator;
    public float smoothTime;

    void Start()
    {
        car = FindObjectOfType<CarScript>().gameObject;
    }

    private void FixedUpdate()
    {
        transform.position = camlocations[locationIndicator].position * (1 - smoothTime) + transform.position * smoothTime;
        transform.LookAt(car.transform);
    }
}
