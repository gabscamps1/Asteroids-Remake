using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.SceneManagement;

public class Script_MenuStart : MonoBehaviour
{    
    // public void Update()
    // {
        
    //      if (Input.GetKeyDown(KeyCode.Space)){
            
    //         SceneManager.LoadScene("Scene_MainLevel", LoadSceneMode.Single);
    //         //SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene_MainLevel"));
    //         SceneManager.UnloadSceneAsync("Scene_MainMenu");
    //      }

    // }

     public float blinkDuration = 2.0f; // Duração do piscar em segundos
    public float blinkInterval = 0.1f; // Intervalo de piscar
    public string nextSceneName; // Nome da próxima cena
    public float idleFadeSpeed = 1.0f; // Velocidade do fade enquanto em idle

    private TextMeshProUGUI textComponent;
    private bool isBlinking = false;
    //private bool isFading = true;
    private float fadeDirection = 1f; // Controla a direção do fade (aumenta ou diminui a opacidade)

    void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isBlinking)
        {
            StartCoroutine(BlinkAndLoadScene());
        }

        if (!isBlinking)
        {
            FadeText();
        }
    }

    IEnumerator BlinkAndLoadScene()
    {
        isBlinking = true;
        //isFading = false; // Para a animação de fade
        float elapsedTime = 0f;

        while (elapsedTime < blinkDuration)
        {
            textComponent.enabled = !textComponent.enabled;
            yield return new WaitForSeconds(blinkInterval);
            elapsedTime += blinkInterval;
        }

        textComponent.enabled = true; // Certifique-se de que o texto fique visível no final
        SceneManager.LoadScene(nextSceneName);
    }

    void FadeText()
    {
        Color color = textComponent.color;
        color.a += fadeDirection * idleFadeSpeed * Time.deltaTime;

        if (color.a >= 1f)
        {
            color.a = 1f;
            fadeDirection = -1f; // Inverte a direção do fade
        }
        else if (color.a <= 0f)
        {
            color.a = 0f;
            fadeDirection = 1f; // Inverte a direção do fade
        }

        textComponent.color = color;
    }
}



