using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text CoinDisplay; // show how many coins we have
    public Player player; // to quickly access health and coins
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CoinDisplay.text = ": " + player.coins.ToString(); // will now print how many coins we collect
    }
}
