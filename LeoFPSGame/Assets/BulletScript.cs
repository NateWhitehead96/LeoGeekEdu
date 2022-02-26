using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    public float expiredTime; // how long has the bullet been alive, and when this hits 0 destroy the bullet
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        expiredTime -= Time.deltaTime; // decrease the time on the bullets life

        if(expiredTime <= 0) // when the timer reaches 0, destroy the bullet
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject); // when the bullet hits anything, destroy it
    }
}
