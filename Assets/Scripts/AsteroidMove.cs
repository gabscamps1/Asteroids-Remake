using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidMove : MonoBehaviour
{
    public float timeToDespawn = 25f;
    public GameInfo gameInfo;
    [SerializeField] float enemySpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToDespawn);
        if (gameInfo == null)
        {
            gameInfo = GameObject.FindObjectOfType<GameInfo>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -enemySpeed, 0) * Time.deltaTime; //Movimenta o objeto
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            gameInfo.AddScore(100);
            Destroy(gameObject);
        }

        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

    }

    private void OnParticleCollision(GameObject other)
    {
       
    //   if (other.CompareTag("Bullet"))
    //     {
             gameInfo.AddScore(100);
             Destroy(gameObject);
    //     }

        

    }


}

