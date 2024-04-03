using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;

public class VideoPlayerController : MonoBehaviour
{
    public VideoPlayer videoPlayer; 
    public Slider videoSlider; 
    public TMP_Text textTime;
    private bool playVideo;
    public AudioClip auCl;
    void Start()
    {
        videoSlider.onValueChanged.AddListener(AdjustTime);
        //auCl = videoPlayer.clip.aud
        playVideo = true;
    }
    
    void Update()
    {
        videoSlider.value = (float)videoPlayer.time;
        TimeCalc((float)videoPlayer.time);
        //videoPlayer.gameObject.GetComponent<AudioSource>().clip = videoPlayer.clip;
    }

    void TimeCalc(float time)
    {
        int fulltime = (int)time;
        int h = fulltime/360;
        int m = (fulltime/60)%60;
        int s = fulltime%60;
        string text = "";
        if (h < 10)
        {
            text += "0";
            text += h.ToString();
        }
        else text += h.ToString();
        text += ":";
        if (m < 10)
        {
            text += "0";
            text += m.ToString();
        }
        else text += m.ToString();
        text += ":";
        if (s < 10)
        {
            text += "0";
            text += s.ToString();
        }
        else text += s.ToString();

        textTime.text = text;
    }
    void AdjustTime(float time)
    {
        videoPlayer.time = time;
    }

    public void StopPlayer()
    {
        if (playVideo)
        {
            videoPlayer.Pause();
            playVideo = false;
        }
        else
        {
            videoPlayer.Play();
            playVideo = true;
        }
    }
}
