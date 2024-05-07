using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class FadeAlpha : MonoBehaviour
{

    [SerializeField] private bool fadeIn = false;
    [SerializeField] private bool fadeOut = false;

    [SerializeField] private float fadeSpeed;

    //Color objectColor = this.GetComponent<Renderer>().material.color;
    // Start is called before the first frame update
    public void ShowUI()
    {
        fadeIn = true;
    }

    public void HideUI()
    {
        fadeOut = true;
    }

    void Start()
    {
        ShowUI();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            HideUI();
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            ShowUI();
        }
        if(fadeOut)
        {
            Color objectColor = this.GetComponent<Renderer>().material.color;
            float fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            this.GetComponent<Renderer>().material.color = objectColor;

            if(objectColor.a <= 0)
            {
                fadeOut = false;
            }
        }
        if(fadeIn)
        {
            Color objectColor = this.GetComponent<Renderer>().material.color;
            float fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            this.GetComponent<Renderer>().material.color = objectColor;

            if(objectColor.a >= 1)
            {
                fadeIn = false;
            }
        }
    }
}
