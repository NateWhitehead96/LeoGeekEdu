using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public float moveSpeed;
    public int direction;
    public float topBounds;
    public float botBounds;
    // Start is called before the first frame update
    void Start()
    {
        topBounds = transform.position.y + 0.5f; // the coin will just go between these 2 points
        botBounds = transform.position.y - 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        // move the coin
        transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * direction * Time.deltaTime);
        if(transform.position.y >= topBounds)
        {
            direction = -1; // make sure the coin goes down
        }
        if(transform.position.y <= botBounds)
        {
            direction = 1; // make sure the coin goes up
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            collision.gameObject.GetComponent<Player>().coins++; // collected coin, increase by 1
            Destroy(gameObject); // destroy the coin
        }
    }
}
