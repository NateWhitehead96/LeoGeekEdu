using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBreaker : MonoBehaviour
{
    public GameObject[] blocksToBreak; // all of the blocks that will be destroyed when the button is pressed
    public SpriteRenderer sprite; // access to the button's image
    public Sprite pressedImage; // the image the button will be when pressed
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>(); // auto link the sprite renderer
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>()) // if player touches this button
        {
            for (int i = 0; i < blocksToBreak.Length; i++) // loop through all of our blocks
            {
                Destroy(blocksToBreak[i]); // destroy each block
            }
            sprite.sprite = pressedImage; // change the sprite to look like it's pressed
            GetComponent<PolygonCollider2D>().enabled = false; // disable collider after we press and do all the actions
        }
    }
}
