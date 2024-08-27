using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBlink : MonoBehaviour
{
     public float blinkDuration = 2.0f;
    public float blinkInterval = 0.1f; 
    public float idleFadeSpeed = 1.0f; 

    private TextMeshProUGUI textComponent;
    private float fadeDirection = 1f; 

    void Start(){
        textComponent = GetComponent<TextMeshProUGUI>();
    }

    void Update(){
        FadeText();
    }

    void FadeText()
    {
        Color color = textComponent.color;
        color.a += fadeDirection * idleFadeSpeed * Time.deltaTime;

        if (color.a >= 1f)
        {
            color.a = 1f;
            fadeDirection = -1f;
        }
        else if (color.a <= 0f)
        {
            color.a = 0f;
            fadeDirection = 1f; 
        }

        textComponent.color = color;
    }
}
