using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3; 
    public int playerHealth;

    public float invincibilityDuration = 2f;
    public bool isInvincible = false;
    public TMP_Text gameOverText;

    private void Start(){

        playerHealth = maxLives;
        gameOverText.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.CompareTag("Enemy")){
            CameraShake cameraShake = FindObjectOfType<CameraShake>();
            cameraShake.Shake();

            TakeDamage();
            
        }

    }


    public void TakeDamage(){

        if (!isInvincible){

            playerHealth = playerHealth -1;

            if (playerHealth <= 0){
                GameOver();

            }else{
                StartCoroutine(Respawn());
            }
        }
    }

    private IEnumerator Respawn(){
        isInvincible = true;
        
        transform.position = new Vector3(0, 0, 0); //mudar posição dps

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        for (float i = 0; i < invincibilityDuration; i += 0.2f){
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(0.2f);
        }
        spriteRenderer.enabled = true;

        isInvincible = false;
    }

    private void GameOver(){

        gameOverText.gameObject.SetActive(true);
        Debug.Log("dead");
        Destroy(gameObject);
 
    }
}
