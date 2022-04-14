using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FinishLine : MonoBehaviour
{
    public int laps;
    public float timer;
    public Text LapText;
    public Text TimerText;
    public bool started;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(started)
            timer += Time.deltaTime;

        LapText.text = "Lap: " +laps.ToString();
        TimerText.text = "Time: " + timer.ToString("#.00");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            started = true;
            laps++;
        }
    }
}
