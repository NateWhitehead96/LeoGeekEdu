using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class MoveForward : MonoBehaviour , IPointerDownHandler, IPointerUpHandler
{
    public CarScript player; // access to the player
    public bool buttonPressed; // to know when the button is pressed and released
    
    public void OnPointerDown(PointerEventData eventData) // input with the mouse to know when we've clicked
    {
        buttonPressed = true; // true because we're clicking on the button
    }

    public void OnPointerUp(PointerEventData eventData) // input to know when the mouse is released
    {
        buttonPressed = false; // false when we lift our finger off the button
    }

    // Update is called once per frame
    void Update()
    {
        if(buttonPressed == true) // move the player when the button is pressed
        {
            player.MoveForward();
        }
        

    }
}
