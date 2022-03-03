using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // grants access to UI classes

public class UIScript : MonoBehaviour
{
    public Text AmmoText; // displays ammo
    public Slider HealthSlider; // display health
    public PlayerMovement player; // access to player
    // Start is called before the first frame update
    void Start()
    {
        HealthSlider.maxValue = player.maxHealth; // set the max health
    }

    // Update is called once per frame
    void Update()
    {
        AmmoText.text = player.currentAmmo + " / " + player.maxAmmo; // displays ammo like 99/99
        HealthSlider.value = player.currentHealth; // constantly updating health
    }
}
