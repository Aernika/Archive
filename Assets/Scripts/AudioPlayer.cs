using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioPlayer : MonoBehaviour
{
    public Sprite btn1x;
    public Sprite btn2x;
    public bool status; // false = 1x, true = 2x
    public TMP_Text timerText;
    private bool timerActive;
    private float currentTime;
    private int mult;

    public AudioSource audioSource;
    
    private void Start()
    {
        status = false;
        timerActive = false;
        currentTime = 0f;
        mult = 1;
    }

    public void ClickPlay()
    {
        timerActive = !timerActive;
        if (timerActive) audioSource.Play();
        else audioSource.Pause();
    }
    
    public void ClickSpeed()
    {
        status = !status;
        if (status)
        {
            this.GetComponent<Image>().sprite = btn2x;
            audioSource.pitch = 2f;
            mult = 2;
        }
        else
        {
            this.GetComponent<Image>().sprite = btn1x;
            audioSource.pitch = 1f;
            mult = 1;
        }
    }
    
    void Update()
    {
        if (timerActive)
        {
            currentTime += Time.deltaTime*mult;
            TimeSpan timeSpan = TimeSpan.FromSeconds(currentTime);
            timerText.text = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        }
    }

    public void ResetTimer()
    {
        timerActive = false;
        currentTime = 0f;
        timerText.text = "00:00:00";
    }
}
