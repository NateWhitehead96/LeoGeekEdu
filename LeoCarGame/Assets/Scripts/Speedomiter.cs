using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedomiter : MonoBehaviour
{
    public Text text;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Speed: " + (player.GetComponent<Rigidbody>().velocity.magnitude * 5).ToString("#.00") + " km/h";
    }
}
