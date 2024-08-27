using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rdb;
    public float playerSpeed = 10;
    
    
    public new ParticleSystem particleSystem;
 
    void Start()
    {
        //transform.position = new Vector3(0, -7,0);  //Transforma a posição
    }

    // Update is called once per frame
    void Update()
    {
        
        // if (playerHealth <= 0) {
           
        // }

    }

    private void FixedUpdate()
    {
        Movimento();
    }

    void Movimento(){
        //Horizontal
        if (Input.GetKey(KeyCode.D)){
            rdb.AddTorque(-playerSpeed);
        }

        else if (Input.GetKey(KeyCode.A)){
            rdb.AddTorque(playerSpeed);
        }

        if (Input.GetKey(KeyCode.W))
        {
            rdb.AddRelativeForce(Vector2.up * playerSpeed);
           
            particleSystem.Emit(1);
        }
          
        else if (Input.GetKey(KeyCode.S))
        {
            rdb.AddRelativeForce(Vector2.down * playerSpeed);
        }

        else {
           
        }
    }

    

}

