using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public enum Button // tell us which button this script is attached to
{
    LeftTurn, // the left turn button
    RightTurn // right turn button
}
public class TurnRight : MonoBehaviour , IPointerDownHandler, IPointerUpHandler
{
    public CarScript player; // access to player
    public bool buttonPressed;
    public Button button; // know what button is being pressed
    public void OnPointerDown(PointerEventData eventData) // pressing down on the button
    {
        buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData) // letting go of the button
    {
        buttonPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(buttonPressed == true && button == Button.RightTurn)
        {
            player.TurnRight();
        }
        if(buttonPressed == true && button == Button.LeftTurn)
        {
            player.TurnLeft();
        }
        
    }
}
