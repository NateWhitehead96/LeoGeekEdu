using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text CoinDisplay; // show how many coins we have
    public Player player; // to quickly access health and coins
    // all of the UI hearts
    public Image HeartOne;
    public Image HeartTwo;
    public Image HeartThree;
    // link to the sprite images of full and emepty hearts
    public Sprite FullHeart;
    public Sprite EmptyHeart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CoinDisplay.text = ": " + player.coins.ToString(); // will now print how many coins we collect
        if(player.health < 3) // when the player takes damage
        {
            HeartOne.sprite = EmptyHeart; // make that heart look empty
        }
        if(player.health < 2)
        {
            HeartTwo.sprite = EmptyHeart;
        }
    }
}
