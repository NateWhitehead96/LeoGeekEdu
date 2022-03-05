using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // grants access to AI classes

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent; // the thing that handles moving the enemy around

    public Transform player; // the position of the player
    public int health; // how much health the enemy has
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position); // this sets the destination of the enemy to constantly move towards the player
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) // check if the thing hitting us is bullet
        {
            health--; // lose health
            if(health <= 0) // when health is 0 destroy the enemy
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().currentHealth--; // lose 1 health on the player
        }
    }
}
