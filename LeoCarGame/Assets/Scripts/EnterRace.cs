using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // access to changing scenes and knowing what scene we're in

public class EnterRace : MonoBehaviour
{
    public GameObject NextRaceButton;
    public GameObject ExitButton;
    public int LevelToLoad;
    // Start is called before the first frame update
    void Start()
    {
        NextRaceButton.SetActive(false); // hide buttons on start
        ExitButton.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            NextRaceButton.SetActive(true); // show the buttons
            ExitButton.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            NextRaceButton.SetActive(false); // hide buttons when player leaves box collider
            ExitButton.SetActive(false);
        }
    }

    public void LoadNextRace()
    {
        SceneManager.LoadScene(LevelToLoad); // load whatever scene we have as the level to load
    }
    public void ExitUI()
    {
        NextRaceButton.SetActive(false); // hide buttons when player hits exit
        ExitButton.SetActive(false);
    }
}
