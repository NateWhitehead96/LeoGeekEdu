using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : MonoBehaviour
{
    public int moveSpeed;
    public int direction;
    public float leftBounds; // how far left the enemy can go
    public float rightBounds; // how far right the enemy can go
    public SpriteRenderer sprite; // to help flip the spider left and right
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + moveSpeed * direction * Time.deltaTime, transform.position.y);
        if(transform.position.x > rightBounds)
        {
            direction = -1;
            sprite.flipX = false; // make the spider face left
        }
        if(transform.position.x < leftBounds)
        {
            direction = 1;
            sprite.flipX = true; // flip the spider to face right
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            print("hit player");
            collision.gameObject.GetComponent<Player>().health--; // subtract 1 health
        }
    }
}
