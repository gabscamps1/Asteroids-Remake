using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float timeToDespawn = 2f;

    void Start()
    {
        //Destroy(gameObject, timeToDespawn);

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     Destroy(gameObject);
    // }

    /*void OnTriggerEnter2D(Collider2D other)
    {
    
        
        if (other.CompareTag("Enemy"))
        {

             Destroy(gameObject);
        }

    }*/

    // private void OnParticleCollision(GameObject collision){
    //         if (collision.CompareTag("Enemy"))
    //         {
    //             Destroy(gameObject);
    //         }
    //     }
}
