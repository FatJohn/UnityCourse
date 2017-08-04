using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public float FadeInTimeSeconds;

    private Image fadePanel;
    private Color currentColor = Color.black;

    // Use this for initialization
    private void Start()
    {
        fadePanel = GetComponent<Image>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.timeSinceLevelLoad < FadeInTimeSeconds)
        {
            // fade in
            var alphaChange = Time.deltaTime / FadeInTimeSeconds;
            currentColor.a -= alphaChange;
            fadePanel.color = currentColor;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
