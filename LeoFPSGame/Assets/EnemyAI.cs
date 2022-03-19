using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // grants access to AI classes

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent; // the thing that handles moving the enemy around

    public Transform player; // the position of the player
    public int health; // how much health the enemy has

    public float distance; // distance between player and enemy
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.position);

        if(distance < 20)
        {
            agent.SetDestination(player.position); // this sets the destination of the enemy to constantly move towards the player
        }
        else
        {
            agent.ResetPath(); // stop following player if they are outside of the distance range
        }

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
            collision.gameObject.GetComponent<PlayerMovement>().currentHealth -= 1; // lose 1 health on the player
        }
    }
}
