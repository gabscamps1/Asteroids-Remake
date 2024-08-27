using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameInfo : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    
    public int score = 0;
    public int highScore = 0;
    public int NumberOfHearts;
    public Image[] Hearts;
    public Sprite fullHealth;
    public Sprite emptyHealth;

      public TMP_Text ammoText;
    public Slider AmmoValue;
    public int Ammo;
    public int health ; 

    
    void Start(){
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    void Update(){

        if (GameObject.Find("Player")) {
             GameObject go = GameObject.Find("Player");
             PlayerHealth cs = go.GetComponent<PlayerHealth>();

             BulletSpawn bs = go.GetComponent<BulletSpawn>();

             Ammo = bs.currentAmmo;
             health = cs.playerHealth;
        }else{
            health = 0;

            if (Input.GetKeyDown(KeyCode.R)){
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        UpdateHealth();
        UpdateAmmoText();
        UpdateScoreText();
        UpdateHighScoreText();

    }

    public void AddScore(int points){
        score += points;
        UpdateScoreText();

        if (score > highScore){
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            UpdateHighScoreText();
        }
    }

    void UpdateAmmoText(){
        ammoText.text = "" + Ammo;
        //ammoText.text = Ammo.ToString("D7");
        AmmoValue.value = Ammo;
    }

    void UpdateHealth(){

        if (health > NumberOfHearts){
            health = NumberOfHearts;
        }

       for (int i = 0; i < Hearts.Length; i++){

            if (i < health){
                Hearts[i].sprite = fullHealth;
            }else{
                Hearts[i].sprite = emptyHealth;
            }

            if(i < NumberOfHearts){
                Hearts[i].enabled = true;
            }else{
                Hearts[i].enabled = false;
            }
       }
    }
    

    void UpdateScoreText(){   
        scoreText.text = score.ToString("D7");
    }

    void UpdateHighScoreText(){
        highScoreText.text = "HI: " + highScore.ToString("D7");
    }

    public void ResetScore(){
        score = 0;
        UpdateScoreText();
    }
}
