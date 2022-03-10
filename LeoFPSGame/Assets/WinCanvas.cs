using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCanvas : MonoBehaviour
{
    public List<GameObject> Enemies = new List<GameObject>(); // a list of all of the enemies in the game

    public GameObject DisplayText; // the prompt/text that tells you, you win
    // Start is called before the first frame update
    void Start()
    {
        DisplayText.SetActive(false); // hide the win text
    }

    // Update is called once per frame
    void Update()
    {
        if(Enemies.Count <= 0) // we have no more enemies
        {
            DisplayText.SetActive(true);
        }
        for (int i = 0; i < Enemies.Count; i++) // loop through all of our enemies, and any spot that has a dead enemy we'll subtract
        {
            if(Enemies[i] == null)
            {
                Enemies.RemoveAt(i); // remove the empty list object
            }
        }
    }
}
